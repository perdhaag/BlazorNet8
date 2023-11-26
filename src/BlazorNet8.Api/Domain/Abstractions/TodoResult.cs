namespace BlazorNet8.Api.Domain.Abstractions;

public static class TodoErrors
{
    public static readonly Error TodoDoesNotExist = new("TodoError.TodoDoesNotExist", "Todo does not exist");

    public static readonly Error TodoNameAlreadyExists = new("TodoError.TodoNameAlreadyExists", "Todo alreadt exists");

    public static readonly Error TodoAlreadyExist = new("TodoError.TodoAlreadyExist", "Todo already exist");

    public static readonly Error TodoAlreadyCompleted =
        new("TodoError.TodoAlreadyCompleted", "Todo is already completed");
}

