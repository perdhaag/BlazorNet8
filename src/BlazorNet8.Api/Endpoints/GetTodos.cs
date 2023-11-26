using BlazorNet8.Api.Queries;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Endpoints;

public class GetTodos
{
    public static async Task<IResult> Execute(AllTodos allTodos)
    {
        var result = await allTodos.Execute();

        return Results.Ok(result);
    }
}

