
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StudentManagement.Models;

namespace StudentManagement.Web.Services;

public class StudentService : IStudentService
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

    public async Task<Student> UpdateStudent(int id, Student entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/student/{id}", entity);
        
      
        if (response.IsSuccessStatusCode)
        {
            var jsonstr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Student>(jsonstr);
        }

        return null;
    }

    public async Task<Student> CreateStudent(Student entity)
    {
        /*var js = JsonConvert.SerializeObject(entity, new JsonSerializerSettings
        {
            // 设置为驼峰命名
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        });

        var httpContent = new StringContent(
            js,
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.PostAsync("api/student", httpContent);
        // var response = await _httpClient.PostAsJsonAsync("api/student", content);


        if (response.IsSuccessStatusCode)
        {
            var jsonstr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Student>(jsonstr);
        }

        return null;

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));*/

    
        var response = await _httpClient.PostAsJsonAsync("api/student", entity);

        if (response.IsSuccessStatusCode)
        {
            var jsonstr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Student>(jsonstr);
        }

        return null;
       
    }
    public async Task DeleteStudent(int id)
    {
        await _httpClient.DeleteAsync($"api/student/{id}");
    }

}