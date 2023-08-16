/*
    NOTE: Auto-generated file.
    Don't make manual changes here.
*/
#nullable enable
#pragma warning disable CS1591
// Missing XML comment for publicly visible type or member

namespace BMTLab.StateResults;

/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TE0">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE1">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TE0, TE1> : IOneOf, IHasSuccessOrErrorResult
    where TSuccess: notnull
    where TE0: notnull
    where TE1: notnull
{
    // Store an index to track the state of this object
    private readonly int _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(in TSuccess value)
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
    public Results(in OneOf<TE0, TE1> value)
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
    ///     Trying to get the error union.
    /// </summary>
    public OneOf<TE0, TE1>? Error { get; }

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
    public static implicit operator Results<TSuccess, TE0, TE1>(in TSuccess value) =>
        new Results<TSuccess, TE0, TE1>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1>(in TE0 value) =>
        new Results<TSuccess, TE0, TE1>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1>(in TE1 value) =>
        new Results<TSuccess, TE0, TE1>(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(in Results<TSuccess, TE0, TE1> value) =>
       value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator OneOf<TE0, TE1>(in Results<TSuccess, TE0, TE1> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<OneOf<TE0, TE1>>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE0(in Results<TSuccess, TE0, TE1> value) =>
        value is { _index: 1, Error: not null } ? (TE0) value.Error : ThrowInvalidCastException<TE0>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE1(in Results<TSuccess, TE0, TE1> value) =>
        value is { _index: 1, Error: not null } ? (TE1) value.Error : ThrowInvalidCastException<TE1>();


    public static bool operator true(in Results<TSuccess, TE0, TE1> result) => result.IsSuccess;
    public static bool operator false(in Results<TSuccess, TE0, TE1> result) => result.IsError;
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<OneOf<TE0, TE1>, TResult> error
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
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<OneOf<TE0, TE1>, Task<TResult>> error
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
        Action<OneOf<TE0, TE1>> error
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
        Func<OneOf<TE0, TE1>, Task> error
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
    [Pure]
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
    public override int GetHashCode() =>
        HashCode.Combine(_index, Value);
}


/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TE0">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE1">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE2">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TE0, TE1, TE2> : IOneOf, IHasSuccessOrErrorResult
    where TSuccess: notnull
    where TE0: notnull
    where TE1: notnull
    where TE2: notnull
{
    // Store an index to track the state of this object
    private readonly int _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(in TSuccess value)
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
    public Results(in OneOf<TE0, TE1, TE2> value)
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
    ///     Trying to get the error union.
    /// </summary>
    public OneOf<TE0, TE1, TE2>? Error { get; }

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
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(in TSuccess value) =>
        new Results<TSuccess, TE0, TE1, TE2>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(in TE0 value) =>
        new Results<TSuccess, TE0, TE1, TE2>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(in TE1 value) =>
        new Results<TSuccess, TE0, TE1, TE2>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(in TE2 value) =>
        new Results<TSuccess, TE0, TE1, TE2>(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(in Results<TSuccess, TE0, TE1, TE2> value) =>
       value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator OneOf<TE0, TE1, TE2>(in Results<TSuccess, TE0, TE1, TE2> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<OneOf<TE0, TE1, TE2>>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE0(in Results<TSuccess, TE0, TE1, TE2> value) =>
        value is { _index: 1, Error: not null } ? (TE0) value.Error : ThrowInvalidCastException<TE0>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE1(in Results<TSuccess, TE0, TE1, TE2> value) =>
        value is { _index: 1, Error: not null } ? (TE1) value.Error : ThrowInvalidCastException<TE1>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE2(in Results<TSuccess, TE0, TE1, TE2> value) =>
        value is { _index: 1, Error: not null } ? (TE2) value.Error : ThrowInvalidCastException<TE2>();


    public static bool operator true(in Results<TSuccess, TE0, TE1, TE2> result) => result.IsSuccess;
    public static bool operator false(in Results<TSuccess, TE0, TE1, TE2> result) => result.IsError;
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<OneOf<TE0, TE1, TE2>, TResult> error
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
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<OneOf<TE0, TE1, TE2>, Task<TResult>> error
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
        Action<OneOf<TE0, TE1, TE2>> error
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
        Func<OneOf<TE0, TE1, TE2>, Task> error
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
    [Pure]
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
    public override int GetHashCode() =>
        HashCode.Combine(_index, Value);
}


/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TE0">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE1">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE2">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE3">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3> : IOneOf, IHasSuccessOrErrorResult
    where TSuccess: notnull
    where TE0: notnull
    where TE1: notnull
    where TE2: notnull
    where TE3: notnull
{
    // Store an index to track the state of this object
    private readonly int _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(in TSuccess value)
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
    public Results(in OneOf<TE0, TE1, TE2, TE3> value)
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
    ///     Trying to get the error union.
    /// </summary>
    public OneOf<TE0, TE1, TE2, TE3>? Error { get; }

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
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(in TSuccess value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(in TE0 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(in TE1 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(in TE2 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(in TE3 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3>(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
       value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator OneOf<TE0, TE1, TE2, TE3>(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<OneOf<TE0, TE1, TE2, TE3>>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE0(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value is { _index: 1, Error: not null } ? (TE0) value.Error : ThrowInvalidCastException<TE0>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE1(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value is { _index: 1, Error: not null } ? (TE1) value.Error : ThrowInvalidCastException<TE1>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE2(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value is { _index: 1, Error: not null } ? (TE2) value.Error : ThrowInvalidCastException<TE2>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE3(in Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value is { _index: 1, Error: not null } ? (TE3) value.Error : ThrowInvalidCastException<TE3>();


    public static bool operator true(in Results<TSuccess, TE0, TE1, TE2, TE3> result) => result.IsSuccess;
    public static bool operator false(in Results<TSuccess, TE0, TE1, TE2, TE3> result) => result.IsError;
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<OneOf<TE0, TE1, TE2, TE3>, TResult> error
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
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<OneOf<TE0, TE1, TE2, TE3>, Task<TResult>> error
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
        Action<OneOf<TE0, TE1, TE2, TE3>> error
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
        Func<OneOf<TE0, TE1, TE2, TE3>, Task> error
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
    [Pure]
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
    public override int GetHashCode() =>
        HashCode.Combine(_index, Value);
}


/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TE0">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE1">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE2">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE3">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE4">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3, TE4> : IOneOf, IHasSuccessOrErrorResult
    where TSuccess: notnull
    where TE0: notnull
    where TE1: notnull
    where TE2: notnull
    where TE3: notnull
    where TE4: notnull
{
    // Store an index to track the state of this object
    private readonly int _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(in TSuccess value)
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
    public Results(in OneOf<TE0, TE1, TE2, TE3, TE4> value)
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
    ///     Trying to get the error union.
    /// </summary>
    public OneOf<TE0, TE1, TE2, TE3, TE4>? Error { get; }

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
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TSuccess value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TE0 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TE1 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TE2 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TE3 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(in TE4 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
       value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator OneOf<TE0, TE1, TE2, TE3, TE4>(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<OneOf<TE0, TE1, TE2, TE3, TE4>>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE0(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? (TE0) value.Error : ThrowInvalidCastException<TE0>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE1(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? (TE1) value.Error : ThrowInvalidCastException<TE1>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE2(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? (TE2) value.Error : ThrowInvalidCastException<TE2>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE3(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? (TE3) value.Error : ThrowInvalidCastException<TE3>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE4(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value is { _index: 1, Error: not null } ? (TE4) value.Error : ThrowInvalidCastException<TE4>();


    public static bool operator true(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> result) => result.IsSuccess;
    public static bool operator false(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4> result) => result.IsError;
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<OneOf<TE0, TE1, TE2, TE3, TE4>, TResult> error
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
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<OneOf<TE0, TE1, TE2, TE3, TE4>, Task<TResult>> error
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
        Action<OneOf<TE0, TE1, TE2, TE3, TE4>> error
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
        Func<OneOf<TE0, TE1, TE2, TE3, TE4>, Task> error
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
    [Pure]
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
    public override int GetHashCode() =>
        HashCode.Combine(_index, Value);
}


/// <summary>
///     Aggregates the result of some operation into itself. The result may be successful or not.
/// </summary>
/// <remarks>There can only be one state at a time.</remarks>
/// <typeparam name="TSuccess">Type of successful result.</typeparam>
/// <typeparam name="TE0">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE1">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE2">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE3">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE4">Type of possible unsuccessful result.</typeparam>
/// <typeparam name="TE5">Type of possible unsuccessful result.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> : IOneOf, IHasSuccessOrErrorResult
    where TSuccess: notnull
    where TE0: notnull
    where TE1: notnull
    where TE2: notnull
    where TE3: notnull
    where TE4: notnull
    where TE5: notnull
{
    // Store an index to track the state of this object
    private readonly int _index = 0;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(in TSuccess value)
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
    public Results(in OneOf<TE0, TE1, TE2, TE3, TE4, TE5> value)
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
    ///     Trying to get the error union.
    /// </summary>
    public OneOf<TE0, TE1, TE2, TE3, TE4, TE5>? Error { get; }

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
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TSuccess value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE0 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE1 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE2 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE3 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE4 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(in TE5 value) =>
        new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TSuccess(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
       value is { _index: 0, Success: not null } ? value.Success : ThrowInvalidCastException<TSuccess>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator OneOf<TE0, TE1, TE2, TE3, TE4, TE5>(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? value.Error : ThrowInvalidCastException<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE0(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE0) value.Error : ThrowInvalidCastException<TE0>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE1(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE1) value.Error : ThrowInvalidCastException<TE1>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE2(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE2) value.Error : ThrowInvalidCastException<TE2>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE3(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE3) value.Error : ThrowInvalidCastException<TE3>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE4(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE4) value.Error : ThrowInvalidCastException<TE4>();

    /// <exception cref="InvalidCastException"><paramref name="value" /> is not stored here right now.</exception>
    public static explicit operator TE5(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value is { _index: 1, Error: not null } ? (TE5) value.Error : ThrowInvalidCastException<TE5>();


    public static bool operator true(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> result) => result.IsSuccess;
    public static bool operator false(in Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> result) => result.IsError;
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="ArgumentNullException">Any of the delegates is <c>null</c>.</exception>
    public TResult Match<TResult>
    (
        Func<TSuccess, TResult> success,
        Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, TResult> error
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
    public Task<TResult> MatchAsync<TResult>
    (
        Func<TSuccess, Task<TResult>> success,
        Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, Task<TResult>> error
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
        Action<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>> error
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
        Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, Task> error
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
    [Pure]
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
    public override int GetHashCode() =>
        HashCode.Combine(_index, Value);
}


