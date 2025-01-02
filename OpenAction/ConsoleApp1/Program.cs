// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using OpenAction.Core;
using OpenAction.Core.Abstraction;
using OpenAction.Core.Actions;
using OpenAction.Core.Runners;

//Console.WriteLine("Hello, World!");

await Engine.StartAsync("hello world", []);

// using IActionScope scope = new DefaultActionScope();
// var ctx = scope.CreateExecutionContext();

// var actions = scope.GetActions().GetEnumerator();

// while (actions.MoveNext())
// {
//     IAction current = actions.Current;

//     IActionRunner runner = IActionRunnerFactory.Create(ctx, current);

//     await runner.RunAsync().ConfigureAwait(false);

//     var result = await runner.GetResultAsync().ConfigureAwait(false);
// }

public class Engine
{
    public static async Task StartAsync(string id, Parameter[] inputs)
    {
        using var scope = new DefaultActionScope();

        var ctx = scope.CreateExecutionContext();

        var actions = scope.GetActions().GetEnumerator();

        while (actions.MoveNext())
        {
            IAction current = actions.Current;

            IActionRunner runner = IActionRunnerFactory.Create(ctx, current);

            await runner.RunAsync().ConfigureAwait(false);

            await runner.GetResultAsync().ConfigureAwait(false);
        }
    }
}

public class ActionFlow
{
    public required string Id { get; set; }

    public IAction[] Actions { get; set; } = [];
}

public interface IActionRunnerFactory
{
    public static IActionRunner Create(ActionExecutionContext executionContext, IAction action)
    {
        return action switch
        {
            _ => new DefaultActionRunner(executionContext, action)
        };
    }
}