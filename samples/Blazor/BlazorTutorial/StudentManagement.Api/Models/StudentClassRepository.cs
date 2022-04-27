using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public class StudentClassRepository: IStudentClassRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentClassRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<StudentClass>> GetStudentClasses()
    {
        return await _appDbContext.StudentClasses.ToListAsync();
    }

    public async Task<StudentClass> GetStudentClass(int id)
    {
        return await _appDbContext.StudentClasses.FirstOrDefaultAsync(x => x.ClassId == id);
    }
}