using BlazorNet8.Api.Domain;
using BlazorNet8.Api.Domain.Abstractions;
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

    public async Task<Result<TodoSuccessData>> Execute()
    {
        var todos = await _dbContext.Todos.ToListAsync();

        var result =  todos.Select(x => new TodoDto
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            IsCompleted = x.IsCompleted,
            CreatedDate = x.CreatedDate,
            UpdatedDate = x.UpdatedDate
        });

        return Result<TodoSuccessData>.Success(TodoResults.GetAllTodosSuccessfully(result));
    }
}

