using BlazorNet8.Api.Endpoints;
using BlazorNet8.Api.Features;

namespace BlazorNet8.Api;

public static class EndpointConfiguration
{
    public static void AddEndpoints(this WebApplication app)
    {
        app.MapGet("/weatherforecast", GetWeatherForecast.Execute)
            .WithName("GetWeatherForecast")
            .WithOpenApi();

        app.MapPost("/todo", PostTodo.Execute);
        app.MapGet("/todo", GetTodos.Execute);
        app.MapPut("/todo/{id}", PutTodo.Execute);
        app.MapPost("/todo/{id}", PostTodoIsCompleted.Execute);
    }
}