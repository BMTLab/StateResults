using BMTLab.OneOf.Reduced;

namespace BMTLab.StateResults.Tests.Units;

public sealed class ResultTests
{
    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Result_Should_InitializeWithSuccessValue<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Result<T>(value);

        //// Assert
        result.IsSuccess.Should().BeTrue("a result initialized with a value should be successful");
        result.IsError.Should().BeFalse("a result initialized with a value should not be an error");
        result.Value.Should().Be(value, "the value passed during initialization should be accessible");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Result_Should_InitializeWithErrorValue<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Result<T>(value, false);

        //// Assert
        result.IsSuccess.Should().BeFalse("a result initialized as an error should not be successful");
        result.IsError.Should().BeTrue("a result initialized as an error should indicate an error state");
        result.Value.Should().Be(value, "the error value passed during initialization should be accessible");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Result_ShouldBeEqual_WhenInitializedWithSameValue<T>(T value) where T : notnull
    {
        //// Arrange
        var result1 = new Result<T>(value);
        var result2 = new Result<T>(value);

        //// Act && Assert
        result1.Should().Be(result2, "results initialized with the same value should be considered equivalent");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void IOneOfValue_ShouldReturnCorrectValue<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value);

        //// Act
        var oneOfValue = ((IOneOf) result).Value;

        //// Assert
        oneOfValue.Should().Be(value, "the IOneOf interface should return the same value as the result");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Index_ShouldAlwaysReturnZero<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value);

        //// Act && Assert
        result.Index.Should().Be(0, "the index of a Result should always be 0 as it is not a discriminated union");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ImplicitOperator_Should_SetIsSuccessToDefault<T>(T value) where T : notnull
    {
        //// Arrange & Act
        Result<T> result = value;

        //// Assert
        result.IsSuccess.Should().BeTrue("an implicit conversion from a value should result in a successful Result");
        result.Value.Should().Be(value, "the implicit conversion should maintain the original value");
    }


    [Theory]
    [InlineData("testString", true)]
    [InlineData("errorString", false)]
    public void ImplicitOperator_FromTuple_ShouldCorrectlyInitializeResult(string value, bool isSuccess)
    {
        //// Arrange & Act
        Result<string> result = (value, isSuccess);

        //// Assert
        result.Value.Should().Be(value, "the value should match the input");
        result.IsSuccess.Should().Be(isSuccess, "the success state should match the input");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ExplicitOperator_Should_ReturnValue<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value);

        //// Act
        var unpacked = (T) result;

        //// Assert
        unpacked.Should().Be(value, "an explicit conversion from a Result should return the original value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void TrueOperator_Should_ReturnTrueIfSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value);

        if (result)
            // Assertion inside condition to ensure it's executed.
            result.IsSuccess.Should().BeTrue("the true operator should indicate success for a successful Result");
        else
            Assert.Fail("Result should be successful");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void FalseOperator_Should_ReturnTrueIfError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value, false);

        if (result)
            Assert.Fail("Result should be an error");
        else
            // Assertion inside condition to ensure it's executed.
            result.IsError.Should().BeTrue("the false operator should indicate an error for a Result initialized as an error");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ToString_Should_ReturnCorrectFormatForSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value);

        //// Act
        var toString = result.ToString();

        //// Assert
        toString.Should()
                .Contain($"{nameof(Result<string>.IsSuccess)} = True", "the ToString output for a successful Result should indicate success")
                .And.Contain($"{nameof(Result<string>.Value)} = {value}", "the ToString output should include the value for a successful Result");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ToString_Should_ReturnCorrectFormatForError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Result<T>(value, false);

        //// Act
        var toString = result.ToString();

        //// Assert
        toString.Should()
                .Contain($"{nameof(Result<string>.IsSuccess)} = False", "the ToString output for an error Result should indicate it's not successful")
                .And.Contain($"{nameof(Result<string>.Value)} = {value}", "the ToString output should include the value even for an error Result");
    }


    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCodes_WhenDifferentValues()
    {
        //// Arrange
        var result1 = new Result<string>("value1");
        var result2 = new Result<string>("value2");

        //// Act
        var hashCode1 = result1.GetHashCode();
        var hashCode2 = result2.GetHashCode();

        //// Assert
        hashCode1.Should().NotBe(hashCode2, "different Results should have different hash codes");
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHasCode_WhenSameValues()
    {
        //// Arrange
        var result1 = new Result<string>("value1");
        var result2 = new Result<string>("value1");

        //// Act
        var hashCode1 = result1.GetHashCode();
        var hashCode2 = result2.GetHashCode();

        //// Assert
        hashCode1.Should().Be(hashCode2, "same Results should have same hash codes");
    }


    [Fact]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("Performance", "CA1806:Do not ignore method results")]
    public void Result_ShouldThrow_ArgumentNullException_WhenValueIsNull()
    {
        //// Arrange
        var successAction = () => new Result<string>(null!);
        var errorAction = () => new Result<string>(null!, isSuccess: false);

        //// Act && Assert
        successAction.Should().ThrowExactly<ArgumentNullException>("initializing a Result with a null value should throw an ArgumentNullException");
        errorAction.Should().ThrowExactly<ArgumentNullException>("initializing a Result with a null value should throw an ArgumentNullException");
    }
}