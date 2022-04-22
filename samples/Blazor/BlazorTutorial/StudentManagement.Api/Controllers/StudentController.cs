using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Models;
using StudentManagement.Models;

namespace StudentManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetStudents()
    {
        try
        {
            return Ok(await _studentRepository.GetStudents());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "获取数据失败");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        try
        {
            var result = await _studentRepository.GetStudent(id);

            if (result == null) return NotFound();

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "获取数据失败");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        try
        {
            if (student == null)
                return BadRequest();

            // 添加自定义模型验证错误
            var stu = _studentRepository.GetStudentByEmail(student.Email);

            if (stu != null)
            {
                ModelState.AddModelError("email", "邮箱已被使用");
                return BadRequest(ModelState);
            }


            var createdStudent = await _studentRepository.AddStudent(student);

            return CreatedAtAction(nameof(GetStudent),
                new { id = createdStudent.StudentId }, createdStudent);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "创建失败");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
    {
        try
        {
            if (id != student.StudentId)
                return BadRequest("Id不匹配");

            var studentToUpdate = await _studentRepository.GetStudent(id);

            if (studentToUpdate == null)
                return NotFound($"id={id}的学生信息未找到");

            return await _studentRepository.UpdateStudent(student);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "数据更新失败");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Student>> DeleteStudent(int id)
    {
        try
        {
            var studentToDelete = await _studentRepository.GetStudent(id);

            if (studentToDelete == null)
            {
                return NotFound($"Id = {id} 的学生信息未找到");
            }

            return await _studentRepository.DeleteStudent(id);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "数据删除错误");
        }
    }

}