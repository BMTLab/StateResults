using System.ComponentModel;

namespace BMTLab.StateResults;

/// <summary>
///     Aggregates the result of some operation into itself.
/// </summary>
/// <typeparam name="T">Type of result (successful or not).</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Result<T> : IHasSuccessResult, IHasErrorResult
{
    private readonly T _value;


    /// <summary>
    ///     Initializes the result object with a certain state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Result(T value)
    {
        ThrowIfNull(value);

        _value = value;
    }


    /// <inheritdoc />
    [DefaultValue(true)]
    public bool IsSuccess { get; init; } = true;


    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Result<T>(T value)
    {
        ThrowIfNull(value);

        return new Result<T>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator T(Result<T> value)
    {
        ThrowIfNull(value);

        return value._value;
    }
}