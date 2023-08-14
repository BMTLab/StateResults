using System.Runtime.CompilerServices;

namespace BMTLab.OneOf.Reduced.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class ThrowHelper
{
    internal const string CorruptedMessage = "Unexpected index, which indicates an problem with this package.";


    internal static void ThrowIfNull
    (
        object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    ) =>
        ArgumentNullException.ThrowIfNull(argument, paramName);


    [DoesNotReturn]
    internal static T ThrowInvalidCastException<T>() =>
        throw new InvalidCastException($"This union does not currently store the given type: {typeof(T)}.");


    internal static T GetValueOrThrowInvalidCastExceptionIfNull<T>
    (
        T? argument,
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