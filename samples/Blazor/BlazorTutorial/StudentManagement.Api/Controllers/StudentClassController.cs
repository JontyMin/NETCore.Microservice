using Microsoft.AspNetCore.Mvc;
using StudentManagement.Api.Models;
using StudentManagement.Models;

namespace StudentManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentClassController : ControllerBase
{
    private readonly IStudentClassRepository _studentClassRepository;

    public StudentClassController(IStudentClassRepository studentClassRepository)
    {
        _studentClassRepository = studentClassRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetClasses()
    {
        try
        {
            return Ok(await _studentClassRepository.GetStudentClasses());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "数据获取失败");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentClass>> GetClass(int id)
    {
        try
        {
            var result = await _studentClassRepository.GetStudentClass(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "数据获取失败");
        }
    }
}