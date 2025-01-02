using System;
using OpenAction.Core.Abstraction;
using OpenAction.Core.Actions;

namespace OpenAction.Core;

public sealed class DefaultActionScope : IActionScope
{
    public DefaultActionScope()
    {

    }

    public ActionExecutionContext CreateExecutionContext()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<IAction> GetActions()
    {
        StartAction start = new() { Id = "" };

        yield return start;

        EndAction end = new() { Id = "" };

        yield return end;
    }
}
