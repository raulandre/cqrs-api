using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand()
    {
        Id = Guid.Empty;
        Title = string.Empty;
        User = string.Empty;
    }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<UpdateTodoCommand>()
                .Requires()
                .IsNotNullOrWhiteSpace(Title, "Title", "Title cannot be null or whitespace.")
                .IsNotNullOrWhiteSpace(User, "User", "User cannot be null or writespace.")
                .IsGreaterOrEqualsThan(Title.Length, 3, "Title", "Title must contain three or more characters.")
                .IsGreaterOrEqualsThan(User.Length, 6, "User", "User must contain six or more characters.")
            );
    }
}
