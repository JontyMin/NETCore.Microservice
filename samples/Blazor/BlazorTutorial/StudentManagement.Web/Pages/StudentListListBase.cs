using Microsoft.AspNetCore.Components;
using StudentManagement.Models;
using StudentManagement.Web.Services;

namespace StudentManagement.Web.Pages;

public class StudentListListBase: ComponentBase
{
    [Inject]
    public IStudentService StudentService { get; set; } 

    public List<Student> Students { get; set; }

    public bool ShowFooter { get; set; } = true;

    protected int SelectedStudentCount { get; set; } = 0;

    protected void StudentSelectionChanged(bool isSelected)
    {
        if (isSelected)
        {
            SelectedStudentCount++;
        }
        else
        {
            SelectedStudentCount--;
        }
    }


    protected override async Task OnInitializedAsync()
    {
        Students = (await StudentService.GetStudents()).ToList();
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
            PhotoPath = "images/john.png"
        };

        Students = new List<Student> {s1, s2, s3, s4};
    }
}