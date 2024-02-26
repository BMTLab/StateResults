namespace BMTLab.StateResults.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class Functions
{
    [Pure]
    internal static string FormatValue<T>(in T value, bool isSuccess = true)
    {
        #if NET7_0_OR_GREATER
        return $$"""{ {{nameof(IOneOf.Value)}} = {{value}}, {{nameof(IHasSuccessOrErrorResult.IsSuccess)}} = {{isSuccess}} }""";
        #else
        return "{ " + $"{nameof(IOneOf.Value)} = {value}, {nameof(IHasSuccessOrErrorResult.IsSuccess)} = {isSuccess}" + " }";
        #endif
    }
}