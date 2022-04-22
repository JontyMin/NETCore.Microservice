using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetStudents();
    Task<Student> GetStudent(int studentId);
    Task<Student> AddStudent(Student student);
    Task<Student>UpdateStudent(Student student);
    Task<Student> DeleteStudent(int studentId);
    Task<Student> GetStudentByEmail(string email);
}