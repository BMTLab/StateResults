using System.Runtime.CompilerServices;

namespace BMTLab.StateResults.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class ThrowHelper
{
    internal static void ThrowIfNull
    (
        object? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    ) =>
        ArgumentNullException.ThrowIfNull(argument, paramName);


    internal static void ThrowIfNullOrWhiteSpace
    (
        string? argument,
        [CallerArgumentExpression("argument")] string? paramName = null
    )
    {
        #if NET8_0_OR_GREATER
        ArgumentException.ThrowIfNullOrWhiteSpace(argument, paramName);
        #else

        if (argument is null)
            throw new ArgumentNullException(paramName, "Value cannot be null.");

        throw new ArgumentException("The value cannot be an empty string or composed entirely of whitespace.", paramName);
        #endif
    }
}