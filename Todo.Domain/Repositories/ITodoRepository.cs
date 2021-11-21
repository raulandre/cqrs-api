using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

public interface ITodoRepository
{
    void Add(TodoItem item);
    void Update(TodoItem item);
}