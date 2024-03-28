namespace BMTLab.OneOf.Reduced.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
[ExcludeFromCodeCoverage]
internal static class Functions
{
    [Pure]
    internal static string FormatValue<T>(in T? value) => value?.ToString() ?? string.Empty;
}