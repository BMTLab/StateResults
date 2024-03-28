namespace BMTLab.StateResults.Tests.Units.Helpers;

internal static class TestStates
{
    internal readonly record struct SomeStructType(string? Message = default);
    internal readonly record struct SomeStructType2(string? Message = default);
    internal class SomeClassError(string? Message = default);
    internal class SomeClassError2(string? Message = default);
    internal record SomeRecordType(string? Message = default);
    internal record SomeRecordType2(string? Message = default);
}