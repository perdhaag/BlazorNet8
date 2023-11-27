using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorNet8.Api.Repositories;

public interface ITodoRepository
{
    Task<Todo?> GetTodoById(int id);

    Task<Todo?> GetTodoByName(string name);

    Task<int> AddTodo(Todo todo);

    Task UpdateTodo(Todo todo);
}

public class TodoRepository : ITodoRepository
{
    private readonly BlazorNetContext _dbContext;

    public TodoRepository(BlazorNetContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Todo?> GetTodoById(int id)
    {
        var entity = await _dbContext.Todos.FindAsync(id);

        return entity;
    }

    public async Task<Todo?> GetTodoByName(string name)
    {
        var entity = await _dbContext.Todos
            .FirstOrDefaultAsync(x => x.Name == name);

        return entity;
    }

    public async Task<int> AddTodo(Todo todo)
    {
        var entity = _dbContext.Todos.Add(todo);

        await _dbContext.SaveChangesAsync();

        return entity.Entity.Id;
    }

    public async Task UpdateTodo(Todo todo)
    {
        _dbContext.Todos.Update(todo);
        await _dbContext.SaveChangesAsync();
    }
}
