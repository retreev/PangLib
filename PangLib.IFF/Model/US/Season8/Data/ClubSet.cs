using System.Runtime.InteropServices;
using PangLib.IFF.Model.US.Season8.General;
using PangLib.IFF.Model.US.Season8.Type;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct ClubSet
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    public uint WoodID { get; set; }
    public uint IronID { get; set; }
    public uint WedgeID { get; set; }
    public uint PutterID { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct SlotStats { get; set; }
    
    public ClubSetWorkshopType WorkshopType { get; set; }
    
    /// <summary>
    /// TODO: Something for the Rank S Bonus stat
    /// </summary>
    public uint WorkshopRankSStat { get; set; }
    public uint WorkshopRecoveryPointsLimit { get; set; }
    
    /// <summary>
    /// Rate that will get for hole played
    /// </summary>
    public float WorkshopPlayRate { get; set; }
    
    /// <summary>
    /// TODO: No idea, something related to Stats and XP
    /// </summary>
    public uint WorkshopRankSType { get; set; }
    
    /// <summary>
    /// TODO: No idea, something related to Transformation or Transafer
    /// </summary>
    public ushort WorkshopTransformFlag { get; set; }
    public ushort UnknownFlag { get; set; }
    
    public uint Unknown { get; set; }
    
    public uint PangyaHitIconId { get; set; }
}