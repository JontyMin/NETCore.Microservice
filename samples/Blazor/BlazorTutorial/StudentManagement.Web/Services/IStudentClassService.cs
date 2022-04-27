using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public interface IStudentClassService
{
    Task<IEnumerable<StudentClass>> GetClasses();
    Task<StudentClass> GetClass(int id);
}