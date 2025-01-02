using System;

namespace OpenAction.Core.Abstraction;

/// <summary>
/// 可动态计算对象
/// </summary>
public interface IComputeable
{
    T Compute<T>(IExecutionContext context);

    ValueTask<T> ComputeAsync<T>(IExecutionContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// 可动态计算对象基类
/// </summary>
public abstract class ComputeableBase : IComputeable
{
    public abstract T Compute<T>(IExecutionContext context);

    public virtual ValueTask<T> ComputeAsync<T>(IExecutionContext context, CancellationToken cancellationToken = default)
    {
        // 默认实现同步调用，但可以被子类重写
        return new ValueTask<T>(Compute<T>(context));
    }
}