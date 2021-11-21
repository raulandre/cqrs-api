using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

internal class TodoHandler : IHandler<CreateTodoCommand>
{

    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Please make sure all fields are valid!", command.Notifications);

        var todo = new TodoItem(command.Title, command.Date, command.User);

        _repository.Add(todo);
        return new GenericCommandResult(true, "Todo created successfully!", todo);
    }
}
