using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;
using BlazorNet8.Core.Dtos;

namespace BlazorNet8.Api.Features;

public class CreateToto
{
    private readonly ITodoRepository _repository;

    public CreateToto(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(TodoRequest todo)
    {
        var entity = await _repository.GetTodoByName(todo.Name);

        if (entity is not null)
        {
            return Result.Failure(TodoErrors.TodoNameAlreadyExists);
        }

        await _repository.AddTodo(new Todo(todo.Name, todo.Description));

        return Result.Success();
    }
}
