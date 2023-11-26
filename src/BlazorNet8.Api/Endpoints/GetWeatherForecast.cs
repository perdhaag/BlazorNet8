using BlazorNet8.Api.Queries;

namespace BlazorNet8.Api.Endpoints;
public class GetWeatherForecast
{
    public static async Task<IResult> Execute(GetWeather getWeather)
    {
        var result = await getWeather.Execute();

        return Results.Ok(result);
    }
}
