namespace BMTLab.StateResults.Generator.Attributes;

/// <summary>
///     Attribute for the partial class within which state marker structures will be generated based on the .csv file.
/// </summary>
[PublicAPI]
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class StateMarkersGeneratorAttribute : Attribute
{
    [SuppressMessage("Performance", "CA1802:Use literals where appropriate")]
    internal static readonly string DefaultFileName = "StateMarkers.csv";


    /// <summary>
    ///     Initializes the generator with an arbitrary name of the source .csv file.
    /// </summary>
    /// <remarks>
    ///     The .csv file should be labeled as AdditionalFile.
    /// </remarks>
    /// <param name="fileName">The name of the source .csv file to generate the state markers class.</param>
    /// <example>
    ///     <code>
    ///         [StateMarkersGenerator("StateMarkers.csv")]
    ///         public static partial class CustomStates
    ///         {
    ///             public readonly record struct OtherState;
    ///         }
    ///     </code>
    /// </example>
    [SuppressMessage("Design", "CA1019:Define accessors for attribute arguments")]
    public StateMarkersGeneratorAttribute(string fileName)
    {
        /*
            Since the attribute is used for the code generator, only syntactic analysis of the value passed to the constructor is used,
            the code generator does not have access to the attribute properties, so there is no need to define the property and store the value of fileName
        */
    }
}