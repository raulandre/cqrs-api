using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

internal class UpdateTodoStatusCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoStatusCommand()
    {
        Id = Guid.Empty;
        User = string.Empty;
    }

    public UpdateTodoStatusCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<UpdateTodoStatusCommand>()
                .Requires()
                .IsNotNullOrWhiteSpace(User, "User", "User cannot be null or writespace.")
                .IsGreaterOrEqualsThan(User.Length, 6, "User", "User must contain six or more characters.")
            );
    }
}