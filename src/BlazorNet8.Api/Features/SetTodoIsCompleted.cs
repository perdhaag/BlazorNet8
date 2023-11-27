using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class SetTodoIsCompleted(ITodoRepository repository)
{
    public async Task<Result<TodoSuccessData>> Handle(int id)
    {
        var entity = await repository.GetTodoById(id);
        
        if (entity is null)
        {
            return Result<TodoSuccessData>.Failure(TodoResults.TodoDoesNotExist);
        }

        if (entity.IsCompleted)
            entity.UpdateTodo(entity.Name, entity.Description);
        else
            entity.UpdateTodo(entity.Name, entity.Description, true);
        
        await repository.UpdateTodo(entity);

        return entity.IsCompleted
            ? Result<TodoSuccessData>.Success(TodoResults.TodoSetToCompletedSuccessfully())
            : Result<TodoSuccessData>.Success(TodoResults.TodoUpdatedSuccessfully());
    }
}

