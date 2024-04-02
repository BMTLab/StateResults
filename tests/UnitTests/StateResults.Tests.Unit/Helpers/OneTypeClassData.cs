using System.Collections;

#pragma warning disable CA1812 // Class is never instantiated.
namespace BMTLab.StateResults.Tests.Units;

[UsedImplicitly]
internal sealed class OneTypeClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return ["some value"];
        yield return [0];
        yield return [true];
        yield return [new object()];
        yield return [new ArgumentException("some exception")];
        yield return [new SomeStructType()];
        yield return [new SomeClassError()];
        yield return [new SomeRecordType()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}


[UsedImplicitly]
internal sealed class TwoTypesClassData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return [new SomeStructType("Test"), new SomeStructType2("Test")];
        yield return [new SomeClassError(), new SomeClassError2()];
        yield return [new SomeRecordType("Test"), new SomeRecordType2("Test")];
        yield return [new SomeRecordType(), new SomeStructType()];
        yield return [new SomeClassError(), new SomeRecordType()];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}