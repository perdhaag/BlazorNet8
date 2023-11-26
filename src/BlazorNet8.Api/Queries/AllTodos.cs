using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Infrastructure;
using BlazorNet8.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BlazorNet8.Api.Queries;

public class AllTodos
{
    private readonly BlazorNetContext _dbContext;

    public AllTodos(BlazorNetContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TodoDto>> Execute()
    {
        var todos = await _dbContext.Todos.ToListAsync();

        return todos.Select(x => new TodoDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsCompleted = x.Completed,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate
        });
    }
}

