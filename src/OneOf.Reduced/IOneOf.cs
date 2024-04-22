namespace BMTLab.OneOf.Reduced;

/// <summary>
///     Represents a generalized OneOf type which can be used to hold values of multiple types.
/// </summary>
[PublicAPI]
public interface IOneOf
{
    /// <summary>
    ///     Returns the actual value that this type union was initialized with.
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
    ///     Returns the type that this type union was initialized with.
    /// </summary>
    /// <remarks>
    ///     The property will return one of the types that was declared in the union signature rather than the actual value type that is stored there. for example:
    ///     <code>
    ///     <![CDATA[
    ///     OneOf<int, Exeption> union = new OverflowExeption();
    ///     union.Type // >> System.Exception
    ///     ]]>
    ///     </code>
    ///     Use <c>Value.GetType()</c> to get the runtime type.
    /// </remarks>
    /// <value>The type of the type union.</value>
    /*
     * The property returns a static type, as in the union declaration, which gives a new and only way to get this information,
     * unlike the runtime type that could be obtained from Value.
     */
    Type Type { get; }

    /// <summary>
    ///     Returns the hash code for this instance based on current state of the union.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this instance.
    /// </returns>
    [Pure]
    int GetHashCode() =>
        HashCode.Combine(Index, Value);
}