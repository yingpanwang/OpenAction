using System;

namespace OpenAction.Core.Abstraction;

public interface IActionRunner
{
    public Task RunAsync();

    public ValueTask<IActionResult> GetResultAsync();
}
