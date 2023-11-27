using System.Text.Json;
using BlazorNet8.Services.Dtos;

namespace BlazorNet8.Core.Services;

public class WeatherService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public WeatherService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<WeatherDto>?> GetWeather()
    {
        var response = await _client.GetAsync("weatherforecast");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<IEnumerable<WeatherDto>>(json, _jsonSerializerOptions);
    }
}
