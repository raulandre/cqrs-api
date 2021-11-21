namespace Todo.Domain.Entities;

internal class Todo : Entity
{
    public Todo(string title, DateTime date, string user)
    {
        Title = title;
        Date = date;
        User = user;
    }

    public string Title { get; private set; }
    public bool Done { get; private set; }
    public DateTime Date { get; private set; }
    public string User { get; private set; }

    public void UpdateStatus()
    {
        Done = !Done;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
    }
}
