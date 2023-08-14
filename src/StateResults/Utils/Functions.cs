namespace BMTLab.OneOf.Reduced.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class Functions
{
    internal static string FormatValue<T>(T value, bool isSuccess = true)
    {
        #if NET7_0_OR_GREATER
        return $$"""{ {{nameof(IOneOf.Value)}} = {{value}}, IsSuccess == {{isSuccess}} }""";
        #else
        return "{ " + $"{nameof(IOneOf.Value)} = {value}, IsSuccess = {isSuccess}" + " }";
        #endif
    }
}