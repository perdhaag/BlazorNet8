using BlazorNet8.Services;

namespace BlazorNet8;
public static class ServiceCollectionExtensions
{
    public static void AddHttpClients(this IServiceCollection services, IConfigurationManager config)
    {
        services.AddHttpClient<WeatherService>(options =>
        {
            options.BaseAddress = new Uri(config["Api:BaseUrl"]!);
        });

        services.AddHttpClient<TodoService>(options =>
        {
            options.BaseAddress = new Uri(config["Api:BaseUrl"]!);
        });
    }
}
