namespace BMTLab.StateResults.Abstractions;

/// <summary>
///     Represents a marker that the operation ended with an error.
/// </summary>
[PublicAPI]
public interface IErrorStateMarker : IStateMarker
{
    /// <summary>
    ///     Aggregates the exception that led to this result.
    /// </summary>
    public Exception? Exception { get; }
}