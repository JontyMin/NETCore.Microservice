using Microsoft.AspNetCore.Components;
using StudentManagement.Models;

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

    protected async Task CheckBoxChanged(ChangeEventArgs e)
    {
        IsSelected = (bool)e.Value;
        await OnStudentSelection.InvokeAsync(IsSelected);
    }
}