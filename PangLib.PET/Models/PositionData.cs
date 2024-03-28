namespace PangLib.PET.Models;

/// <summary>
/// Positional data structure used inside <see cref="PangLib.PET.Models.Animation"/>, determining position changes
/// </summary>
public struct PositionData
{
    /// <summary>
    /// Time in seconds
    /// </summary>
    public float Time { get; set; }
        
    /// <summary>
    /// X coordinate at <see cref="Time"/>
    /// </summary>
    public float X { get; set; }
        
    /// <summary>
    /// Y coordinate at <see cref="Time"/>
    /// </summary>
    public float Y { get; set; }
        
    /// <summary>
    /// Z coordinate at <see cref="Time"/>
    /// </summary>
    public float Z { get; set; }
}