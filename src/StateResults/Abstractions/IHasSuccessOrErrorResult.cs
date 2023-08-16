namespace BMTLab.StateResults.Abstractions;

/// <summary>
///     Determines that the derived object has a state, indicating whether it is successful or not.
/// </summary>
[PublicAPI]
public interface IHasSuccessOrErrorResult
{
    /// <summary>
    ///     Successful result?
    /// </summary>
    bool IsSuccess { get; }

    /// <summary>
    ///     Failed result?
    /// </summary>
    bool IsError { get; }


    /// <exception cref="ArgumentNullException"><paramref name="result" /> is <c>null</c>.</exception>
    /// <returns><c>true</c> if <see cref="IsSuccess" /> is <c>true</c>.</returns>
    public static bool operator true(in IHasSuccessOrErrorResult result)
    {
        ThrowIfNull(result);

        return result.IsSuccess;
    }


    /// <exception cref="ArgumentNullException"><paramref name="result" /> is <c>null</c>.</exception>
    /// <returns><c>true</c> if <see cref="IsError" /> is <c>true</c>.</returns>
    public static bool operator false(in IHasSuccessOrErrorResult result)
    {
        ThrowIfNull(result);

        return result.IsError;
    }
}