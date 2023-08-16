/*
    This file was generated automatically, do not make changes to it manually!
*/
#nullable enable

namespace BMTLab.OneOf.Reduced;

/// <summary>
///     Represents a type-union that can contain only one of the values.
/// </summary>
/// <typeparam name="T0">Possible state type.</typeparam>
/// <typeparam name="T1">Possible state type.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public class OneOf<T0, T1> : IOneOf, IEquatable<OneOf<T0, T1>>
    where T0: notnull
    where T1: notnull
{
    private readonly T0? _value0;
    private readonly T1? _value1;

    private OneOf
    (
        int index,
        T0? value0 = default,
        T1? value1 = default
    )
    {
        Index = index;
        _value0 = value0;
        _value1 = value1;
    }


    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T0" />.
    /// </summary>
    public bool IsT0 => Index == 0;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T0" />.
    /// </summary>
    /// <returns>Returns <c>default(T0)</c> if the union does not store this type.</returns>
    public T0? AsT0 =>
        IsT0 ? _value0 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T1" />.
    /// </summary>
    public bool IsT1 => Index == 1;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T1" />.
    /// </summary>
    /// <returns>Returns <c>default(T1)</c> if the union does not store this type.</returns>
    public T1? AsT1 =>
        IsT1 ? _value1 : default;


    /// <inheritdoc />
    public object Value =>
        Index switch
        {
            0 when _value0 is not null => _value0,
            1 when _value1 is not null => _value1,
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };


    /// <inheritdoc />
    public int Index { get; }


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1>(T0 value) =>
        new(0, value0: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1>(T1 value) =>
        new(1, value1: GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T0(OneOf<T0, T1> value) =>
        value is { Index: 0, _value0: not null } ? value._value0 : ThrowInvalidCastException<T0>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T1(OneOf<T0, T1> value) =>
        value is { Index: 1, _value1: not null } ? value._value1 : ThrowInvalidCastException<T1>();


    public static bool operator ==(OneOf<T0, T1> left, OneOf<T0, T1> right)
        => left.Equals(right);

    public static bool operator !=(OneOf<T0, T1> left, OneOf<T0, T1> right)
        => !left.Equals(right);
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    public void Switch
    (
        Action<T0> f0,
        Action<T1> f1
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);

        switch (Index)
        {
            case 0 when _value0 is not null:
            {
                f0(_value0);

                break;
            }
            case 1 when _value1 is not null:
            {
                f1(_value1);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    public Task SwitchAsync
    (
        Func<T0, Task> f0,
        Func<T1, Task> f1
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public TResult Match<TResult>
    (
        Func<T0, TResult> f0,
        Func<T1, TResult> f1
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<T0, Task<TResult>> f0,
        Func<T1, Task<TResult>> f1
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <returns>
    ///     Calls <see cref="ToString" /> of the type that stores the union.
    /// </returns>
    [Pure]
    public override string ToString() =>
        Index switch
        {
            0     => FormatValue(_value0),
            1     => FormatValue(_value1),
            var _ => string.Empty
        };


    /// <inheritdoc />
    public bool Equals(OneOf<T0, T1>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Index == other.Index && Index switch
        {
            0     => Equals(_value0, other._value0),
            1     => Equals(_value1, other._value1),
            var _ => false
        };
    }


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj is OneOf<T0, T1> oneOfObj && Equals(oneOfObj);
    }


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(Index, Value);
}


/// <summary>
///     Represents a type-union that can contain only one of the values.
/// </summary>
/// <typeparam name="T0">Possible state type.</typeparam>
/// <typeparam name="T1">Possible state type.</typeparam>
/// <typeparam name="T2">Possible state type.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public class OneOf<T0, T1, T2> : IOneOf, IEquatable<OneOf<T0, T1, T2>>
    where T0: notnull
    where T1: notnull
    where T2: notnull
{
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;

    private OneOf
    (
        int index,
        T0? value0 = default,
        T1? value1 = default,
        T2? value2 = default
    )
    {
        Index = index;
        _value0 = value0;
        _value1 = value1;
        _value2 = value2;
    }


    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T0" />.
    /// </summary>
    public bool IsT0 => Index == 0;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T0" />.
    /// </summary>
    /// <returns>Returns <c>default(T0)</c> if the union does not store this type.</returns>
    public T0? AsT0 =>
        IsT0 ? _value0 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T1" />.
    /// </summary>
    public bool IsT1 => Index == 1;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T1" />.
    /// </summary>
    /// <returns>Returns <c>default(T1)</c> if the union does not store this type.</returns>
    public T1? AsT1 =>
        IsT1 ? _value1 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T2" />.
    /// </summary>
    public bool IsT2 => Index == 2;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T2" />.
    /// </summary>
    /// <returns>Returns <c>default(T2)</c> if the union does not store this type.</returns>
    public T2? AsT2 =>
        IsT2 ? _value2 : default;


    /// <inheritdoc />
    public object Value =>
        Index switch
        {
            0 when _value0 is not null => _value0,
            1 when _value1 is not null => _value1,
            2 when _value2 is not null => _value2,
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };


    /// <inheritdoc />
    public int Index { get; }


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2>(T0 value) =>
        new(0, value0: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2>(T1 value) =>
        new(1, value1: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2>(T2 value) =>
        new(2, value2: GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T0(OneOf<T0, T1, T2> value) =>
        value is { Index: 0, _value0: not null } ? value._value0 : ThrowInvalidCastException<T0>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T1(OneOf<T0, T1, T2> value) =>
        value is { Index: 1, _value1: not null } ? value._value1 : ThrowInvalidCastException<T1>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T2(OneOf<T0, T1, T2> value) =>
        value is { Index: 2, _value2: not null } ? value._value2 : ThrowInvalidCastException<T2>();


    public static bool operator ==(OneOf<T0, T1, T2> left, OneOf<T0, T1, T2> right)
        => left.Equals(right);

    public static bool operator !=(OneOf<T0, T1, T2> left, OneOf<T0, T1, T2> right)
        => !left.Equals(right);
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    public void Switch
    (
        Action<T0> f0,
        Action<T1> f1,
        Action<T2> f2
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);

        switch (Index)
        {
            case 0 when _value0 is not null:
            {
                f0(_value0);

                break;
            }
            case 1 when _value1 is not null:
            {
                f1(_value1);

                break;
            }
            case 2 when _value2 is not null:
            {
                f2(_value2);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    public Task SwitchAsync
    (
        Func<T0, Task> f0,
        Func<T1, Task> f1,
        Func<T2, Task> f2
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public TResult Match<TResult>
    (
        Func<T0, TResult> f0,
        Func<T1, TResult> f1,
        Func<T2, TResult> f2
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<T0, Task<TResult>> f0,
        Func<T1, Task<TResult>> f1,
        Func<T2, Task<TResult>> f2
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <returns>
    ///     Calls <see cref="ToString" /> of the type that stores the union.
    /// </returns>
    [Pure]
    public override string ToString() =>
        Index switch
        {
            0     => FormatValue(_value0),
            1     => FormatValue(_value1),
            2     => FormatValue(_value2),
            var _ => string.Empty
        };


    /// <inheritdoc />
    public bool Equals(OneOf<T0, T1, T2>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Index == other.Index && Index switch
        {
            0     => Equals(_value0, other._value0),
            1     => Equals(_value1, other._value1),
            2     => Equals(_value2, other._value2),
            var _ => false
        };
    }


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj is OneOf<T0, T1, T2> oneOfObj && Equals(oneOfObj);
    }


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(Index, Value);
}


/// <summary>
///     Represents a type-union that can contain only one of the values.
/// </summary>
/// <typeparam name="T0">Possible state type.</typeparam>
/// <typeparam name="T1">Possible state type.</typeparam>
/// <typeparam name="T2">Possible state type.</typeparam>
/// <typeparam name="T3">Possible state type.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public class OneOf<T0, T1, T2, T3> : IOneOf, IEquatable<OneOf<T0, T1, T2, T3>>
    where T0: notnull
    where T1: notnull
    where T2: notnull
    where T3: notnull
{
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;
    private readonly T3? _value3;

    private OneOf
    (
        int index,
        T0? value0 = default,
        T1? value1 = default,
        T2? value2 = default,
        T3? value3 = default
    )
    {
        Index = index;
        _value0 = value0;
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
    }


    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T0" />.
    /// </summary>
    public bool IsT0 => Index == 0;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T0" />.
    /// </summary>
    /// <returns>Returns <c>default(T0)</c> if the union does not store this type.</returns>
    public T0? AsT0 =>
        IsT0 ? _value0 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T1" />.
    /// </summary>
    public bool IsT1 => Index == 1;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T1" />.
    /// </summary>
    /// <returns>Returns <c>default(T1)</c> if the union does not store this type.</returns>
    public T1? AsT1 =>
        IsT1 ? _value1 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T2" />.
    /// </summary>
    public bool IsT2 => Index == 2;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T2" />.
    /// </summary>
    /// <returns>Returns <c>default(T2)</c> if the union does not store this type.</returns>
    public T2? AsT2 =>
        IsT2 ? _value2 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T3" />.
    /// </summary>
    public bool IsT3 => Index == 3;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T3" />.
    /// </summary>
    /// <returns>Returns <c>default(T3)</c> if the union does not store this type.</returns>
    public T3? AsT3 =>
        IsT3 ? _value3 : default;


    /// <inheritdoc />
    public object Value =>
        Index switch
        {
            0 when _value0 is not null => _value0,
            1 when _value1 is not null => _value1,
            2 when _value2 is not null => _value2,
            3 when _value3 is not null => _value3,
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };


    /// <inheritdoc />
    public int Index { get; }


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3>(T0 value) =>
        new(0, value0: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3>(T1 value) =>
        new(1, value1: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3>(T2 value) =>
        new(2, value2: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3>(T3 value) =>
        new(3, value3: GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T0(OneOf<T0, T1, T2, T3> value) =>
        value is { Index: 0, _value0: not null } ? value._value0 : ThrowInvalidCastException<T0>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T1(OneOf<T0, T1, T2, T3> value) =>
        value is { Index: 1, _value1: not null } ? value._value1 : ThrowInvalidCastException<T1>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T2(OneOf<T0, T1, T2, T3> value) =>
        value is { Index: 2, _value2: not null } ? value._value2 : ThrowInvalidCastException<T2>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T3(OneOf<T0, T1, T2, T3> value) =>
        value is { Index: 3, _value3: not null } ? value._value3 : ThrowInvalidCastException<T3>();


    public static bool operator ==(OneOf<T0, T1, T2, T3> left, OneOf<T0, T1, T2, T3> right)
        => left.Equals(right);

    public static bool operator !=(OneOf<T0, T1, T2, T3> left, OneOf<T0, T1, T2, T3> right)
        => !left.Equals(right);
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    public void Switch
    (
        Action<T0> f0,
        Action<T1> f1,
        Action<T2> f2,
        Action<T3> f3
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);

        switch (Index)
        {
            case 0 when _value0 is not null:
            {
                f0(_value0);

                break;
            }
            case 1 when _value1 is not null:
            {
                f1(_value1);

                break;
            }
            case 2 when _value2 is not null:
            {
                f2(_value2);

                break;
            }
            case 3 when _value3 is not null:
            {
                f3(_value3);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    public Task SwitchAsync
    (
        Func<T0, Task> f0,
        Func<T1, Task> f1,
        Func<T2, Task> f2,
        Func<T3, Task> f3
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public TResult Match<TResult>
    (
        Func<T0, TResult> f0,
        Func<T1, TResult> f1,
        Func<T2, TResult> f2,
        Func<T3, TResult> f3
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<T0, Task<TResult>> f0,
        Func<T1, Task<TResult>> f1,
        Func<T2, Task<TResult>> f2,
        Func<T3, Task<TResult>> f3
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <returns>
    ///     Calls <see cref="ToString" /> of the type that stores the union.
    /// </returns>
    [Pure]
    public override string ToString() =>
        Index switch
        {
            0     => FormatValue(_value0),
            1     => FormatValue(_value1),
            2     => FormatValue(_value2),
            3     => FormatValue(_value3),
            var _ => string.Empty
        };


    /// <inheritdoc />
    public bool Equals(OneOf<T0, T1, T2, T3>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Index == other.Index && Index switch
        {
            0     => Equals(_value0, other._value0),
            1     => Equals(_value1, other._value1),
            2     => Equals(_value2, other._value2),
            3     => Equals(_value3, other._value3),
            var _ => false
        };
    }


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj is OneOf<T0, T1, T2, T3> oneOfObj && Equals(oneOfObj);
    }


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(Index, Value);
}


/// <summary>
///     Represents a type-union that can contain only one of the values.
/// </summary>
/// <typeparam name="T0">Possible state type.</typeparam>
/// <typeparam name="T1">Possible state type.</typeparam>
/// <typeparam name="T2">Possible state type.</typeparam>
/// <typeparam name="T3">Possible state type.</typeparam>
/// <typeparam name="T4">Possible state type.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public class OneOf<T0, T1, T2, T3, T4> : IOneOf, IEquatable<OneOf<T0, T1, T2, T3, T4>>
    where T0: notnull
    where T1: notnull
    where T2: notnull
    where T3: notnull
    where T4: notnull
{
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;
    private readonly T3? _value3;
    private readonly T4? _value4;

    private OneOf
    (
        int index,
        T0? value0 = default,
        T1? value1 = default,
        T2? value2 = default,
        T3? value3 = default,
        T4? value4 = default
    )
    {
        Index = index;
        _value0 = value0;
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
    }


    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T0" />.
    /// </summary>
    public bool IsT0 => Index == 0;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T0" />.
    /// </summary>
    /// <returns>Returns <c>default(T0)</c> if the union does not store this type.</returns>
    public T0? AsT0 =>
        IsT0 ? _value0 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T1" />.
    /// </summary>
    public bool IsT1 => Index == 1;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T1" />.
    /// </summary>
    /// <returns>Returns <c>default(T1)</c> if the union does not store this type.</returns>
    public T1? AsT1 =>
        IsT1 ? _value1 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T2" />.
    /// </summary>
    public bool IsT2 => Index == 2;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T2" />.
    /// </summary>
    /// <returns>Returns <c>default(T2)</c> if the union does not store this type.</returns>
    public T2? AsT2 =>
        IsT2 ? _value2 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T3" />.
    /// </summary>
    public bool IsT3 => Index == 3;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T3" />.
    /// </summary>
    /// <returns>Returns <c>default(T3)</c> if the union does not store this type.</returns>
    public T3? AsT3 =>
        IsT3 ? _value3 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T4" />.
    /// </summary>
    public bool IsT4 => Index == 4;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T4" />.
    /// </summary>
    /// <returns>Returns <c>default(T4)</c> if the union does not store this type.</returns>
    public T4? AsT4 =>
        IsT4 ? _value4 : default;


    /// <inheritdoc />
    public object Value =>
        Index switch
        {
            0 when _value0 is not null => _value0,
            1 when _value1 is not null => _value1,
            2 when _value2 is not null => _value2,
            3 when _value3 is not null => _value3,
            4 when _value4 is not null => _value4,
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };


    /// <inheritdoc />
    public int Index { get; }


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4>(T0 value) =>
        new(0, value0: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4>(T1 value) =>
        new(1, value1: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4>(T2 value) =>
        new(2, value2: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4>(T3 value) =>
        new(3, value3: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4>(T4 value) =>
        new(4, value4: GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T0(OneOf<T0, T1, T2, T3, T4> value) =>
        value is { Index: 0, _value0: not null } ? value._value0 : ThrowInvalidCastException<T0>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T1(OneOf<T0, T1, T2, T3, T4> value) =>
        value is { Index: 1, _value1: not null } ? value._value1 : ThrowInvalidCastException<T1>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T2(OneOf<T0, T1, T2, T3, T4> value) =>
        value is { Index: 2, _value2: not null } ? value._value2 : ThrowInvalidCastException<T2>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T3(OneOf<T0, T1, T2, T3, T4> value) =>
        value is { Index: 3, _value3: not null } ? value._value3 : ThrowInvalidCastException<T3>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T4(OneOf<T0, T1, T2, T3, T4> value) =>
        value is { Index: 4, _value4: not null } ? value._value4 : ThrowInvalidCastException<T4>();


    public static bool operator ==(OneOf<T0, T1, T2, T3, T4> left, OneOf<T0, T1, T2, T3, T4> right)
        => left.Equals(right);

    public static bool operator !=(OneOf<T0, T1, T2, T3, T4> left, OneOf<T0, T1, T2, T3, T4> right)
        => !left.Equals(right);
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    /// <param name="f4">Action that will be executed in case of this state.</param>
    public void Switch
    (
        Action<T0> f0,
        Action<T1> f1,
        Action<T2> f2,
        Action<T3> f3,
        Action<T4> f4
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);

        switch (Index)
        {
            case 0 when _value0 is not null:
            {
                f0(_value0);

                break;
            }
            case 1 when _value1 is not null:
            {
                f1(_value1);

                break;
            }
            case 2 when _value2 is not null:
            {
                f2(_value2);

                break;
            }
            case 3 when _value3 is not null:
            {
                f3(_value3);

                break;
            }
            case 4 when _value4 is not null:
            {
                f4(_value4);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    /// <param name="f4">Action that will be executed in case of this state.</param>
    public Task SwitchAsync
    (
        Func<T0, Task> f0,
        Func<T1, Task> f1,
        Func<T2, Task> f2,
        Func<T3, Task> f3,
        Func<T4, Task> f4
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <param name="f4">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public TResult Match<TResult>
    (
        Func<T0, TResult> f0,
        Func<T1, TResult> f1,
        Func<T2, TResult> f2,
        Func<T3, TResult> f3,
        Func<T4, TResult> f4
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <param name="f4">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<T0, Task<TResult>> f0,
        Func<T1, Task<TResult>> f1,
        Func<T2, Task<TResult>> f2,
        Func<T3, Task<TResult>> f3,
        Func<T4, Task<TResult>> f4
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <returns>
    ///     Calls <see cref="ToString" /> of the type that stores the union.
    /// </returns>
    [Pure]
    public override string ToString() =>
        Index switch
        {
            0     => FormatValue(_value0),
            1     => FormatValue(_value1),
            2     => FormatValue(_value2),
            3     => FormatValue(_value3),
            4     => FormatValue(_value4),
            var _ => string.Empty
        };


    /// <inheritdoc />
    public bool Equals(OneOf<T0, T1, T2, T3, T4>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Index == other.Index && Index switch
        {
            0     => Equals(_value0, other._value0),
            1     => Equals(_value1, other._value1),
            2     => Equals(_value2, other._value2),
            3     => Equals(_value3, other._value3),
            4     => Equals(_value4, other._value4),
            var _ => false
        };
    }


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj is OneOf<T0, T1, T2, T3, T4> oneOfObj && Equals(oneOfObj);
    }


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(Index, Value);
}


/// <summary>
///     Represents a type-union that can contain only one of the values.
/// </summary>
/// <typeparam name="T0">Possible state type.</typeparam>
/// <typeparam name="T1">Possible state type.</typeparam>
/// <typeparam name="T2">Possible state type.</typeparam>
/// <typeparam name="T3">Possible state type.</typeparam>
/// <typeparam name="T4">Possible state type.</typeparam>
/// <typeparam name="T5">Possible state type.</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public class OneOf<T0, T1, T2, T3, T4, T5> : IOneOf, IEquatable<OneOf<T0, T1, T2, T3, T4, T5>>
    where T0: notnull
    where T1: notnull
    where T2: notnull
    where T3: notnull
    where T4: notnull
    where T5: notnull
{
    private readonly T0? _value0;
    private readonly T1? _value1;
    private readonly T2? _value2;
    private readonly T3? _value3;
    private readonly T4? _value4;
    private readonly T5? _value5;

    private OneOf
    (
        int index,
        T0? value0 = default,
        T1? value1 = default,
        T2? value2 = default,
        T3? value3 = default,
        T4? value4 = default,
        T5? value5 = default
    )
    {
        Index = index;
        _value0 = value0;
        _value1 = value1;
        _value2 = value2;
        _value3 = value3;
        _value4 = value4;
        _value5 = value5;
    }


    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T0" />.
    /// </summary>
    public bool IsT0 => Index == 0;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T0" />.
    /// </summary>
    /// <returns>Returns <c>default(T0)</c> if the union does not store this type.</returns>
    public T0? AsT0 =>
        IsT0 ? _value0 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T1" />.
    /// </summary>
    public bool IsT1 => Index == 1;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T1" />.
    /// </summary>
    /// <returns>Returns <c>default(T1)</c> if the union does not store this type.</returns>
    public T1? AsT1 =>
        IsT1 ? _value1 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T2" />.
    /// </summary>
    public bool IsT2 => Index == 2;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T2" />.
    /// </summary>
    /// <returns>Returns <c>default(T2)</c> if the union does not store this type.</returns>
    public T2? AsT2 =>
        IsT2 ? _value2 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T3" />.
    /// </summary>
    public bool IsT3 => Index == 3;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T3" />.
    /// </summary>
    /// <returns>Returns <c>default(T3)</c> if the union does not store this type.</returns>
    public T3? AsT3 =>
        IsT3 ? _value3 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T4" />.
    /// </summary>
    public bool IsT4 => Index == 4;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T4" />.
    /// </summary>
    /// <returns>Returns <c>default(T4)</c> if the union does not store this type.</returns>
    public T4? AsT4 =>
        IsT4 ? _value4 : default;

    /// <summary>
    ///     Checks if the current union state is of type <typeparamref name="T5" />.
    /// </summary>
    public bool IsT5 => Index == 5;

    /// <summary>
    ///     Trying to cast to type <typeparamref name="T5" />.
    /// </summary>
    /// <returns>Returns <c>default(T5)</c> if the union does not store this type.</returns>
    public T5? AsT5 =>
        IsT5 ? _value5 : default;


    /// <inheritdoc />
    public object Value =>
        Index switch
        {
            0 when _value0 is not null => _value0,
            1 when _value1 is not null => _value1,
            2 when _value2 is not null => _value2,
            3 when _value3 is not null => _value3,
            4 when _value4 is not null => _value4,
            5 when _value5 is not null => _value5,
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };


    /// <inheritdoc />
    public int Index { get; }


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T0 value) =>
        new(0, value0: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T1 value) =>
        new(1, value1: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T2 value) =>
        new(2, value2: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T3 value) =>
        new(3, value3: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T4 value) =>
        new(4, value4: GetValueOrThrowInvalidCastExceptionIfNull(value));

    /// <exception cref="InvalidCastException">if <paramref name="value" /> is null.</exception>
    public static implicit operator OneOf<T0, T1, T2, T3, T4, T5>(T5 value) =>
        new(5, value5: GetValueOrThrowInvalidCastExceptionIfNull(value));


    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T0(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 0, _value0: not null } ? value._value0 : ThrowInvalidCastException<T0>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T1(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 1, _value1: not null } ? value._value1 : ThrowInvalidCastException<T1>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T2(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 2, _value2: not null } ? value._value2 : ThrowInvalidCastException<T2>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T3(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 3, _value3: not null } ? value._value3 : ThrowInvalidCastException<T3>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T4(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 4, _value4: not null } ? value._value4 : ThrowInvalidCastException<T4>();

    /// <exception cref="InvalidCastException">if the union does not currently store the given type.</exception>
    public static explicit operator T5(OneOf<T0, T1, T2, T3, T4, T5> value) =>
        value is { Index: 5, _value5: not null } ? value._value5 : ThrowInvalidCastException<T5>();


    public static bool operator ==(OneOf<T0, T1, T2, T3, T4, T5> left, OneOf<T0, T1, T2, T3, T4, T5> right)
        => left.Equals(right);

    public static bool operator !=(OneOf<T0, T1, T2, T3, T4, T5> left, OneOf<T0, T1, T2, T3, T4, T5> right)
        => !left.Equals(right);
    #endregion _Operators


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    /// <param name="f4">Action that will be executed in case of this state.</param>
    /// <param name="f5">Action that will be executed in case of this state.</param>
    public void Switch
    (
        Action<T0> f0,
        Action<T1> f1,
        Action<T2> f2,
        Action<T3> f3,
        Action<T4> f4,
        Action<T5> f5
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);
        ThrowIfNull(f5);

        switch (Index)
        {
            case 0 when _value0 is not null:
            {
                f0(_value0);

                break;
            }
            case 1 when _value1 is not null:
            {
                f1(_value1);

                break;
            }
            case 2 when _value2 is not null:
            {
                f2(_value2);

                break;
            }
            case 3 when _value3 is not null:
            {
                f3(_value3);

                break;
            }
            case 4 when _value4 is not null:
            {
                f4(_value4);

                break;
            }
            case 5 when _value5 is not null:
            {
                f5(_value5);

                break;
            }
            default: throw new InvalidOperationException(CorruptedMessage);
        }
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Action that will be executed in case of this state.</param>
    /// <param name="f1">Action that will be executed in case of this state.</param>
    /// <param name="f2">Action that will be executed in case of this state.</param>
    /// <param name="f3">Action that will be executed in case of this state.</param>
    /// <param name="f4">Action that will be executed in case of this state.</param>
    /// <param name="f5">Action that will be executed in case of this state.</param>
    public Task SwitchAsync
    (
        Func<T0, Task> f0,
        Func<T1, Task> f1,
        Func<T2, Task> f2,
        Func<T3, Task> f3,
        Func<T4, Task> f4,
        Func<T5, Task> f5
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);
        ThrowIfNull(f5);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            5 when _value5 is not null => f5(_value5),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <param name="f4">Function that will be executed in case of this state.</param>
    /// <param name="f5">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public TResult Match<TResult>
    (
        Func<T0, TResult> f0,
        Func<T1, TResult> f1,
        Func<T2, TResult> f2,
        Func<T3, TResult> f3,
        Func<T4, TResult> f4,
        Func<T5, TResult> f5
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);
        ThrowIfNull(f5);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            5 when _value5 is not null => f5(_value5),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <summary>
    ///     Executes one of the provided delegates, depending on the current state.
    /// </summary>
    /// <remarks>Asynchronous version.</remarks>
    /// <param name="f0">Function that will be executed in case of this state.</param>
    /// <param name="f1">Function that will be executed in case of this state.</param>
    /// <param name="f2">Function that will be executed in case of this state.</param>
    /// <param name="f3">Function that will be executed in case of this state.</param>
    /// <param name="f4">Function that will be executed in case of this state.</param>
    /// <param name="f5">Function that will be executed in case of this state.</param>
    /// <typeparam name="TResult">Type of returning result.</typeparam>
    /// <returns>The result of one of the delegates.</returns>
    [Pure]
    public Task<TResult> MatchAsync<TResult>
    (
        Func<T0, Task<TResult>> f0,
        Func<T1, Task<TResult>> f1,
        Func<T2, Task<TResult>> f2,
        Func<T3, Task<TResult>> f3,
        Func<T4, Task<TResult>> f4,
        Func<T5, Task<TResult>> f5
    )
    {
        ThrowIfNull(f0);
        ThrowIfNull(f1);
        ThrowIfNull(f2);
        ThrowIfNull(f3);
        ThrowIfNull(f4);
        ThrowIfNull(f5);

        return Index switch
        {
            0 when _value0 is not null => f0(_value0),
            1 when _value1 is not null => f1(_value1),
            2 when _value2 is not null => f2(_value2),
            3 when _value3 is not null => f3(_value3),
            4 when _value4 is not null => f4(_value4),
            5 when _value5 is not null => f5(_value5),
            var _                      => throw new InvalidOperationException(CorruptedMessage)
        };
    }


    /// <returns>
    ///     Calls <see cref="ToString" /> of the type that stores the union.
    /// </returns>
    [Pure]
    public override string ToString() =>
        Index switch
        {
            0     => FormatValue(_value0),
            1     => FormatValue(_value1),
            2     => FormatValue(_value2),
            3     => FormatValue(_value3),
            4     => FormatValue(_value4),
            5     => FormatValue(_value5),
            var _ => string.Empty
        };


    /// <inheritdoc />
    public bool Equals(OneOf<T0, T1, T2, T3, T4, T5>? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Index == other.Index && Index switch
        {
            0     => Equals(_value0, other._value0),
            1     => Equals(_value1, other._value1),
            2     => Equals(_value2, other._value2),
            3     => Equals(_value3, other._value3),
            4     => Equals(_value4, other._value4),
            5     => Equals(_value5, other._value5),
            var _ => false
        };
    }


    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        return obj is OneOf<T0, T1, T2, T3, T4, T5> oneOfObj && Equals(oneOfObj);
    }


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(Index, Value);
}


