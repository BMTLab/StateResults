using BMTLab.StateResults.Generator.Attributes;

namespace BMTLab.StateResults.Samples;


[StateMarkersGenerator("StateMarkers.csv")]
public static partial class CustomStates
{
    /// <summary>
    ///     Arbitrary custom state types, with a different structure.
    /// </summary>
    public readonly record struct OtherState;
}