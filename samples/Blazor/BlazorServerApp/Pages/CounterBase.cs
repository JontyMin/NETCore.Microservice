using Microsoft.AspNetCore.Components;

namespace BlazorServerApp.Pages;

public class CounterBase:ComponentBase
{
    protected int currentCount = 0;

    protected void IncrementCount()
    {
        currentCount+=2;
    }
}