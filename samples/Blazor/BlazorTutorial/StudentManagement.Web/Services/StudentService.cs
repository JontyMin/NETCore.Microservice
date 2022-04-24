using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public class StudentService:IStudentService
{
    private readonly HttpClient _httpClient;

    public StudentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        return await _httpClient.GetFromJsonAsync<Student[]>("api/student");
    }

    public async Task<Student> GetStudent(int id)
    {
        return await _httpClient.GetFromJsonAsync<Student>($"api/student/{id}");
    }
}