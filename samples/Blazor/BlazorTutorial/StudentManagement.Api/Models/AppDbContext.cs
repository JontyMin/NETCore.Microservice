using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Api.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<StudentClass> StudentClasses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student Class
        modelBuilder.Entity<StudentClass>().HasData(
            new StudentClass { ClassId = 1, ClassName = "软件工程" });
        modelBuilder.Entity<StudentClass>().HasData(
            new StudentClass { ClassId = 2, ClassName = "计算机科学" });

        // Student
        modelBuilder.Entity<Student>().HasData(new Student
        {
            StudentId = 1,
            FirstName = "John",
            LastName = "Hastings",
            Email = "501211312@qq.com",
            DateOfBrith = new DateTime(1980, 10, 5),
            Gender = Gender.Male,
            ClassId = 1,
            PhotoPath = "images/john.png"
        });

        modelBuilder.Entity<Student>().HasData(new Student
        {
            StudentId = 2,
            FirstName = "Jonty",
            LastName = "Hastings",
            Email = "501211312@qq.com",
            DateOfBrith = new DateTime(1980, 10, 5),
            Gender = Gender.Male,
            ClassId = 2,
            PhotoPath = "images/john.png"
        });
    }
}