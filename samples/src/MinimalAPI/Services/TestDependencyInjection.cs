namespace MinimalAPI.Services;

public class TestDependencyInjection: ITestDependencyInjection
{
    public void Show()
    {
        Console.WriteLine("Hello DI~");
    }
}