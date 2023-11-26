using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class UpdateTodo
{
    private readonly ITodoRepository _repository;

    public record Command(int Id, string Name, string? Desctiption);

    public UpdateTodo(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(Command command)
    {
        var entity = await _repository.GetTodoById(command.Id);

        if (entity == null)
        {
            return Result.Failure(TodoErrors.TodoDoesNotExist);
        }

        entity.UpdateTodo(command.Name, command.Desctiption);

        await _repository.UpdateTodo(entity);

        return Result.Success();
    }
}
