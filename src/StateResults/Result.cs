#pragma warning disable CS1591
// Missing XML comment for publicly visible type or member

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BMTLab.StateResults;

/// <summary>
///     Aggregates the result of some operation into itself.
/// </summary>
/// <typeparam name="T">Type of result (successful or not).</typeparam>
[PublicAPI]
[DebuggerStepThrough]
[ExcludeFromCodeCoverage]
public readonly record struct Result<T> : IOneOf, IHasSuccessOrErrorResult
    where T : notnull
{
    /// <summary>
    ///     Initializes the result object with a certain state.
    /// </summary>
    /// <param name="value">Arbitrary result object.</param>
    /// <param name="isSuccess">Marks that the type contains a successful state.</param>
    /// <exception cref="ArgumentNullException"><paramref name="value" /> is <c>null</c>.</exception>
    public Result(in T value, bool isSuccess = true)
    {
        ThrowIfNull(value);

        Value = value;
        IsSuccess = isSuccess;
    }


    /// <summary>
    ///     Get the stored <typeparamref name="T" /> value.
    /// </summary>
    public T Value { get; }


    /// <inheritdoc />
    [DefaultValue(false)]
    public bool IsError => !IsSuccess;


    /// <inheritdoc />
    [DefaultValue(true)]
    public bool IsSuccess { get; init; } = true;


    /// <inheritdoc />
    object IOneOf.Value => Value;


    /// <inheritdoc />
    public int Index => 0;


    #region Operators
    /// <exception cref="InvalidCastException">if <paramref name="value" /> is <c>null</c>.</exception>
    public static implicit operator Result<T>(in T value) =>
        new(GetValueOrThrowInvalidCastExceptionIfNull(value), TryPredictIfSuccessType());

    /// <exception cref="InvalidCastException">if Value is <c>null</c>.</exception>
    public static implicit operator Result<T>(in (T Value, bool IsSuccess) tuple) =>
        new(GetValueOrThrowInvalidCastExceptionIfNull(tuple.Value), tuple.IsSuccess);

    public static explicit operator T(in Result<T> value) => value.Value;


    public static bool operator true(in Result<T> result) => result.IsSuccess;
    public static bool operator false(in Result<T> result) => result.IsError;
    #endregion _Operators


    /// <inheritdoc />
    /// <example>
    ///     <code>
    ///         { Value = Success { Message = custom msg }, IsSuccess = True }
    ///         { Value = InternalError { Message = custom msg, Exception = System.ArgumentException: inner exception msg }, IsSuccess = False }
    ///     </code>
    /// </example>
    [Pure]
    public override string ToString() =>
        FormatValue(Value, IsSuccess);


    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public override int GetHashCode() =>
        HashCode.Combine(IsSuccess.GetHashCode(), Value);


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool TryPredictIfSuccessType() =>
        !typeof(T).IsAssignableTo(typeof(IErrorStateMarker));
}