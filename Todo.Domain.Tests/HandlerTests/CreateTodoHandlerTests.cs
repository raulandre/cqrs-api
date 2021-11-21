using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{

    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());
    private readonly CreateTodoCommand _invalidCreateTodoCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCreateTodoCommand = new CreateTodoCommand("Todo", "TestUser", DateTime.Now);
    private GenericCommandResult _result = new GenericCommandResult();   

    [TestMethod]
    public void OnInvalidCommand()
    {
        _result = (GenericCommandResult)(_handler.Handle(_invalidCreateTodoCommand));
        Assert.IsFalse(_result.Ok);
    }

    [TestMethod]
    public void OnValidCommand()
    {
        _result = (GenericCommandResult)(_handler.Handle(_validCreateTodoCommand));
        Assert.IsTrue(_result.Ok);
    }
}