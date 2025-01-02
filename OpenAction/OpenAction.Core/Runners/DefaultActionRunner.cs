using System;
using OpenAction.Core.Abstraction;

namespace OpenAction.Core.Runners;

public sealed class DefaultActionRunner : IActionRunner
{
    public DefaultActionRunner(ActionExecutionContext context)
    {
    }

    public Task RunAsync()
    {
        throw new NotImplementedException();
    }
}
