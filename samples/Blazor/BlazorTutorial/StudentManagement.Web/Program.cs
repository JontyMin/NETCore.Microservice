using StudentManagement.Web.Models;
using StudentManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("StudentManagementWebContextConnection");;

builder.Services.AddDbContext<StudentManagementWebContext>(options =>
    options.UseSqlServer(connectionString));;

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentManagementWebContext>();;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<IStudentService, StudentService>(option =>
{
    option.BaseAddress = new Uri("http://localhost:5123/");
});
builder.Services.AddHttpClient<IStudentClassService, StudentClassService>(option =>
{
    option.BaseAddress = new Uri("http://localhost:5123/");
});

builder.Services.AddAutoMapper(typeof(StudentProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();
