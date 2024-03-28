namespace PangLib.PET.Models;

/// <summary>
/// Base version structure for Puppet files
/// </summary>
public struct Version
{
    /// <summary>
    /// Major version number
    /// </summary>
    public int Major { get; set; }
        
    /// <summary>
    /// Minor version number
    /// </summary>
    public int Minor { get; set; }
        
    /// <summary>
    /// String override that returns the full version number
    /// </summary>
    /// <returns>A string composed of the Major and Minor version number</returns>
    public override string ToString()
    {
        return $"{Major.ToString()}.{Minor.ToString()}";
    }
}