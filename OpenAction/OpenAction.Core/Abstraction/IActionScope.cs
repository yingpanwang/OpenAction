using System;

namespace OpenAction.Core.Abstraction;

public interface IActionScope : IDisposable
{
    public IEnumerable<IAction> GetActions();

    public ActionExecutionContext CreateExecutionContext();
}
