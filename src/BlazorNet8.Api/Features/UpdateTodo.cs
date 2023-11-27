using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class UpdateTodo(ITodoRepository repository)
{
    public record Command(int Id, string Name, string? Description);

    public async Task<Result<TodoSuccessData>> Handle(Command command)
    {
        var entity = await repository.GetTodoById(command.Id);

        if (entity == null)
        {
            return Result<TodoSuccessData>.Failure(TodoResults.TodoDoesNotExist);
        }

        entity.UpdateTodo(command.Name, command.Description);

        await repository.UpdateTodo(entity);

        return Result<TodoSuccessData>.Success(TodoResults.TodoUpdatedSuccessfully());
    }
}
