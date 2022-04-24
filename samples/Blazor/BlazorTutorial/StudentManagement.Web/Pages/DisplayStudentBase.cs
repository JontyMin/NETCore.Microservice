using Microsoft.AspNetCore.Components;
using StudentManagement.Models;

namespace StudentManagement.Web.Pages;

public class DisplayStudentBase : ComponentBase
{
    [Parameter]
    public Student Student { get; set; }

    [Parameter]
    public bool ShowFooter { get; set; }
}