using BlazorNet8.Core.Services;
using BlazorNet8.Services;
using Microsoft.FluentUI.AspNetCore.Components;

namespace BlazorNet8;
public static class ServiceCollectionExtensions
{
    public static void AddHttpClients(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddHttpClient();

        services.AddHttpClient<WeatherService>(options =>
        {
            options.BaseAddress = new Uri(config["Api:BaseUrl"]!);
        });

        services.AddHttpClient<ITodoService, TodoService>(options =>
        {
            options.BaseAddress = new Uri(config["Api:BaseUrl"]!);
        });
    }
    
    public static void AddUiComponents(this IServiceCollection services)
    {
        services.AddFluentUIComponents();
    }
}
