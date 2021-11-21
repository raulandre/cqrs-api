using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    void Add(TodoItem item);
    void Update(TodoItem item);
    TodoItem? GetById(Guid id, string user);
}