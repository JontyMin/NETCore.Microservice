using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public class StudentRepository: IStudentRepository
{
    private readonly AppDbContext _appDbContext;

    public StudentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _appDbContext.Students.ToListAsync();
    }

    public async Task<Student> GetStudent(int studentId)
    {
        return await _appDbContext.Students
            .Include(x=>x.Class)
            .FirstOrDefaultAsync(x => x.StudentId == studentId);
    }

    public async Task<Student> AddStudent(Student student)
    {
        var result = await _appDbContext.Students.AddAsync(student);
        await _appDbContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Student> UpdateStudent(Student student)
    {
        var result = await _appDbContext.Students
            .FirstOrDefaultAsync(e => e.StudentId == student.StudentId);

        if (result == null) return null;
        result.FirstName = student.FirstName;
        result.LastName = student.LastName;
        result.Email = student.Email;
        result.DateOfBrith = student.DateOfBrith;
        result.Gender = student.Gender;
        result.ClassId = student.ClassId;
        result.PhotoPath = student.PhotoPath;

        await _appDbContext.SaveChangesAsync();

        return result;

    }

    public async Task<Student> DeleteStudent(int studentId)
    {
        var result = await _appDbContext.Students
            .FirstOrDefaultAsync(e => e.StudentId == studentId);
        if (result == null) return null;
        _appDbContext.Students.Remove(result);
        await _appDbContext.SaveChangesAsync();
        return result;

    }

    public async Task<Student> GetStudentByEmail(string email)
    {
        return await _appDbContext.Students
            .FirstOrDefaultAsync(e => e.Email == email);
    }

    public async Task<IEnumerable<Student>> Search(string name, Gender? gender)
    {
        IQueryable<Student> query = _appDbContext.Students;

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(e => e.FirstName.Contains(name)
                                     || e.LastName.Contains(name));
        }

        if (gender != null)
        {
            query = query.Where(e => e.Gender == gender);
        }

        return await query.ToListAsync();
    }
}