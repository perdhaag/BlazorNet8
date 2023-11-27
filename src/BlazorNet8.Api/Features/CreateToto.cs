using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;
using BlazorNet8.Core.Dtos;

namespace BlazorNet8.Api.Features;

public class CreateToto(ITodoRepository repository)
{
    public async Task<Result<TodoSuccessData>> Handle(TodoRequest todo)
    {
        var entity = await repository.GetTodoByName(todo.Name);

        if (entity is not null)
        {
            return Result<TodoSuccessData>.Failure(TodoResults.TodoNameAlreadyExists);
        }

        await repository.AddTodo(Todo.Create(todo.Name, todo.Description));

        return Result<TodoSuccessData>.Success(TodoResults.TodoCreatedSuccessfully());
    }
}
