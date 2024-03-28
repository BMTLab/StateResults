namespace BMTLab.StateResults.Tests.Units;

public sealed class Results2Tests
{
    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Results_InitializedWithSuccess_ShouldIndicateSuccess<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Results<T, Exception>(value);

        //// Assert
        result.IsSuccess.Should().BeTrue("the result was initialized with a success value");
        result.IsError.Should().BeFalse("the result was initialized with a success value, not an error");
        result.Success.Should().Be(value, "a success value was provided during initialization");
        result.Error.Should().BeNull("no error value was provided during initialization");
        result.Index.Should().Be(0, "success value should have an index of 0");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Results_InitializedWithError_ShouldIndicateError<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Results<Exception, T>(value);

        //// Assert
        result.IsSuccess.Should().BeFalse("the result was initialized with an error value");
        result.IsError.Should().BeTrue("the result was initialized with an error value");
        result.Error.Should().Be(value, "an error value was provided during initialization");
        result.Success.Should().BeNull("no success value was provided during initialization");
        result.Index.Should().Be(1, "error value should have an index of 1");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void IOneOfValue_ShouldReturnCorrectValue_ForSuccess<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Results<T, SomeClassError>(value);

        //// Assert
        result.Value.Should().Be(value, "the result was initialized with this success value");
        result.Index.Should().Be(0, "success values should have an index of 0");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void IOneOfValue_ShouldReturnCorrectValue_ForError<T>(T value) where T : notnull
    {
        //// Arrange & Act
        var result = new Results<SomeStructType, T>(value);

        //// Assert
        result.Value.Should().Be(value, "the result was initialized with this error value");
        result.Index.Should().Be(1, "error values should have an index of 1");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Match_ShouldExecuteSuccesFunction_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);

        //// Act
        var matchResult = result.Match
        (
            success => $"Success: {success}",
            error => $"Error: {error}"
        );

