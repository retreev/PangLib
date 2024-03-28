namespace PangLib.PET.Models;

/// <summary>
/// UV mapping structure used inside <see cref="PangLib.PET.Models.PolygonIndex"/>
/// </summary>
public struct UVMapping
{
    /// <summary>
    /// U-axis of the UV mapping
    /// </summary>
    public float U { get; set; }
        
    /// <summary>
    /// V-axis of the UV mapping
    /// </summary>
    public float V { get; set; }
}