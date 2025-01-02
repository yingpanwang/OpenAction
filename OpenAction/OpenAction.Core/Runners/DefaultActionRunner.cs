using System;
using OpenAction.Core.Abstraction;

namespace OpenAction.Core.Runners;

public sealed class DefaultActionRunner : IActionRunner
{
    private readonly ActionExecutionContext _context;
    private readonly IAction _action;
    public DefaultActionRunner(ActionExecutionContext context, IAction action)
    {
        _context = context;
        _action = action;
    }

    public Task RunAsync()
    {
        return _action.ExecuteAsync(_context).AsTask();
    }

    public ValueTask<IActionResult> GetResultAsync()
    {
        return ValueTask.FromResult<IActionResult>(default);
    }

}
