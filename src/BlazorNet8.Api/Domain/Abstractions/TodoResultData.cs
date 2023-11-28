using static BlazorNet8.Api.Domain.Abstractions.ResultsExtensions;

namespace BlazorNet8.Api.Domain.Abstractions;

public class TodoResultData : ResultData<TodoResultData>
{
    private TodoResultData(bool isSuccess, Error? error, List<AdditionalData>? additionalProperties) : base(isSuccess, error, additionalProperties, GetResultsType()) { }
}