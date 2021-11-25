using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueriesTests
{
    private List<TodoItem> _items = new List<TodoItem>();

    public TodoQueriesTests()
    {
        _items.Add(new TodoItem("Todo1", DateTime.Now, "user1"));
        _items[0].UpdateStatus();
        _items.Add(new TodoItem("Todo2", DateTime.Now, "user1"));
        _items.Add(new TodoItem("Todo3", DateTime.Now, "user2"));
        _items.Add(new TodoItem("Todo4", DateTime.Now, "user2"));
    }

    [TestMethod]
    public void OnGetAll()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("user1"));
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void OnGetAllDone()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("user1"));
        Assert.AreEqual(1, result.Count());
    }

    [TestMethod]
    public void OnGetAllUndone()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("user1"));
        Assert.AreEqual(1, result.Count());
    }
}