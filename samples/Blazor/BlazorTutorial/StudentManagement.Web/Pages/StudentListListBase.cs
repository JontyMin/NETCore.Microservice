using Microsoft.AspNetCore.Components;
using StudentManagement.Models;

namespace StudentManagement.Web.Pages;

public class StudentListListBase: ComponentBase
{
    public List<Student> Students { get; set; }


    protected override async Task OnInitializedAsync()
    {
        await Task.Run(LoadStudents);
    }

    private void LoadStudents()
    {
        Thread.Sleep(2000);

        var s1 = new Student()
        {
            StudentId = 1,
            FirstName = "John",
            LastName = "Hastings",
            Email = "David@qq.com",
            DateOfBrith = new DateTime(1980, 10, 5),
            Gender = Gender.Male,
            StudentClass = new StudentClass {ClassId = 1, ClassName = "计算机科学"},
            PhotoPath = "images/john.png"
        };

        var s2 = new Student()
        {
            StudentId = 2,
            FirstName = "Sam",
            LastName = "Galloway",
            Email = "Sam@qq.com",
            DateOfBrith = new DateTime(1981, 12, 22),
            Gender = Gender.Male,
            StudentClass = new StudentClass { ClassId = 2, ClassName = "软件工程" },
            PhotoPath = "images/john.png"
        };

        var s3 = new Student()
        {
            StudentId = 3,
            FirstName = "Mary",
            LastName = "Smith",
            Email = "mary@qq.com",
            DateOfBrith = new DateTime(1979, 11, 11),
            Gender = Gender.Female,
            StudentClass = new StudentClass { ClassId = 3, ClassName = "通信工程" },
            PhotoPath = "images/john.png"
        };

        var s4 = new Student()
        {
            StudentId = 4,
            FirstName = "Sara",
            LastName = "Longway",
            Email = "sara@qq.com",
            DateOfBrith = new DateTime(1982, 9, 23),
            Gender = Gender.Female,
            StudentClass = new StudentClass { ClassId = 3, ClassName = "移动互联网" },
            PhotoPath = "images/john.png"
        };

        Students = new List<Student> {s1, s2, s3, s4};
    }
}