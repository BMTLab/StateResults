namespace BMTLab.StateResults.Abstractions;

/// <summary>
///     Determines that the derived object has a state, indicating whether it is successful or not.
/// </summary>
[PublicAPI]
public interface IHasSuccessResult
{
    /// <summary>
    ///     Successful result?
    /// </summary>
    bool IsSuccess { get; }
}