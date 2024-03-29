using System.Runtime.InteropServices;
using PangLib.IFF.Models.US.Season8.General;
using PangLib.IFF.Models.US.Season8.Type;

namespace PangLib.IFF.Models.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Part
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon CommonItem { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string MPet { get; set; }
    
    public PartType PartType { get; set; }
    /// <summary>
    /// Slot in Equipment Array of CharacterDto
    /// Flags of slot's index
    /// </summary>
    public uint PartSlotBitMap { get; set; }
    
    public uint Unknown1 { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture3 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture4 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture5 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture6 { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct SlotStats { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Unknown2 { get; set; }
    
    /** Second possible Id, probably related to items with 2 pieces (like gloves), it is useful for server-side cloth slot placement validation */
    public int Id2 { get; set; }
    public int Unknown4 { get; set; }
    
    public ushort Unknown5 { get; set; }
    /// <summary>
    /// Third Caddie Card Slot
    /// </summary>
    public short CaddieCardSlotFlag { get; set; }
    
    public uint Unknown6 { get; set; }
    /// <summary>
    /// TODO: investigate
    /// </summary>
    public int RentPrice { get; set; }
    public uint Unknown7 { get; set; }
}