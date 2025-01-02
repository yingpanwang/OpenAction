using System;
using OpenAction.Core.Abstraction;

namespace OpenAction.Core.Actions;

public sealed class EndAction : Action
{
    public override ValueTask ExecuteAsync(ActionExecutionContext context)
    {
        return ValueTask.CompletedTask;
    }
}
