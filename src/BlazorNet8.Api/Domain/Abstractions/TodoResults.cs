using BlazorNet8.Api.Repositories;
using static BlazorNet8.Api.Domain.Abstractions.SuccessDataExtensions;

namespace BlazorNet8.Api.Domain.Abstractions;

public static class TodoResults
{
    public static readonly Error TodoDoesNotExist = new("TodoError.TodoDoesNotExist", "Todo does not exist");

    public static readonly Error TodoNameAlreadyExists = new("TodoError.TodoNameAlreadyExists", "Todo already exists");

    public static readonly Error TodoAlreadyExist = new("TodoError.TodoAlreadyExist", "Todo already exists");

    public static readonly Error TodoAlreadyCompleted = new("TodoError.TodoAlreadyCompleted", "Todo is already completed");

    public static readonly Error TodoIsNotCompleted = new("TodoError.TodoIsNotCompleted", "Todo is not completed");

    public static TodoSuccessData GetAllTodosSuccessfully(IEnumerable<TodoDto> todos) =>
        TodoSuccessData.Success(
            "Todo.GetAllTodosSuccessfully", 
            SuccessData<TodoSuccessData>.AddAdditionalProperties(todos)
        );
    
    public static TodoSuccessData TodoCreatedSuccessfully()
    {
        return TodoSuccessData.Success("Todo.TodoCreatedSuccessfully", AddAdditionalProperties(false));
    }

    public static SuccessData<TodoSuccessData> TodoUpdatedSuccessfully()
    {
        return TodoSuccessData.Success("Todo.TodoUpdatedSuccessfully", AddAdditionalProperties(false));
    }



    public static SuccessData<TodoSuccessData> TodoSetToCompletedSuccessfully()
    {
        return TodoSuccessData.Success("Todo.TodoSetToCompletedSuccessfully", AddAdditionalProperties(true));
    }
}