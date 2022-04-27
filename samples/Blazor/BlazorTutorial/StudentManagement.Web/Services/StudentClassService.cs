using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public class StudentClassService : IStudentClassService
{
    private readonly HttpClient _httpClient;

    public StudentClassService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<StudentClass>> GetClasses()
    {
        return await _httpClient.GetFromJsonAsync<StudentClass[]>("api/studentclass");
    }

    public async Task<StudentClass> GetClass(int id)
    {
        return await _httpClient.GetFromJsonAsync<StudentClass>($"api/studentclass/{id}");
    }
}