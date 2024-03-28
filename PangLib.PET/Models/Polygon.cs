namespace PangLib.PET.Models;

/// <summary>
/// Polygon structure used inside <see cref="PangLib.PET.Models.Mesh"/>
/// </summary>
public struct Polygon
{
    /// <summary>
    /// List of <see cref="PangLib.PET.Models.PolygonIndex"/> making up this polygon
    /// </summary>
    public PolygonIndex[] PolygonIndices { get; set; }
}