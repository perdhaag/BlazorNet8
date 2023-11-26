using BlazorNet8.Api.Features;
using BlazorNet8.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BlazorNet8.Api.Endpoints;

public class PostTodo
{
    public record Request(string Name, string Description);

    public static async Task<IResult> Execute(
        [FromBody] Request request,
        CreateToto createToto
    )
    {
        var result = await createToto.Handle(new TodoRequest
        {
            Name = request.Name,
            Description = request.Description,
        });

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}

