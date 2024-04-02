using BMTLab.OneOf.Reduced;

#pragma warning disable CS9113 // Parameter is unread.
namespace BMTLab.StateResults.Tests.Units;

// ReSharper disable All
file sealed class TE0(string? message = default);

file sealed class TE1(string? message = default);
// ReSharper restore All


public class Results3Tests
{
    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Results_InitializedWithSuccess_ShouldIndicateSuccess<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Results<T, TE0, TE1>(value);

        //// Assert
        result.IsSuccess.Should().BeTrue("the result was initialized with a success value");
        result.IsError.Should().BeFalse("a successful result should not be marked as an error");

        result.Success.Should().NotBeNull("a successful result should have a non-null Success property");
        result.Error.Should().BeNull("a successful result should not have an Error");

        result.Success.Should()
              .NotBeNull("the result was initialized with a success value")
              .And.BeOfType<T>("the result was initialized with a success type")
              .Subject.Should().Be(value, "the result was initialized with a this value");

        result.Value.Should()
              .NotBeNull("the result was initialized with a value")
              .And.BeOfType<T>("the result was initialized with a success type")
              .And.Be(value, "the result was initialized with a this value");

        result.Index.Should().Be(0, "success values should have an index of 0");
    }


    [Fact]
    public void Results_InitializedWithError0_ShouldIndicateError()
    {
        //// Arrange & Act
        var error = new TE0("Error");
        var result = new Results<SomeRecordType, TE0, TE1>(error);

        //// Assert
        result.IsSuccess.Should().BeFalse("the result was initialized with a error value");
        result.IsError.Should().BeTrue("a error result should not be marked as a success");

        result.Success.Should().BeNull("a error result should not have an Success");
        result.Error.Should().NotBeNull("a error result should have a non-null Error property");

        result.Error.Should()
              .NotBeNull("the result was initialized with a error value")
              .And.BeOfType<OneOf<TE0, TE1>>("the result was initialized with an error union type")
              .Subject.Value.Should().Be(error, "the result was initialized with a this value");

        result.Value.Should()
              .NotBeNull("the result was initialized with a value")
              .And.BeOfType<TE0>("the result was initialized with a success type")
              .And.Be(error, "the result was initialized with a this value");

        result.Index.Should().NotBe(0, "error values should not have an index of 0");
    }


    [Fact]
    public void Match_ShouldExecuteCorrectDelegate_BasedOnState()
    {
        //// Arrange
        Results<string, TE0, TE1> successResult = "Success";
        Results<string, TE0, TE1> error0Result = new TE0("Error0");
        Results<string, TE0, TE1> error1Result = new TE1("Error1");

        //// Act & Assert
        successResult.Match
        (
            success =>
            {
                success.Should().Be("Success", "the Match function should execute the success delegate when the result is a success");

                return true;
            },
            _ =>
            {
                Assert.Fail("Error delegate should not be executed for success result.");

                return false;
            }
        );

        error0Result.Match
        (
            _ =>
            {
                Assert.Fail("Success delegate should not be executed for error result.");

                return true;
            },
            error =>
            {
                error.Value.Should()
                     .BeOfType<TE0>("the Match function should execute the error delegate with the correct error type")
                     .And.BeSameAs(error0Result.Value, "the Match function should execute the error delegate with the correct error value");

                return false;
            }
        );

        error1Result.Match
        (
            _ =>
            {
                Assert.Fail("Success delegate should not be executed for error result.");

                return true;
            },
            error =>
            {
                error.Value.Should()
                     .BeOfType<TE1>("the Match function should execute the error delegate with the correct error type")
                     .And.BeSameAs(error1Result.Value, "the Match function should execute the error delegate with the correct error value");

                return false;
            }
        );
    }


    [Fact]
    public void Switch_ShouldExecuteCorrectAction_BasedOnState()
    {
        //// Arrange
        var successResult = new Results<string, TE0, TE1>("Success");
        var errorResult = new Results<string, TE0, TE1>(new TE0("Error"));

        //// Act & Assert
        successResult.Switch
        (
            success => success.Should().Be("Success", "the Switch function should execute the success action for successful results"),
            _ => Assert.Fail("Error delegate should not be executed for success result.")
        );

        errorResult.Switch
        (
            _ => Assert.Fail("Success delegate should not be executed for error result."),
            error =>
                error.Value.Should()
                     .BeOfType<TE0>("the Switch function should execute the error delegate with the correct error type")
                     .And.BeSameAs(errorResult.Value, "the Switch function should execute the error delegate with the correct error value")
        );
    }


    [Fact]
    public void ExplicitOperator_ShouldCastCorrectly_BasedOnState()
    {
        //// Arrange
        Results<string, TE0, TE1> successResult = "Success";

        //// Act
        var successFunction = () => (string) successResult;

        //// Assert
        successFunction.Should().NotThrow("explicit casting to the success type should be valid for success results");
    }


    [Fact]
    public void GetHashCode_ShouldBeConsistent_WhenSuccessType()
    {
        //// Arrange
        var result1 = new Results<string, TE0, TE1>("Value");
        var result2 = new Results<string, TE0, TE1>("Value");
        var result3 = new Results<string, TE0, TE1>("OtherValue");

        //// Act & Assert
        result1.GetHashCode().Should().Be(result2.GetHashCode(), "results initialized with the same value should have the same hash code");
        result1.GetHashCode().Should().NotBe(result3.GetHashCode(), "results initialized with the different values should have the different hash code");
    }


    [Fact]
    public void GetHashCode_ShouldBeConsistent_WhenErrorType()
    {
        //// Arrange
        var errorResult1 = new Results<string, TE0, TE1>(new TE0("Value"));
        var errorResult2 = new Results<string, TE0, TE1>(new TE0("OtherValue"));

        //// Act & Assert
        errorResult1.GetHashCode().Should().NotBe(errorResult2.GetHashCode(), "error results initialized with the same value should have the same hash code");
    }


    [Fact]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("Performance", "CA1806:Do not ignore method results")]
    public void Results_ShouldThrow_ArgumentNullException_WhenValueIsNull()
    {
        //// Arrange
        var successAction = () => new Results<string, TE0, TE1>((string) null!);
        var errorAction = () => new Results<string, TE0, TE1>((OneOf<TE0, TE1>) null!);

        //// Act & Assert
        successAction.Should().ThrowExactly<ArgumentNullException>("initializing a Results with a null success value is invalid");
        errorAction.Should().ThrowExactly<ArgumentNullException>("initializing a Results with a null error is invalid");
    }
}