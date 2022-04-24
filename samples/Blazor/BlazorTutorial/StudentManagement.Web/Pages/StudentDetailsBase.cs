using Microsoft.AspNetCore.Components;
using StudentManagement.Models;
using StudentManagement.Web.Services;

namespace StudentManagement.Web.Pages;

public class StudentDetailsBase:ComponentBase
{
    public Student Student { get; set; } = new Student();

    [Inject]
    public IStudentService StudentService { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        Student =await StudentService.GetStudent(int.Parse(Id));
    }
}