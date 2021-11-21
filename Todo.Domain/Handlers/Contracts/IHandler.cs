using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts;

internal interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}