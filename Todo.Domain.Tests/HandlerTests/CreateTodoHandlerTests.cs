using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests;

[TestClass]
public class CreateTodoHandlerTests
{

    private readonly TodoHandler _handler;
    private readonly CreateTodoCommand _invalidCreateTodoCommand;
    private readonly CreateTodoCommand _validCreateTodoCommand;

    public CreateTodoHandlerTests()
    {
        _handler = new TodoHandler(new FakeTodoRepository());
        _invalidCreateTodoCommand = new CreateTodoCommand("", "", DateTime.Now);
        _validCreateTodoCommand = new CreateTodoCommand("Todo", "TestUser", DateTime.Now);
    }       

    [TestMethod]
    public void OnInvalidCommand()
    {
        var result = (GenericCommandResult)(_handler.Handle(_invalidCreateTodoCommand));
        Assert.IsFalse(result.Ok);
    }

    [TestMethod]
    public void OnValidCommand()
    {
        var result = (GenericCommandResult)(_handler.Handle(_validCreateTodoCommand));
        Assert.IsTrue(result.Ok);
    }
}