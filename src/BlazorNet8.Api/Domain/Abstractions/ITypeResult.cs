namespace BlazorNet8.Api.Domain.Abstractions;

public interface ITypeResult
{
    public string? ErrorType { get; set; }
    public int TodoId { get; set; }
    public string TodoName { get; set; }
}