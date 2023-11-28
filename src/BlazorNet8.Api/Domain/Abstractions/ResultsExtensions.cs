namespace BlazorNet8.Api.Domain.Abstractions;

public static class ResultsExtensions
{
    public static List<AdditionalData> AddAdditionalProperties<TModel>(this TModel request) => 
        new() {
            new(new List<Entity>
            {
                new(request?.GetType().FullName!, GetModelProperties(request))
            })
        };

    public static List<AdditionalData>? AddAdditionalProperties<TModel>(this IEnumerable<TModel> entities) =>
        new() { 
            new(entities.Select(entity => 
                new Entity(
                    entity.GetType().Name.ToString(),
                    GetModelProperties(entity)
                )).ToList()
            )
        };

    private static IEnumerable<Property> GetModelProperties<TModel>(this TModel entity) => entity!.GetType()
        .GetProperties().Select(property => new Property(
            property.Name.ToString(), 
            property.GetValue(entity)?.ToString() ?? string.Empty
        ));
    
    public static List<AdditionalData>? MapToResultData<TModel>(this TModel[] entity)
    {
        return entity.Length == 1 ?
            entity.FirstOrDefault().AddAdditionalProperties() : entity.AsEnumerable().AddAdditionalProperties();
    }
    
    public static string GetResultsType([System.Runtime.CompilerServices.CallerMemberName] string methodName = "") =>
        $"Todo.{methodName}";
}

