using System.Net.Http.Json;
using System.Text.Json;
using BlazorNet8.Api.Repositories;
using BlazorNet8.Core.Dtos;

namespace BlazorNet8.Core.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoDto>?> GetTodos();
    Task<bool> CreateTodoItem(TodoRequest request);
    Task <bool> UpdateTodo(int id, string name, string? description);
    Task<bool> CompleteTodo(int id);
}

public class TodoService : ITodoService
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public TodoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CreateTodoItem(TodoRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("todo", request);
        response.EnsureSuccessStatusCode();

        return true;
    }


    public async Task<IEnumerable<TodoDto>?> GetTodos()
    {
        var response = await _httpClient.GetAsync("todo");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<IEnumerable<TodoDto>>(json, _jsonSerializerOptions);
    }

    public async Task<bool> UpdateTodo(int id, string name, string? description)
    {
        var response = await _httpClient.PutAsync($"todo/{id}?name={name}&description={description}", null);
        response.EnsureSuccessStatusCode();

        return true;
    }

    public async Task<bool> CompleteTodo(int id)
    {
        var response = await _httpClient.PostAsync($"todo/{id}", null);
        response.EnsureSuccessStatusCode();

        return true;
    }
}
