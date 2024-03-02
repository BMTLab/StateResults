namespace BMTLab.StateResults.Tests.Units;

public class ResultsTests
{
    [Fact]
    public void Results_InitializedWithSuccess_ShouldIndicateSuccess()
    {
        //// Arrange & Act
        var result = new Results<string, Exception>("success");

        //// Assert
        result.IsSuccess.Should().BeTrue();
        result.IsError.Should().BeFalse();
        result.Success.Should().Be("success");
        result.Error.Should().BeNull();
        result.Index.Should().Be(0);
    }


    [Fact]
    public void Results_InitializedWithError_ShouldIndicateError()
    {
        //// Arrange & Act
        var exception = new ArgumentException("error");
        var result = new Results<string, Exception>(exception);

        //// Assert
        result.IsSuccess.Should().BeFalse();
        result.IsError.Should().BeTrue();
        result.Error.Should().Be(exception);
        result.Success.Should().BeNull();
    }


    [Fact]
    public void IOneOfValue_ShouldReturnCorrectValue_ForSuccess()
    {
        //// Arrange
        const int successValue = 42;
        var result = new Results<int, string>(successValue);

        //// Act && Assert
        result.Value.Should().Be(successValue);
        result.Index.Should().Be(0);
    }


    [Fact]
    public void IOneOfValue_ShouldReturnCorrectValue_ForError()
    {
        //// Arrange
        const string errorValue = "Error!";
        var result = new Results<int, string>(errorValue);

        //// Act && Assert
        result.Value.Should().Be(errorValue);
        result.Index.Should().Be(1);
    }


    [Fact]
    public void Match_ShouldExecuteSuccessFunction_WhenSuccess()
    {
        //// Arrange
        var result = new Results<string, object>("Success");

        //// Act & Assert
        result.Match(
            success =>
            {
                success.Should().Be("Success");

                return true;
            },
            error =>
            {
                Assert.Fail("Expected success, not error.");

                return false;
            });
    }


    [Fact]
    public void Match_ShouldExecuteErrorFunction_WhenError()
    {
        //// Arrange
        var result = new Results<object, string>("Error");

        //// Act & Assert
        result.Match(
            success =>
            {
                Assert.Fail("Expected error, not success.");

                return true;
            },
            error =>
            {
                error.Should().Be("Error");

                return false;
            });
    }


    [Fact]
    public void ImplicitConversion_FromSuccessValue_ShouldResultInSuccess()
    {
        //// Arrange & Act
        Results<string, byte> result = "Success";

        //// Assert
        result.IsSuccess.Should().BeTrue();
    }


    [Fact]
    public void ImplicitConversion_FromErrorValue_ShouldResultInError()
    {
        //// Arrange & Act
        Results<byte, string> result = "Error";

        //// Assert
        result.IsError.Should().BeTrue();
    }


    [Fact]
    public void ExplicitConversion_ToSuccessValue_WhenSuccess_ShouldReturnCorrectValue()
    {
        //// Arrange
        var result = new Results<string, byte>("Success");

        //// Act
        var success = (string) result;

        //// Assert
        success.Should().Be("Success");
    }


    [Fact]
    public void ExplicitConversion_ToErrorValue_WhenError_ShouldReturnCorrectValue()
    {
        //// Arrange
        var result = new Results<byte, string>(5);

        //// Act
        var error = (byte) result;

        //// Assert
        error.Should().Be(5);
    }
}
