namespace BlazorNet8.Api.Domain.Abstractions;

public class TodoSuccessData : SuccessData<TodoSuccessData>
{
    private TodoSuccessData(string code, List<AdditionalData>? additionalProperties) : base(code,
        additionalProperties) { }

    public static TodoSuccessData Success(string code, List<AdditionalData>? additionalProperties) => 
        new TodoSuccessData(code, additionalProperties);
    
}