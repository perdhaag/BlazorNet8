using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class SetTodoIsCompleted(ITodoRepository repository)
{
    public async Task<ResultData<TodoResultData>> Handle(int id)
    {
        var entity = await repository.GetTodoById(id);
        
        if (entity is null)
        {
            return ResultData<TodoResultData>.Failure(TodoResults.TodoDoesNotExist);
        }

        if (entity.IsCompleted)
            entity.UpdateTodo(entity.Name, entity.Description);
        else
            entity.UpdateTodo(entity.Name, entity.Description, true);
        
        await repository.UpdateTodo(entity);

        return entity.IsCompleted
            ? TodoResults.TodoSetToCompletedSuccessfully(entity)
            : TodoResults.TodoSetToNotCompletedSuccessfully(entity);
    }
}

