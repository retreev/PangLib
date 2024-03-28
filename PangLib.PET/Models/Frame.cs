namespace PangLib.PET.Models;

/// <summary>
/// Base frame structure for Puppet files
/// </summary>
public struct Frame
{
    /// <summary>
    /// Index of the frame
    /// </summary>
    public uint Index { get; set; }
        
    /// <summary>
    /// Script executed on this frame
    /// </summary>
    public string Script { get; set; }
        
    /// <summary>
    /// X origin coordinate
    /// </summary>
    public float X { get; set; }
        
    /// <summary>
    /// Y origin coordinate
    /// </summary>
    public float Y { get; set; }
        
    /// <summary>
    /// Z origin coordinate
    /// </summary>
    public float Z { get; set; }
}