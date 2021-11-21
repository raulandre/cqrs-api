using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<UpdateTodoStatusCommand>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Please make sure all fields are valid!", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        if(todo is null)
            return new GenericCommandResult(false, "Todo not found!", command.Notifications);

        todo.UpdateTitle(command.Title);
        _repository.Update(todo);
        return new GenericCommandResult(true, "Todo updated successfully!", todo);
    }

    public ICommandResult Handle(UpdateTodoStatusCommand command)
    {
        command.Validate();
        if(!command.IsValid)
            return new GenericCommandResult(false, "Please make sure all fields are valid!", command.Notifications);

        var todo = _repository.GetById(command.Id, command.User);

        if(todo is null)
            return new GenericCommandResult(false, "Todo not found!", command.Notifications);

        todo.UpdateStatus();
        _repository.Update(todo);
        return new GenericCommandResult(true, "Todo updated successfully!", todo);
    }
}
