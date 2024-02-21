namespace BMTLab.StateResults.Tests.Units;

public sealed class StopwatchTimestampProviderTests(ITestOutputHelper output)
{
    [Fact]
    public void Test_Success()
    {
        output.WriteLine("Success");

        Assert.True(true);
    }
}