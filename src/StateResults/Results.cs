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
public readonly record struct Results<TSuccess, TError> : IOneOf, IHasSuccessResult, IHasErrorResult
    where TSuccess: notnull
    where TError: notnull
{
    // Align the size of the structure
    private readonly short _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        Success = value;
        Error = default;
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
        Success = default;
        Error = value;
    }


    /// <summary>
    ///     Trying to get the successful <typeparamref name="TSuccess"/> value.
    /// </summary>
    public TSuccess? Success { get; }

    /// <summary>
    ///     Trying to get the error <typeparamref name="TError"/> value.
    /// </summary>
    public TError? Error { get; }

    /// <inheritdoc />
    public object Value => _index switch
    {
        0 when Success is not null => Success,
        1 when Error is not null   => Error,
        var _                      => throw new InvalidOperationException(CorruptedMessage)
    };

    /// <inheritdoc />
    public int Index => _index;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;

    /// <inheritdoc />
    public bool IsSuccess => _index == 0;


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TError>(TSuccess value) =>
        new(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TError>(TError value) =>
        new(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(Results<TSuccess, TError> value) =>
        value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TError(Results<TSuccess, TError> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<TError>();
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<TError, TResult> error
    )
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when Success is not null => success(Success),
            1 when Error is not null   => error(Error),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
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
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<TError, Task<TResult>> error
    )
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when Success is not null => success(Success),
            1 when Error is not null   => error(Error),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public void Switch
    (
        Action<TSuccess> success,
        Action<TError> error
    )
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        switch (_index)
        {
            case 0 when Success is not null:
            {
                success(Success);

                break;
            }
            case 1 when Error is not null:
            {
                error(Error);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync
    (
        Func<TSuccess, Task> success,
        Func<TError, Task> error
    )
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when Success is not null => success(Success),
            1 when Error is not null   => error(Error),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <inheritdoc />
    /// <example>
    ///     <code>
    ///         { Value = Success { Message = custom msg }, IsSuccess = True }
    ///         { Value = InternalError { Message = custom msg, Exception = System.ArgumentException: inner exception msg }, IsSuccess = False }
    ///     </code>
    /// </example>
    public override string ToString() =>
        _index switch
        {
            0     => FormatValue(Success),
            1     => FormatValue(Error, false),
            var _ => string.Empty
        };



    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = _index switch
            {
                0     => Success?.GetHashCode(),
                1     => Error?.GetHashCode(),
                var _ => default
            } ?? 0;

            return HashCode.Combine(hashCode, _index);
        }
    }
}