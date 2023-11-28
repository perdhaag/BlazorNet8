using BlazorNet8.Api.Repositories;
using static BlazorNet8.Api.Domain.Abstractions.ResultsExtensions;

namespace BlazorNet8.Api.Domain.Abstractions;

public static class TodoResults
{
    public static readonly Error TodoDoesNotExist = new(GetResultsType(), "Todo does not exist");

    public static readonly Error TodoWithGivenNameAlreadyExists = new(GetResultsType(), "Todo already exists");
    
    public static ResultData<TodoResultData> GetAllTodosSuccessfully(IEnumerable<TodoDto> todos) =>
        TodoResultData.Success(GetResultsType(), todos);
    
    public static ResultData<TodoResultData> TodoCreatedSuccessfully(Todo todo) =>
        TodoResultData.Success(GetResultsType(), todo);
    
    public static ResultData<TodoResultData> TodoUpdatedSuccessfully(Todo todo) =>
        TodoResultData.Success(GetResultsType(), todo);
    
    public static ResultData<TodoResultData> TodoSetToCompletedSuccessfully(Todo todo) =>
         TodoResultData.Success(GetResultsType(), todo);
    
    public static ResultData<TodoResultData> TodoSetToNotCompletedSuccessfully(Todo todo) =>
        TodoResultData.Success(GetResultsType(), todo);
}