namespace BMTLab.OneOf.Reduced;

/// <summary>
///     Represents a generalized OneOf type which can be used to hold values of multiple types.
/// </summary>
[PublicAPI]
public interface IOneOf
{
    /// <summary>
    ///     A value of the type union.
    /// </summary>
    /// <remarks>
    ///     The union can hold a value of any type defined within the set of possible types.
    /// </remarks>
    /// <value>The value of the type union.</value>
    object Value { get; }

    /// <summary>
    ///     Returns the sequence positive number of the type that stores this union.
    /// </summary>
    /// <example>0</example>
    int Index { get; }

    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    public int GetHashCode() =>
        HashCode.Combine(Index, Value);
}