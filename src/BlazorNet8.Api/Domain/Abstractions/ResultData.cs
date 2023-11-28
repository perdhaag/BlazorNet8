using static BlazorNet8.Api.Domain.Abstractions.ResultsExtensions;

namespace BlazorNet8.Api.Domain.Abstractions;
public interface IResultBaseData
{
    public bool IsSuccess { get; }
    
    public Error? Error { get; }
    
    public string? Code { get; set; }
    public List<AdditionalData>? AdditionalProperties { get; set; }
}

public class ResultData<T> : IResultBaseData
{
    public bool IsSuccess { get; }
    
    public Error? Error { get; }
    
    public string? Code { get; set; }
    public List<AdditionalData>? AdditionalProperties { get; set; }

    public static ResultData<T> Success<TModel>(string? method, params TModel[]? entity) => new(
        true,
        Error.None,
        entity?.MapToResultData(),
        method
    );
    
    public static ResultData<T> Failure(Error? error) =>
        new(false, error, null, error?.Code);
    
    protected ResultData(bool isSuccess, Error? error, List<AdditionalData>? additionalProperties, string? method)
    {
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Code = method;
        Error = IsSuccess ? null : error;
        AdditionalProperties = !IsSuccess ? null : additionalProperties;
    }
}