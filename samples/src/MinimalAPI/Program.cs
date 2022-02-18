using MinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITestDependencyInjection, TestDependencyInjection>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/HelloWorld", () => new {Name = "Jonty", Age = 18})
.WithName("Hello");

app.MapGet("/HelloApi", () => new { Name = "API", Value = "Minimal" })
    .WithName("HelloApi");

app.TestApi();

app.Run();
