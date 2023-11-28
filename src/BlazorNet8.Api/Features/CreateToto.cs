using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;
using BlazorNet8.Core.Dtos;

namespace BlazorNet8.Api.Features;

public class CreateToto(ITodoRepository repository)
{
    public async Task<ResultData<TodoResultData>> Handle(TodoRequest todo)
    {
        var entity = await repository.GetTodoByName(todo.Name);

        if (entity is not null)
        {
            return ResultData<TodoResultData>.Failure(TodoResults.TodoWithGivenNameAlreadyExists);
        }

        var newEntity = Todo.Create(todo.Name, todo.Description);
        await repository.AddTodo(newEntity);
        return TodoResults.TodoCreatedSuccessfully(newEntity);
    }
}
