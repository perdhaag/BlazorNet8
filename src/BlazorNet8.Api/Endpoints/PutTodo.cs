using BlazorNet8.Api.Features;

namespace BlazorNet8.Api.Endpoints;

public class PutTodo
{
    public static async Task<IResult> Execute(int id, string name, string? description, UpdateTodo updateTodo)
    {
        var result = await updateTodo
            .Handle(new UpdateTodo.Command(
                id,
                name,
                description)
            );

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}

