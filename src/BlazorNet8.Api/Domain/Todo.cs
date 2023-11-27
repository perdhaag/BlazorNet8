namespace BlazorNet8.Api.Domain;

public class Todo
{
    public int Id { get; init; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public bool IsCompleted { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime UpdatedDate { get; private set; }

    private Todo(string name, string? description)
    {
        Name = name;
        Description = description;
        IsCompleted = false;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }
    public static Todo Create(string name, string? description)
        => new(name, description);

    public void UpdateTodo(string name, string? description, bool isCompleted = false)
    {
        Name = name;
        Description = description;
        IsCompleted = isCompleted;
        UpdatedDate = DateTime.Now;
    }
}