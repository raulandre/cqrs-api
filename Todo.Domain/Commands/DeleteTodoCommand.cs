using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class DeleteTodoCommand : Notifiable<Notification>, ICommand
{
    public DeleteTodoCommand(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<DeleteTodoCommand>()
                .Requires()
                .IsNotNullOrWhiteSpace(Id.ToString(), "Title", "Title cannot be null or whitespace.")
            );
    }
}
