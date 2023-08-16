﻿namespace BMTLab.OneOf.Reduced.Utils;

[DebuggerStepThrough]
[StackTraceHidden]
internal static class Functions
{
    internal static string FormatValue<T>(in T? value) => value?.ToString() ?? string.Empty;
}