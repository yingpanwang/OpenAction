using System;
using System.Reflection.Metadata.Ecma335;

namespace OpenAction.Core.Abstraction;

public interface IAction
{
    public string Id { get; }

    public ValueTask ExecuteAsync(ActionExecutionContext context);
}

public interface IAction<TResult> where TResult : IActionResult
{
    public ValueTask<TResult> ExecuteAsync(ActionExecutionContext context);
}

public interface IActionResult
{

}