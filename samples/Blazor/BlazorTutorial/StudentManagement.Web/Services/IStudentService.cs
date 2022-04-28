using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudents();

    Task<Student> GetStudent(int id);

    Task<Student> UpdateStudent(int id,Student entity);

    Task<Student> CreateStudent(Student entity);

    Task DeleteStudent(int id);
}