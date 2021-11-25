using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;

namespace Todo.Domain.Api;

[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase
{

    [HttpPost]
    public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
    )
    {
        command.User = "username";
        return (GenericCommandResult)handler.Handle(command);
    }
}