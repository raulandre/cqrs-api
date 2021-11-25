using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{

    private readonly ITodoRepository _repository;

    public TodoController(ITodoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("todos")]
    public IEnumerable<TodoItem> GetAll()
    {
        return _repository.GetAll("username") ?? new List<TodoItem>();
    }

    [HttpGet("done")]
    public IEnumerable<TodoItem> GetAllDone()
    {
        return _repository.GetAllDone("username") ?? new List<TodoItem>();
    }

    [HttpGet("undone")]
    public IEnumerable<TodoItem> GetAllUndone()
    {
        return _repository.GetAllUndone("username") ?? new List<TodoItem>();
    }

    [HttpGet("done/today")]
    public IEnumerable<TodoItem> GetAllDoneToday()
    {
        return _repository.GetFromPeriod("username", DateTime.Today, true) ?? new List<TodoItem>();
    }

    [HttpGet("undone/today")]
    public IEnumerable<TodoItem> GetAllUndoneToday()
    {
        return _repository.GetFromPeriod("username", DateTime.Today, false) ?? new List<TodoItem>();
    }

    [HttpGet("done/tomorrow")]
    public IEnumerable<TodoItem> GetAllDoneTomorrow()
    {
        return _repository.GetFromPeriod("username", DateTime.Today.AddDays(1), true) ?? new List<TodoItem>();
    }

    [HttpGet("undone/tomorrow")]
    public IEnumerable<TodoItem> GetAllUndoneTomorrow()
    {
        return _repository.GetFromPeriod("username", DateTime.Today.AddDays(1), false) ?? new List<TodoItem>();
    }

    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "username";
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut]
    public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "username";
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("update")]
    public GenericCommandResult UpdateStatus(
        [FromBody] UpdateTodoStatusCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "username";
        return (GenericCommandResult)handler.Handle(command);
    }
}