using BlazorNet8.Api.Features;

namespace BlazorNet8.Api.Endpoints;
public class CompleteTodo
{
    public static async Task<IResult> Execute(int id, SetTodoToCompleted todoToCompleted)
    {
        var result = await todoToCompleted.Handle(id);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
