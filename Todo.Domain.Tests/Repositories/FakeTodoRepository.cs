using System;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Add(TodoItem item)
    {
        
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return null;
    }

    public void Update(TodoItem item)
    {
        
    }
}