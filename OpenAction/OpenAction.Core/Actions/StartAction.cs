using System;
using OpenAction.Core.Abstraction;

namespace OpenAction.Core.Actions;

public sealed class StartAction : Action
{
    public override ValueTask ExecuteAsync(ActionExecutionContext context)
    {
        return ValueTask.CompletedTask;
    }
}
