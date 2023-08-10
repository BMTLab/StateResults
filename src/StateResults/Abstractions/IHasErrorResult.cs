namespace BMTLab.StateResults.Abstractions;

/// <summary>
///     Determines that the derived object has a state, indicating whether it is failed or not.
/// </summary>
[PublicAPI]
public interface IHasErrorResult
{
    /// <summary>
    ///     Failed result?
    /// </summary>
    bool IsError { get; }
}