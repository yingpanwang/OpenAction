using System;

namespace OpenAction.Core.Abstraction;

/// <summary>
/// 参数
/// </summary>
/// <typeparam name="T">参数类型</typeparam>
public abstract class Parameter<T> : IComputeable
{
    #region IComputeable

    public virtual T1 Compute<T1>(IExecutionContext context)
    {
        var r = GetValue(context);
        if (r is T1 t1Val)
        {
            return t1Val;
        }
        throw new NotImplementedException();
    }

    public virtual async ValueTask<T1> ComputeAsync<T1>(IExecutionContext context, CancellationToken cancellationToken = default)
    {
        var r = await GetValueAsync(context, cancellationToken);
        if (r is T1 t1Val)
        {
            return t1Val;
        }
        throw new NotImplementedException();
    }


    #endregion

    public abstract T GetValue(IExecutionContext context);

    public abstract ValueTask<T> GetValueAsync(IExecutionContext context, CancellationToken cancellationToken = default);

}

/// <summary>
/// 无固定类型参数
/// </summary>
public abstract class Parameter : Parameter<object>
{
    public override object GetValue(IExecutionContext context)
    {
        return GetValue(context);
    }

    public override ValueTask<object> GetValueAsync(IExecutionContext context, CancellationToken cancellationToken = default)
    {
        return GetValueAsync(context, cancellationToken);
    }
}

/// <summary>
/// 常量参数
/// </summary>
/// <typeparam name="TConstant">常量参数类型</typeparam>
/// <param name="constant">常量值</param>
public class Constant<TConstant>(TConstant constant) : Parameter<TConstant>
{
    private readonly TConstant backField = constant;
    public override TConstant GetValue(IExecutionContext context)
    {
        return backField;
    }

    public override ValueTask<TConstant> GetValueAsync(IExecutionContext context, CancellationToken cancellationToken = default)
    {
        return ValueTask.FromResult(backField);
    }

    public static implicit operator Constant<TConstant>(TConstant constant)
    {
        return new Constant<TConstant>(constant);
    }

    public static implicit operator TConstant(Constant<TConstant> constant)
    {
        return constant.backField;
    }
}
