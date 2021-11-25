using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{

    private readonly DataContext _context;

    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(TodoItem item)
    {
        _context.Todos?.Add(item);
        _context.SaveChanges();
    }

    public IEnumerable<TodoItem>? GetAll(string user)
    {
        return _context.Todos?.AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem>? GetAllDone(string user)
    {
        return _context.Todos?.AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<TodoItem>? GetAllUndone(string user)
    {
        return _context.Todos?.AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return _context.Todos?.AsNoTracking()
            .Where(x => x.Id == id && x.User == user)
            .FirstOrDefault();
    }

    public IEnumerable<TodoItem>? GetFromPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos?.AsNoTracking()
            .Where(TodoQueries.GetFromPeriod(user, date, done))
            .OrderBy(x => x.Date);
    }

    public void Update(TodoItem item)
    {
        _context.Entry<TodoItem>(item).State = EntityState.Modified;
        _context.SaveChanges();
    }
}