using Microsoft.AspNetCore.Components;
using StudentManagement.Models;
using StudentManagement.Web.Services;

namespace StudentManagement.Web.Pages;

public class DisplayStudentBase : ComponentBase
{
    [Parameter]
    public Student Student { get; set; }

    [Parameter]
    public bool ShowFooter { get; set; }

    protected bool IsSelected { get; set; }

    [Parameter]
    public EventCallback<bool> OnStudentSelection { get; set; }

    [Parameter]
    public EventCallback<int> OnStudentDeleted { get; set; }

    [Inject] public IStudentService StudentService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    protected ConfirmBase DeleteConfirmation { get; set; }

    protected async Task Delete_Click()
    {
        /*await StudentService.DeleteStudent(Student.StudentId);
        await OnStudentDeleted.InvokeAsync(Student.StudentId);
        //NavigationManager.NavigateTo("/", true);*/

        DeleteConfirmation.Show();
    }

    protected async Task ConfirmDelete_Click(bool deleteConfirmed)
    {
        if (deleteConfirmed)
        {
            await StudentService.DeleteStudent(Student.StudentId);
            await OnStudentDeleted.InvokeAsync(Student.StudentId);
        }
    }

    protected async Task CheckBoxChanged(ChangeEventArgs e)
    {
        IsSelected = (bool)e.Value;
        await OnStudentSelection.InvokeAsync(IsSelected);
    }
}