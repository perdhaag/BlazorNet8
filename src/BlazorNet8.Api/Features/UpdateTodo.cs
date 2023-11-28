using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Features;
public class UpdateTodo
{
    public record UpdateTodoCommand(int Id, string Name, string? Description);

    private readonly ITodoRepository _repository;

    public UpdateTodo(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultData<TodoResultData>> Handle(UpdateTodoCommand command)
    {
        var entity = await _repository.GetTodoById(command.Id);

        if (entity == null)
        {
            return ResultData<TodoResultData>.Failure(TodoResults.TodoDoesNotExist);
        }

        entity.UpdateTodo(command.Name, command.Description);

        await _repository.UpdateTodo(entity);

        return TodoResults.TodoUpdatedSuccessfully(entity);
    }
}