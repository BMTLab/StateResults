using System.Runtime.CompilerServices;

namespace BMTLab.StateResults.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class ThrowHelper
{
    internal const string CorruptedMessage = "Unexpected index, which indicates an problem with this package.";


    internal static void ThrowIfNull
    (
        in object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    ) =>
        ArgumentNullException.ThrowIfNull(argument, paramName);


    internal static void ThrowIfNullOrWhiteSpace
    (
        in string? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    )
    {
        #if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrWhiteSpace(argument, paramName);
        #else

        if (argument is null)
            throw new ArgumentNullException(paramName, "Value cannot be null.");

        if (string.IsNullOrWhiteSpace(argument))
            throw new ArgumentException
            (
                "The value cannot be an empty string or composed entirely of whitespace.",
                paramName
            );

        #endif
    }


    [DoesNotReturn]
    internal static T ThrowInvalidCastException<T>() =>
        throw new InvalidCastException($"This union does not currently store the given type: {typeof(T)}.");


    internal static T GetValueOrThrowInvalidCastExceptionIfNull<T>
    (
        in T? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    )
    {
        if (argument is not null)
            return argument;

        throw new InvalidCastException
        (
            $"Cannot convert an object of type {typeof(T)} because it is null.",
            new ArgumentNullException(paramName)
        );
    }
}