namespace Todo.Domain.Commands.Contracts;

internal interface ICommand
{
    void Validate();
}
