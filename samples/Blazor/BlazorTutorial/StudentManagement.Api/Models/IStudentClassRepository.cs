using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public interface IStudentClassRepository
{
    IEnumerable<StudentClass> GetStudentClasses();
    StudentClass GetStudentClass(int id);
}