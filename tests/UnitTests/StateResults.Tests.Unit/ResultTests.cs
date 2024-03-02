using BMTLab.OneOf.Reduced;

namespace BMTLab.StateResults.Tests.Units;

public class ResultTests
{
    [Fact]
    public void Result_Should_InitializeWithSuccessValue()
    {
        //// Arrange & Act
        var result = new Result<string>("success");

        //// Assert
        result.IsSuccess.Should().BeTrue();
        result.IsError.Should().BeFalse();
        result.Value.Should().Be("success");
    }


    [Fact]
    public void Result_Should_InitializeWithErrorValue()
    {
        //// Arrange & Act
        var result = new Result<string>("error", false);

        //// Assert
        result.IsSuccess.Should().BeFalse();
        result.IsError.Should().BeTrue();
        result.Value.Should().Be("error");
    }


    [Fact]
    public void Result_ShouldBeEqual_WhenInitializedWithSameValue()
    {
        //// Arrange
        var result1 = new Result<string>("testValue");
        var result2 = new Result<string>("testValue");

        //// Act && Assert
        result1.Should().BeEquivalentTo(result2);
    }


    [Fact]
    public void IOneOfValue_ShouldReturnCorrectValue()
    {
        //// Arrange
        var testValue = new object();
        var result = new Result<object>(testValue);

        //// Act
        var oneOfValue = ((IOneOf) result).Value;

        //// Assert
        oneOfValue.Should().Be(testValue);
    }


    [Fact]
    public void Index_ShouldAlwaysReturnZero()
    {
        //// Arrange
        var result = new Result<string>("testValue");

        //// Act && Assert
        result.Index.Should().Be(0);
    }


    [Fact]
    public void ImplicitOperator_Should_SetIsSuccessToDefault()
    {
        //// Arrange & Act
        Result<string> result = "some value";

        //// Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("some value");
    }


    [Fact]
    public void ExplicitOperator_Should_ReturnValue()
    {
        //// Arrange
        var result = new Result<string>("some value");

        //// Act
        var value = (string) result;

        //// Assert
        value.Should().Be("some value");
    }


    [Fact]
    public void TrueOperator_Should_ReturnTrueIfSuccess()
    {
        //// Arrange
        var result = new Result<string>("some value");

        if (result)
            // Assertion inside condition to ensure it's executed.
            result.IsSuccess.Should().BeTrue();
        else
            Assert.Fail("Result should be successful");
    }


    [Fact]
    public void FalseOperator_Should_ReturnTrueIfError()
    {
        //// Arrange
        var result = new Result<string>("some value", false);

        if (result)
            Assert.Fail("Result should be an error");
        else
            // Assertion inside condition to ensure it's executed.
            result.IsError.Should().BeTrue();
    }


    [Fact]
    public void ToString_Should_ReturnCorrectFormatForSuccess()
    {
        //// Arrange
        var result = new Result<string>("success");

        //// Act
        var toString = result.ToString();

        //// Assert
        toString.Should()
                .Contain($"{nameof(Result<string>.IsSuccess)} = True").And
                .Contain($"{nameof(Result<string>.Value)} = success");
    }


    [Fact]
    public void ToString_Should_ReturnCorrectFormatForError()
    {
        //// Arrange
        var result = new Result<string>("error", false);

        //// Act
        var toString = result.ToString();

        //// Assert
        toString.Should()
                .Contain($"{nameof(Result<string>.IsSuccess)} = False").And
                .Contain($"{nameof(Result<string>.Value)} = error");
    }


    [Fact]
    public void GetHashCode_Should_ReturnDifferentHashCodesForDifferentValues()
    {
        //// Arrange
        var result1 = new Result<string>("value1");
        var result2 = new Result<string>("value2");

        //// Act
        var hashCode1 = result1.ToString();
        var hashCode2 = result2.ToString();

        //// Assert
        hashCode1.Should().NotBe(hashCode2);
    }


     #pragma warning disable CA1806
    [Fact]
    public void Result_ShouldThrow_ArgumentNullException_WhenValueIsValue()
    {
        //// Arrange
        Action act = () => new Result<string>(null!);

        //// Act && Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
     #pragma warning restore CA1806
}