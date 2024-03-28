using System.Runtime.InteropServices;
using PangLib.IFF.Model.US.Season8.General;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Character
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture3 { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    
    public byte Unknown1 { get; set; }
    public byte Unknown2 { get; set; }
    public uint Unknown3 { get; set; }
    
    public float ClubSetScale { get; set; }
    
    public byte RankSPowerSlot { get; set; }
    public byte RankSControlSlot { get; set; }
    public byte RankSAccuracySlot { get; set; }
    public byte RankSSpinSlot { get; set; }
    public byte RankSCurveSlot { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string AdditionalTexture { get; set; }
}