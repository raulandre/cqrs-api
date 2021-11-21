using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validTodo = new TodoItem("Todo", DateTime.Now, "TestUser");
    
    [TestMethod]
    public void OnCreate()
    {
        Assert.IsFalse(_validTodo.Done);
    }
}