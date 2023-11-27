namespace BlazorNet8.Api.Domain.Abstractions;
public interface ISuccessBaseData
{
    string? AssemblyName { get; set; }
    string Code { get; set; }
}

public class SuccessData<T> : ISuccessBaseData
{
    public string Code { get; set; }
    public string? AssemblyName { get; set; }
    
    public List<AdditionalData>? AdditionalProperties { get; set; }
    protected SuccessData(string code, List<AdditionalData>? additionalProperties)
    {
        Code = code;
        AssemblyName = typeof(T).Name;
        AdditionalProperties = additionalProperties;
    }
    public static List<AdditionalData>? AddAdditionalProperties<TModel>(IEnumerable<TModel> entities)
    {
        var additionalProperties = entities.Select(entity =>
        {
            var properties = GetModelProperties(entity);
            return new Entity(
                entity!.GetType().FullName!, 
                new List<Property>(properties)
            );
        }).ToList();

        return new List<AdditionalData> { new(additionalProperties) };
    }

    private static IEnumerable<Property> GetModelProperties<TModel>(TModel entity)
    {
        var properties = entity!.GetType().GetProperties();
        return properties.Select(property =>
            new Property(
                property.Name,
                property.GetValue(entity)?.ToString() ?? string.Empty)
        );
    }
}