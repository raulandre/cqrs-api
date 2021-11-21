using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests;

[TestClass]
public class CreateTodoCommandTests
{

    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Todo", "TestUser", DateTime.Now);

    public CreateTodoCommandTests()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void OnInvalidCommand()
    {
        Assert.IsFalse(_invalidCommand.IsValid);
    }

    [TestMethod]
    public void OnValidCommand()
    {
        Assert.IsTrue(_validCommand.IsValid);
    }
}