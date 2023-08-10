namespace BMTLab.StateResults;

/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TError">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TError> : IHasSuccessResult, IHasErrorResult
{
    private readonly TError? _errorValue;

    // Align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorValue = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TError value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorValue = value;
    }


    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TError>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TError>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TError>(TError value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TError>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TError> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TError?(Results<TSuccess, TError> value) => value._errorValue;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<TError, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorValue is not null   => error(_errorValue),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<TError, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorValue is not null   => error(_errorValue),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<TError> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        switch (_index)
        {
            case 0 when _successValue is not null:
            {
                success(_successValue);

                break;
            }
            case 1 when _errorValue is not null:
            {
                error(_errorValue);

                break;
            }
            default: throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<TError, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorValue is not null   => error(_errorValue),
            var _                            => throw new InvalidOperationException()
        };
    }
}