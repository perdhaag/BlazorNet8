using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class SetTodoToCompleted
{
    private readonly ITodoRepository _repository;

    public SetTodoToCompleted(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(int id)
    {
        var entity = await _repository.GetTodoById(id);
        
        if (entity is null)
        {
            return Result.Failure(TodoErrors.TodoDoesNotExist);
        }

        if (entity.Completed)
        {
            return Result.Failure(TodoErrors.TodoAlreadyCompleted);
        }

        entity.SetTodoToCompleted();

        await _repository.UpdateTodo(entity);

        return Result.Success();
    }
}

