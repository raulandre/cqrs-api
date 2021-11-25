using System;
using System.Collections.Generic;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Add(TodoItem item)
    {
        
    }

    public IEnumerable<TodoItem>? GetAll(string user)
    {
        return null;
    }

    public IEnumerable<TodoItem>? GetAllDone(string user)
    {
        return null;
    }

    public IEnumerable<TodoItem>? GetAllUndone(string user)
    {
        return null;
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return null;
    }

    public IEnumerable<TodoItem>? GetFromPeriod(string user, DateTime date, bool done)
    {
        return null;
    }

    public void Update(TodoItem item)
    {
        
    }
}