        //// Assert
        matchResult.Should().Be($"Success: {value}", "the result was initialized with a success value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Match_ShouldExecuteErrorFunction_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);

        //// Act
        var matchResult = result.Match
        (
            success => $"Success: {success}",
            error => $"Error: {error}"
        );

        //// Assert
        matchResult.Should().Be($"Error: {value}", "the result was initialized with an error value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public async Task MatchAsync_ShouldExecuteSuccessFunction_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);

        //// Act
        var matchResult = await result.MatchAsync
        (
            success => Task.FromResult($"Success: {success}"),
            error => Task.FromResult($"Error: {error}")
        );

        //// Assert
        matchResult.Should().Be($"Success: {value}", "the result was initialized with a success value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public async Task MatchAsync_ShouldExecuteErrorFunction_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);

        //// Act
        var matchResult = await result.MatchAsync
        (
            success => Task.FromResult($"Success: {success}"),
            error => Task.FromResult($"Error: {error}")
        );

        //// Assert
        matchResult.Should().Be($"Error: {value}", "the result was initialized with an error value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Switch_ShouldExecuteSuccessAction_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);
        var successActionInvoked = false;

        //// Act
        result.Switch
        (
            _ => successActionInvoked = true,
            _ => Assert.Fail("Expected success, not error.")
        );

        //// Assert
        successActionInvoked.Should().BeTrue("the result was initialized with a success value");
    }

    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void Switch_ShouldExecuteErrorAction_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);
        var errorActionInvoked = false;

        //// Act
        result.Switch
        (
            _ => Assert.Fail("Expected error, not success."),
            _ => errorActionInvoked = true
        );

        //// Assert
        errorActionInvoked.Should().BeTrue("the result was initialized with an error value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public async Task SwitchAsync_ShouldExecuteSuccessFunc_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);
        var successFuncInvoked = false;

        //// Act
        await result.SwitchAsync
        (
            async _ =>
            {
                await Task.Yield();; // Simulate async work
                successFuncInvoked = true;
            },
            async _ =>
            {
                await Task.Yield(); // Simulate async work
                Assert.Fail("Expected success, not error.");
            }
        );

        //// Assert
        successFuncInvoked.Should().BeTrue("the result was initialized with a success value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public async Task SwitchAsync_ShouldExecuteErrorFunc_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);
        var errorFuncInvoked = false;

        //// Act
        await result.SwitchAsync
        (
            async _ =>
            {
                await Task.Yield(); // Simulate async work
                Assert.Fail("Expected error, not success.");
            },
            async _ =>
            {
                await Task.Yield(); // Simulate async work
                errorFuncInvoked = true;
            }
        );

        //// Assert
        errorFuncInvoked.Should().BeTrue("the result was initialized with an error value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ImplicitConversion_FromSuccessValue_ShouldResultInSuccess<T>(T value) where T : notnull
    {
        //// Arrange & Act
        Results<T, SomeClassError> results2 = value;

        //// Assert
        results2.IsSuccess.Should().BeTrue("an implicit conversion from a success value should result in a successful result");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ImplicitConversion_FromErrorValue_ShouldResultInError<T>(T value) where T : notnull
    {
        //// Arrange & Act
        Results<SomeStructType, T> results2 = value;

        //// Assert
        results2.IsError.Should().BeTrue("an implicit conversion from an error value should result in an error result");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ExplicitConversion_ToSuccessValue_ShouldReturnCorrectValue_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);

        //// Act
        var success = (T) result;

        //// Assert
        success.Should().Be(value, "explicit conversion to a success value should return the correct success value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ExplicitConversion_ToErrorValue_ShouldReturnCorrectValue_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);

        //// Act
        var error = (T) result;

        //// Assert
        error.Should().Be(value, "explicit conversion to an error value should return the correct error value");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void TrueOperator_ShouldReturnTrue_IfSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);

        if (result)
            // Assertion inside condition to ensure it's executed.
            result.IsSuccess.Should().BeTrue("the true operator should indicate success for a successful Result");
        else
            Assert.Fail("Result should be successful");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void FalseOperator_ShouldReturnTrue_IfError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);

        if (result)
            Assert.Fail("Result should be an error");
        else
            // Assertion inside condition to ensure it's executed.
            result.IsError.Should().BeTrue("the false operator should indicate an error for a Result initialized as an error");
    }


    [Theory]
    [ClassData(typeof(TwoTypesClassData))]
    public void Results_ShouldBeEqual_WhenInitializedWithSameValue<T1, T2>(T1 value1, T2 value2) where T1 : notnull where T2 : notnull
    {
        //// Arrange
        var result11 = new Results<T1, T2>(value1);
        var result12 = new Results<T1, T2>(value1);
        var result21 = new Results<T1, T2>(value2);
        var result22 = new Results<T1, T2>(value2);

        //// Act && Assert
        result11.Should().Be(result12, "results initialized with the same value should be considered equivalent");
        result21.Should().Be(result22, "results initialized with the same value should be considered equivalent");
        result11.Should().NotBe(result21, "results initialized with the different values should be considered not equivalent");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ToString_Should_ReturnCorrectFormat_WhenSuccess<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<T, SomeClassError>(value);

        //// Act
        var toString = result.ToString();

        //// Assert
        toString
           .Should()
           .Contain($"{nameof(Results<SomeStructType, SomeClassError>.IsSuccess)} = True", "the ToString output for a successful Result should indicate success")
           .And.Contain($"{nameof(Results<SomeStructType, SomeClassError>.Value)} = {value}", "the ToString output should include the value for a successful Results");
    }


    [Theory]
    [ClassData(typeof(OneTypeClassData))]
    public void ToString_Should_ReturnCorrectFormat_WhenError<T>(T value) where T : notnull
    {
        //// Arrange
        var result = new Results<SomeStructType, T>(value);

        //// Act
        var toString = result.ToString();

        //// Assert
        toString
           .Should()
           .Contain($"{nameof(Results<SomeStructType, SomeClassError>.IsSuccess)} = False", "the ToString output for an error Result should indicate it's not successful")
           .And.Contain($"{nameof(Results<SomeStructType, SomeClassError>.Value)} = {value}", "the ToString output should include the value even for an error Results");
    }


    [Fact]
    public void GetHashCode_ShouldReturnDifferentValuesForDifferentResults()
    {
        //// Arrange
        var result1 = new Results<int, string>(42);
        var result2 = new Results<int, string>(43);

        //// Act
        var hashCode1 = result1.GetHashCode();
        var hashCode2 = result2.GetHashCode();

        //// Assert
        hashCode1.Should().NotBe(hashCode2, "different results should produce different hash codes");
    }


    [Fact]
    [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
    [SuppressMessage("Performance", "CA1806:Do not ignore method results")]
    public void Results_ShouldThrow_ArgumentNullException_WhenValueIsNull()
    {
        //// Arrange
        var successAction = () => new Results<string, SomeClassError>((string) null!);
        var errorAction = () => new Results<string, SomeClassError>((SomeClassError) null!);

        //// Act && Assert
        successAction.Should().ThrowExactly<ArgumentNullException>("initializing a Results with a null value should throw an ArgumentNullException");
        errorAction.Should().ThrowExactly<ArgumentNullException>("initializing a Results with a null value should throw an ArgumentNullException");
    }
}