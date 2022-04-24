using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
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

    protected string Coordinates { get; set; }
    protected string ButtonText { get; set; } = "隐藏";
    protected string CssClass { get; set; } = null;

    protected void Button_Click()
    {
        if (ButtonText == "隐藏")
        {
            ButtonText = "显示";
            CssClass = "HideFooter";
        }
        else
        {
            CssClass = null;
            ButtonText = "隐藏";
        }
    }

    /*protected void Mouse_Move(MouseEventArgs e)
    {
        Coordinates = $"X = {e.ClientX } Y = {e.ClientY}";
    }*/

    protected override async Task OnInitializedAsync()
    {
        Id = Id ?? "1";
        Student =await StudentService.GetStudent(int.Parse(Id));
    }
}