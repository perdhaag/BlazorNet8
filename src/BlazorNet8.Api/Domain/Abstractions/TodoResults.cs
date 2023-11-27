using BlazorNet8.Api.Repositories;

namespace BlazorNet8.Api.Domain.Abstractions;

public static class TodoResults
{
    public static readonly Error TodoDoesNotExist = new("TodoError.TodoDoesNotExist", "Todo does not exist");

    public static readonly Error TodoNameAlreadyExists = new("TodoError.TodoNameAlreadyExists", "Todo already exists");

    public static readonly Error TodoAlreadyExist = new("TodoError.TodoAlreadyExist", "Todo already exists");

    public static readonly Error TodoAlreadyCompleted = new("TodoError.TodoAlreadyCompleted", "Todo is already completed");

    public static readonly Error TodoIsNotCompleted = new("TodoError.TodoIsNotCompleted", "Todo is not completed");

    public static TodoSuccessData GetAllTodosSuccessfully(IEnumerable<TodoDto> todos)
    {
        var additionalProperties = SuccessData<TodoSuccessData>.AddAdditionalProperties(todos);
        return TodoSuccessData.Success("Todo.GetAllTodosSuccessfully", additionalProperties);
    }

    public static TodoSuccessData TodoCreatedSuccessfully()
    {
        var additionalProperties = new List<AdditionalData>
        {
            new(new List<Entity>
            {
                new("id",
                    new List<Property> { new("isCompleted", false.ToString()) })

            })
        };
        return TodoSuccessData.Success("Todo.TodoCreatedSuccessfully", additionalProperties);
    }

    public static SuccessData<TodoSuccessData> TodoUpdatedSuccessfully()
    {
        var additionalProperties = new List<AdditionalData>
        {
            new(new List<Entity>
            {
                new("id",
                    new List<Property> { new("isCompleted", false.ToString()) })
            })
        };
        return TodoSuccessData.Success("Todo.TodoUpdatedSuccessfully", additionalProperties);
    }

    public static SuccessData<TodoSuccessData> TodoSetToCompletedSuccessfully()
    {
        var additionalProperties = new List<AdditionalData>
        {
            new(new List<Entity>
            {
                new("id",
                    new List<Property> { new("isCompleted", true.ToString()) })
            })
        };
        return TodoSuccessData.Success("Todo.TodoSetToCompletedSuccessfully", additionalProperties);
    }
}