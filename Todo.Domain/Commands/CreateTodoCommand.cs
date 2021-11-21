using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

internal class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    public CreateTodoCommand()
    {
        Title = string.Empty;
        User = string.Empty;
    }

    public CreateTodoCommand(string title, string user, DateTime date)
    {
        Title = title;
        User = user;
        Date = date;
    }

    public string Title { get; set; }
    public string User { get; set; }
    public DateTime Date { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateTodoCommand>()
                .Requires()
                .IsNotNullOrWhiteSpace(Title, "Title", "Title cannot be null or whitespace.")
                .IsNotNullOrWhiteSpace(User, "User", "User cannot be null or writespace.")
                .IsNotNull(Date, "Date", "Date cannot be null.")
                .IsGreaterOrEqualsThan(Title.Length, 3, "Title", "Title must contain three or more characters.")
                .IsGreaterOrEqualsThan(User.Length, 6, "User", "User must contain six or more characters.")
                .IsGreaterOrEqualsThan(Date, DateTime.Now, "Date", "Date must be now or future.")
            );
    }
}