using AutoMapper;
using Microsoft.AspNetCore.Components;
using StudentManagement.Models;
using StudentManagement.Web.Models;
using StudentManagement.Web.Services;

namespace StudentManagement.Web.Pages;

public class EditStudentBase: ComponentBase
{
    public string PageHeader { get; set; }

    public Student Student { get; set; }

    [Inject]
    public IStudentService StudentService { get; set; }

    [Inject]
    public IStudentClassService StudentClassService { get; set; }


    [Inject]
    public IMapper Mapper { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    public List<StudentClass> StudentClasses { get; set; } = new();


    public EditStudentModel EditStudentModel { get; set; } = new();

    [Parameter]
    public string Id { get; set; }

    protected async Task HandleValidSubmit()
    {
        Mapper.Map(EditStudentModel, Student);

        Student result = null;

        if (Student.StudentId!=0)
        {
            result = await StudentService.UpdateStudent(int.Parse(Id), Student);
        }
        else
        {
            result = await StudentService.CreateStudent(Student);
        }
        
        if (result != null)
        {
            NavigationManager.NavigateTo("/students");
        }
    }

    protected override async Task OnInitializedAsync()
    {
        int.TryParse(Id, out int studentId);

        if (studentId!=0)
        {
            PageHeader = "编辑学生";
            Student = await StudentService.GetStudent(studentId);
        }
        else
        {
            PageHeader = "新增学生";

            Student = new Student
            {
                ClassId = 1,
                DateOfBrith = DateTime.Now,
                PhotoPath = "images/nophoto.jpg",
                Class = new StudentClass
                {
                    ClassName = "test"
                }
            };
        }

        Mapper.Map(Student, EditStudentModel);

        StudentClasses = (await StudentClassService.GetClasses()).ToList();
    }

    protected async Task Delete_Click()
    {
        await StudentService.DeleteStudent(Student.StudentId);
        NavigationManager.NavigateTo("/students");
    }
}