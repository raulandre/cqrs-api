using Todo.Domain.Entities;

namespace Todo.Domain.Repositories;

internal interface ITodoRepository
{
    void Add(TodoItem item);
    void Update(TodoItem item);
}