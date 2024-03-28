namespace PangLib.PET.Models;

/// <summary>
/// Scaling data structure used inside <see cref="PangLib.PET.Models.Animation"/>, determining scale changes
/// </summary>
public struct ScalingData
{
    /// <summary>
    /// Time in seconds
    /// </summary>
    public float Time { get; set; }
        
    /// <summary>
    /// Scale of X coordinate at <see cref="Time"/>
    /// </summary>
    public float X { get; set; }
        
    /// <summary>
    /// Scale of Y coordinate at <see cref="Time"/>
    /// </summary>
    public float Y { get; set; }
        
    /// <summary>
    /// Scale of Z coordinate at <see cref="Time"/>
    /// </summary>
    public float Z { get; set; }
}