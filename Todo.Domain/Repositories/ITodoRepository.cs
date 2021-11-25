using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    void Add(TodoItem item);
    void Update(TodoItem item);
    TodoItem? GetById(Guid id, string user);
    IEnumerable<TodoItem>? GetAll(string user);
    IEnumerable<TodoItem>? GetAllDone(string user);
    IEnumerable<TodoItem>? GetAllUndone(string user);
    IEnumerable<TodoItem>? GetFromPeriod(string user, DateTime date, bool done);
}