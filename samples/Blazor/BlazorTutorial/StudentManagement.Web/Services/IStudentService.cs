using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetStudents();

    Task<Student> GetStudent(int id);
}