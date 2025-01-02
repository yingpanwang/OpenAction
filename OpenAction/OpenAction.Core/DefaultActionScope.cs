using System;
using OpenAction.Core.Abstraction;
using OpenAction.Core.Actions;

namespace OpenAction.Core;

public sealed class DefaultActionScope : IActionScope
{
    Guid rId = Guid.NewGuid();

    public DefaultActionScope()
    {
        Console.WriteLine($"-- Begin Scope {rId} --");
    }

    public ActionExecutionContext CreateExecutionContext()
    {
        return new ActionExecutionContext();
    }

    public void Dispose()
    {
        Console.WriteLine($"-- End Scope {rId} --");
    }

    public IEnumerable<IAction> GetActions()
    {
        StartAction start = new() { Id = "1" };

        yield return start;

        WriteTextAction write = new() { Id = "2", WriteText = "Hello world" };

        yield return write;

        EndAction end = new() { Id = "3" };

        yield return end;
    }
}
