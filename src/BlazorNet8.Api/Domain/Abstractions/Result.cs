namespace BlazorNet8.Api.Domain.Abstractions;

public class Result<T> where T : SuccessData<T>
{
    public bool IsSuccess { get; }
    
    public Error? Error { get; }
   
    public SuccessData<T>? SuccessData { get; set; }
    
    private Result(bool isSuccess, Error error, SuccessData<T>? successData)
    {
        if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = IsSuccess ? null : error;
        SuccessData = successData;
    }
    
    public static Result<T> Success(SuccessData<T> data)
    {
        return new Result<T>(true, Error.None, data);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(false, error, null);
    }
}