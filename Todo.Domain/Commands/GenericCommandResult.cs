using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

internal class GenericCommandResult : ICommandResult
{
    public GenericCommandResult()
    {
        Message = string.Empty;
        Data = string.Empty;
    }

    public GenericCommandResult(bool ok, string message, object data)
    {
        Ok = ok;
        Message = message;
        Data = data;
    }

    public bool Ok { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}