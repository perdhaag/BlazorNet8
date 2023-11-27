using BlazorNet8.Api.Features;

namespace BlazorNet8.Api.Endpoints;
public class PostTodoIsCompleted
{
    public static async Task<IResult> Execute(int id, SetTodoIsCompleted todoIsCompleted)
    {
        var result = await todoIsCompleted.Handle(id);

        return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);
    }
}
