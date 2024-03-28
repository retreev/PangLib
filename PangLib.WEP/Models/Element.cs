namespace PangLib.WEP.Models;

/// <summary>
/// Base element structure
/// </summary>
public struct Element
{
    /// <summary>
    /// Unknown (possible?) flag values
    /// </summary>
    public int Unknown { get; set; }
        
    /// <summary>
    /// Count of vertices
    /// </summary>
    public int VertexCount { get; set; }
        
    /// <summary>
    /// Element name
    /// </summary>
    public string Name { get; set; }
        
    /// <summary>
    /// First matrix values
    /// </summary>
    public Matrix Matrix1 { get; set; }
        
    /// <summary>
    /// Second matrix values
    /// </summary>
    public Matrix Matrix2 { get; set; }
        
    /// <summary>
    /// Course/Element type
    /// </summary>
    public int CourseType { get; set; }
        
    /// <summary>
    /// Name of the element class
    /// </summary>
    public string ClassName { get; set; }
        
    /// <summary>
    /// Third matrix values
    /// </summary>
    public Matrix Matrix3 { get; set; }
                
    /// <summary>
    /// Extra values section
    /// </summary>
    public ExtraValues ExtraValues { get; set; }
}