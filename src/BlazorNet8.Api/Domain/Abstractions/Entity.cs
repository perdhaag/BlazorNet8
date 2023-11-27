namespace BlazorNet8.Api.Domain.Abstractions;

public record Entity(string Name, IEnumerable<Property> Properties);