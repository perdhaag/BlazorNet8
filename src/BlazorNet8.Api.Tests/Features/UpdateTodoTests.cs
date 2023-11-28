using BlazorNet8.Api.Domain.Abstractions;
using BlazorNet8.Api.Features;
using BlazorNet8.Api.Repositories;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using FluentAssertions;

namespace BlazorNet8.Api.Tests.Features;

public class UpdateTodoTests
{
    private readonly UpdateTodo _updateTodo;
    private readonly ITodoRepository _repository;

    public UpdateTodoTests()
    {
        _repository = Substitute.For<ITodoRepository>();
        _updateTodo = new UpdateTodo(_repository);
    }

    [Fact]
    public async Task UpdateTodo_Should_ReturnFailure_WhenTodoDontExist()
    {
        var command = new UpdateTodo.UpdateTodoCommand(1, "Test", "Test");
        _repository.GetTodoById(Arg.Any<int>()).ReturnsNullForAnyArgs();

        var result = await _updateTodo.Handle(command);

        result.Should().BeOfType<ResultData<TodoResultData>>();
    }
}