using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public interface IStudentClassRepository
{
    Task<IEnumerable<StudentClass>> GetStudentClasses();
    Task<StudentClass> GetStudentClass(int id);
}