using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public class StudentClassRepository: IStudentClassRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentClassRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<StudentClass> GetStudentClasses()
    {
        return _appDbContext.StudentClasses;
    }

    public StudentClass GetStudentClass(int id)
    {
        return _appDbContext.StudentClasses.FirstOrDefault(x => x.ClassId == id);
    }
}