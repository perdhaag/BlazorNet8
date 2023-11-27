namespace BlazorNet8.Api.Domain.Abstractions;

public static class TodoResultsExtensions
{
    public static List<AdditionalData> AddAdditionalProperties(bool isCompleted) =>
        new()
        {
            new(new List<Entity>
            {
                new("id",
                    new List<Property>
                    {
                        new("isCompleted", isCompleted.ToString())
                    })
            })
        };
    
}