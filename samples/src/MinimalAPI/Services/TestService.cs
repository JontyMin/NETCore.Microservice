namespace MinimalAPI.Services;

public static class TestService
{
    public static void TestApi(this WebApplication app)
    {

        app.MapPost("/ServiceApi", (HttpContext context, ITestDependencyInjection testDependencyInjection) =>
        {
            testDependencyInjection.Show();
            return "hello mmp";
        }).WithTags("ServiceApi");
    }
}