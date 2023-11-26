using BlazorNet8.Services.Dtos;

namespace BlazorNet8.Api.Queries;
public class GetWeather
{
    public Task<IEnumerable<WeatherDto>> Execute()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecast = Enumerable
            .Range(1, 5)
            .Select(index => new WeatherDto
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

        return Task.FromResult(forecast);
    }
}
