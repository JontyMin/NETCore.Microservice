using System.ComponentModel;
using System.Reflection.PortableExecutable;
using AutoMapper;
using Microsoft.AspNetCore.Components;
using StudentManagement.Models;
using StudentManagement.Web.Models;
using StudentManagement.Web.Services;

namespace StudentManagement.Web.Pages;

public class EditStudentBase: ComponentBase
{
    //public Student Student { get; set; } = new Student();

    [Inject]
    public IStudentService StudentService { get; set; }

    [Inject]
    public IStudentClassService StudentClassService { get; set; }


    [Inject]
    public IMapper Mapper { get; set; }

    public List<StudentClass> StudentClasses { get; set; } = new List<StudentClass>();


    public EditStudentModel EditStudentModel { get; set; } = new EditStudentModel();

    [Parameter]
    public string Id { get; set; }

    protected void HandleValidSubmit(){}

    protected override async Task OnInitializedAsync()
    {
        var student= await StudentService.GetStudent(int.Parse(Id));

        Mapper.Map(student, EditStudentModel);

        StudentClasses = (await StudentClassService.GetClasses()).ToList();
    }
}