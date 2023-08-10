namespace BMTLab.StateResults.Abstractions;

/// <summary>
///     Represents a marker about how the operation went.
/// </summary>
[PublicAPI]
public interface IStateMarker
{
    /// <summary>
    ///     User message about the result of the operation.
    /// </summary>
    public string? Message { get; init; }
}