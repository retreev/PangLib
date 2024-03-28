namespace PangLib.WEP.Models;

/// <summary>
/// Base area node structure
/// </summary>
public struct AreaNode
{
    /// <summary>
    /// Type of area node
    /// </summary>
    public byte Type { get; set; }
        
    /// <summary>
    /// Associated script sequence
    /// </summary>
    public string Sequence { get; set; }
        
    /// <summary>
    /// First area
    /// </summary>
    public Area Area { get; set; }
        
    /// <summary>
    /// Second area
    /// </summary>
    public Area Area2 { get; set; }
        
    /// <summary>
    /// Extra values section
    /// </summary>
    public ExtraValues ExtraValues { get; set; }
}