namespace BlazorNet8.Api.Domain.Abstractions;

public static class SuccessDataExtensions
{
    public static List<AdditionalData> AddAdditionalProperties(bool isCompleted)
    {
        var additionalProperties = new List<AdditionalData>
        {
            new(new List<Entity>
            {
                new("id",
                    new List<Property> { new("isCompleted", isCompleted.ToString()) })
            })
        };
        return additionalProperties;
    }
}