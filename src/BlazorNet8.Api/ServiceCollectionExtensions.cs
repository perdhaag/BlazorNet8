using BlazorNet8.Api.Features;
using BlazorNet8.Api.Queries;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api;
public static class ServiceCollectionExtensions
{
    public static void AddFeatures(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<GetWeather>();
        services.AddScoped<CreateToto>();
        services.AddScoped<AllTodos>();
        services.AddScoped<UpdateTodo>();
        services.AddScoped<SetTodoIsCompleted>();
    }
}
