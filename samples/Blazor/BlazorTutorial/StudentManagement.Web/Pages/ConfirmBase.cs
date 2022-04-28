using Microsoft.AspNetCore.Components;

namespace StudentManagement.Web.Pages;

public class ConfirmBase : ComponentBase
{
    protected bool ShowConfirmation { get; set; }

    [Parameter]
    public string ConfirmationTitle { get; set; } = "删除确认";

    [Parameter]
    public string ConfirmationMessage { get; set; } = "确认删除吗？";

    public void Show()
    {
        ShowConfirmation = true;
        StateHasChanged();
    }

    [Parameter]
    public EventCallback<bool> ConfirmationChanged { get; set; }

    protected async Task OnConfirmationChange(bool value)
    {
        ShowConfirmation = false;
        await ConfirmationChanged.InvokeAsync(value);
    }
}