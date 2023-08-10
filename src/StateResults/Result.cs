namespace BMTLab.StateResults;

/// <summary>
///     Aggregates the result of some operation into itself.
/// </summary>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Result<TSuccess> : IHasSuccessResult, IHasErrorResult
{
    private readonly TSuccess _successValue;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Result(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
    }


    /// <inheritdoc />
    public bool IsError => false;


    /// <inheritdoc />
    public bool IsSuccess => true;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Result<TSuccess>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Result<TSuccess>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator TSuccess(Result<TSuccess> value)
    {
        ThrowIfNull(value);

        return value._successValue;
    }
}