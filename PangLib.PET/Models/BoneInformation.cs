namespace PangLib.PET.Models;

/// <summary>
/// Bone information structure used inside <see cref="PangLib.PET.Models.Vertex"/>
/// </summary>
public struct BoneInformation
{
    /// <summary>
    /// Weight of the binding to <see cref="BoneID"/>
    /// </summary>
    public byte Weight { get; set; }
        
    /// <summary>
    /// ID of the <see cref="PangLib.PET.Models.Bone"/> the <see cref="PangLib.PET.Models.Vertex"/> is attached to
    /// </summary>
    public byte BoneID { get; set; }
}