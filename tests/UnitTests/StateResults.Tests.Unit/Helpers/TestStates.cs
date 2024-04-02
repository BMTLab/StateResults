// ReSharper disable All
#pragma warning disable CS9113 // Parameter is unread.
namespace BMTLab.StateResults.Tests.Units.Helpers;

internal static class TestStates
{
    internal readonly record struct SomeStructType(string? Message = default);
    internal readonly record struct SomeStructType2(string? Message = default);
    internal sealed class SomeClassError(string? Message = default);
    internal sealed class SomeClassError2(string? Message = default);
    internal sealed record SomeRecordType(string? Message = default);
    internal sealed record SomeRecordType2(string? Message = default);
}