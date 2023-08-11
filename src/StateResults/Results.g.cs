/*
    This file was generated automatically, do not make changes to it manually!
*/
#nullable enable

using OneOf;

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
public readonly record struct Results<TSuccess, TE0, TE1> : IHasSuccessResult, IHasErrorResult
{
    // Store an index to track the state of this object
    // 'short' to align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;
    private readonly OneOf<TE0, TE1>? _errorUnion;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorUnion = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(OneOf<TE0, TE1> value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorUnion = value;
    }


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1>(TE0 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1>(TE1 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TE0, TE1> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator OneOf<TE0, TE1>?(Results<TSuccess, TE0, TE1> value) => value._errorUnion;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE0?(Results<TSuccess, TE0, TE1> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT0
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE1?(Results<TSuccess, TE0, TE1> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT1
            : default;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<OneOf<TE0, TE1>, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
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
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<OneOf<TE0, TE1>, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<OneOf<TE0, TE1>> error)
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
            case 1 when _errorUnion is not null:
            {
                error(_errorUnion.Value);

                break;
            }
            default : throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<OneOf<TE0, TE1>, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }
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
public readonly record struct Results<TSuccess, TE0, TE1, TE2> : IHasSuccessResult, IHasErrorResult
{
    // Store an index to track the state of this object
    // 'short' to align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;
    private readonly OneOf<TE0, TE1, TE2>? _errorUnion;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorUnion = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(OneOf<TE0, TE1, TE2> value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorUnion = value;
    }


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(TE0 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(TE1 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2>(TE2 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TE0, TE1, TE2> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator OneOf<TE0, TE1, TE2>?(Results<TSuccess, TE0, TE1, TE2> value) => value._errorUnion;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE0?(Results<TSuccess, TE0, TE1, TE2> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT0
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE1?(Results<TSuccess, TE0, TE1, TE2> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT1
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE2?(Results<TSuccess, TE0, TE1, TE2> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT2
            : default;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<OneOf<TE0, TE1, TE2>, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
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
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<OneOf<TE0, TE1, TE2>, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<OneOf<TE0, TE1, TE2>> error)
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
            case 1 when _errorUnion is not null:
            {
                error(_errorUnion.Value);

                break;
            }
            default : throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<OneOf<TE0, TE1, TE2>, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }
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
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3> : IHasSuccessResult, IHasErrorResult
{
    // Store an index to track the state of this object
    // 'short' to align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;
    private readonly OneOf<TE0, TE1, TE2, TE3>? _errorUnion;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorUnion = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(OneOf<TE0, TE1, TE2, TE3> value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorUnion = value;
    }


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(TE0 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(TE1 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(TE2 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3>(TE3 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TE0, TE1, TE2, TE3> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator OneOf<TE0, TE1, TE2, TE3>?(Results<TSuccess, TE0, TE1, TE2, TE3> value) => value._errorUnion;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE0?(Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT0
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE1?(Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT1
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE2?(Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT2
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE3?(Results<TSuccess, TE0, TE1, TE2, TE3> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT3
            : default;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<OneOf<TE0, TE1, TE2, TE3>, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
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
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<OneOf<TE0, TE1, TE2, TE3>, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<OneOf<TE0, TE1, TE2, TE3>> error)
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
            case 1 when _errorUnion is not null:
            {
                error(_errorUnion.Value);

                break;
            }
            default : throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<OneOf<TE0, TE1, TE2, TE3>, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }
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
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3, TE4> : IHasSuccessResult, IHasErrorResult
{
    // Store an index to track the state of this object
    // 'short' to align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;
    private readonly OneOf<TE0, TE1, TE2, TE3, TE4>? _errorUnion;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorUnion = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(OneOf<TE0, TE1, TE2, TE3, TE4> value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorUnion = value;
    }


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TE0 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TE1 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TE2 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TE3 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(TE4 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator OneOf<TE0, TE1, TE2, TE3, TE4>?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) => value._errorUnion;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE0?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT0
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE1?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT1
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE2?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT2
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE3?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT3
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE4?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT4
            : default;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4>, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
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
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4>, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<OneOf<TE0, TE1, TE2, TE3, TE4>> error)
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
            case 1 when _errorUnion is not null:
            {
                error(_errorUnion.Value);

                break;
            }
            default : throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4>, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }
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
public readonly record struct Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> : IHasSuccessResult, IHasErrorResult
{
    // Store an index to track the state of this object
    // 'short' to align the size of the structure
    private readonly short _index = 0;

    private readonly TSuccess? _successValue;
    private readonly OneOf<TE0, TE1, TE2, TE3, TE4, TE5>? _errorUnion;


    /// <summary>
    ///     Initializes the result object with a successful state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(TSuccess value)
    {
        ThrowIfNull(value);

        _successValue = value;
        _errorUnion = default;
    }

    /// <summary>
    ///     Initializes the result object with a state indicating that the result is unsuccessful.
    /// </summary>
    /// <param name="value">Arbitrary error result object.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Results(OneOf<TE0, TE1, TE2, TE3, TE4, TE5> value)
    {
        ThrowIfNull(value);

        _index = 1;
        _successValue = default;
        _errorUnion = value;
    }


    /// <inheritdoc />
    public bool IsSuccess => _index == 0;

    /// <inheritdoc />
    public bool IsError => !IsSuccess;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TSuccess value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE0 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE1 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE2 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE3 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE4 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static implicit operator Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(TE5 value)
    {
        ThrowIfNull(value);

        return new Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5>(value);
    }


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TSuccess?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) => value._successValue;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator OneOf<TE0, TE1, TE2, TE3, TE4, TE5>?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) => value._errorUnion;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE0?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT0
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE1?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT1
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE2?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT2
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE3?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT3
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE4?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT4
            : default;


    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    [Pure]
    public static explicit operator TE5?(Results<TSuccess, TE0, TE1, TE2, TE3, TE4, TE5> value) =>
        value._errorUnion.HasValue
            ? value._errorUnion.Value.AsT5
            : default;


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Function that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Function that will be executed in case of an unsuccessful state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    [Pure]
    public TResult Match<TResult>(Func<TSuccess, TResult> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, TResult> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
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
    public Task<TResult> MatchAsync<TResult>(Func<TSuccess, Task<TResult>> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, Task<TResult>> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public void Switch(Action<TSuccess> success, Action<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>> error)
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
            case 1 when _errorUnion is not null:
            {
                error(_errorUnion.Value);

                break;
            }
            default : throw new InvalidOperationException();
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current result.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="success">Action that will be executed in case of an unsuccessful state.</param>
    /// <param name="error">Action that will be executed in case of an unsuccessful state.</param>
    /// <exception cref="InvalidOperationException">Any of the delegates is <c>null</c>.</exception>
    public Task SwitchAsync(Func<TSuccess, Task> success, Func<OneOf<TE0, TE1, TE2, TE3, TE4, TE5>, Task> error)
    {
        ThrowIfNull(success);
        ThrowIfNull(error);

        return _index switch
        {
            0 when _successValue is not null => success(_successValue),
            1 when _errorUnion is not null   => error(_errorUnion.Value),
            var _                            => throw new InvalidOperationException()
        };
    }
}


