namespace PangLib.WEP.Models;

/// <summary>
/// Types of point nodes
/// </summary>
public enum PointNodeType : byte
{
    Start = 0,
    Light = 1,
    Sun = 2,
    Sequence = 3
}

/// <summary>
/// Base point node structure
/// </summary>
public struct PointNode
{
    /// <summary>
    /// Type of the point node
    /// </summary>
    public PointNodeType Type { get; set; }
        
    /// <summary>
    /// Name of the point node
    /// </summary>
    public string Name { get; set; }
        
    /// <summary>
    /// Position of the point node
    /// </summary>
    public Vector3<float> Position { get; set; }
        
    /// <summary>
    /// Data of the point node
    /// </summary>
    public string Data { get; set; }
        
    /// <summary>
    /// Second position of the point node
    /// </summary>
    public Vector3<float> Position2 { get; set; }
                
    /// <summary>
    /// Extra values section
    /// </summary>
    public ExtraValues ExtraValues { get; set; }
}