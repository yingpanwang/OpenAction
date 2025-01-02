// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using OpenAction.Core;
using OpenAction.Core.Abstraction;
using OpenAction.Core.Actions;
using OpenAction.Core.Runners;

Console.WriteLine("Hello, World!");

using IActionScope scope = new DefaultActionScope();

var ctx = scope.CreateExecutionContext();

var action = scope.GetActions().GetEnumerator();

while (action.MoveNext())
{
    IAction current = action.Current;

    IActionRunner runner = IActionRunnerFactory.Create(ctx, current);

    await runner.RunAsync().ConfigureAwait(false);
}

public interface IActionRunnerFactory
{
    public static IActionRunner Create(ActionExecutionContext executionContext, IAction action)
    {
        return action switch
        {
            _ => new DefaultActionRunner(executionContext)
        };
    }
}

public abstract class ActionEngineBase(
    IActionRunnerFactory actionRunnerFactory
)
{
    public Task StartAsync()
    {
        return Task.CompletedTask;
    }
}