using System;
using OpenAction.Core.Abstraction;

namespace OpenAction.Core.Actions;

public class WriteTextAction : Action
{
    public required Constant<string> WriteText { get; set; }

    public override ValueTask ExecuteAsync(ActionExecutionContext context)
    {
        var text = WriteText.GetValue(context);

        Console.WriteLine(text);

        return ValueTask.CompletedTask;
    }
}
