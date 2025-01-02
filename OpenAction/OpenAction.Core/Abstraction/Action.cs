using System;

namespace OpenAction.Core.Abstraction;

public abstract class Action : IAction
{
    public required string Id { get; set; }

    public abstract ValueTask ExecuteAsync(ActionExecutionContext context);
}
