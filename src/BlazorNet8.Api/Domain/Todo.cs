namespace BlazorNet8.Api.Domain;

public class Todo
{
    public int Id { get; init; }

    public string Name { get; private set; } = null!;

    public string? Description { get; private set; }

    public bool Completed { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime UpdatedDate { get; private set; }

    public Todo(string name, string description)
    {
        Name = name;
        Description = description;
        Completed = false;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public Todo UpdateTodo(string name, string? description)
    {
        Name = name;
        Description = description;
        UpdatedDate = DateTime.Now;
        return this;
    }

    public Todo SetTodoToCompleted()
    {
        Completed = true;
        UpdatedDate = DateTime.Now;
        return this;
    }
}