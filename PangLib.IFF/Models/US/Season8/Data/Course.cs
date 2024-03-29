using System.Runtime.InteropServices;
using PangLib.IFF.Models.US.Season8.General;

namespace PangLib.IFF.Models.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Course
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string MpetFile { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string GbinFile { get; set; }
    
    public byte Difficulty { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string XmlFile { get; set; }
    
    public float RatePang { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string SeqFile { get; set; }
    
    /** TODO: investigate what this does */
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
    public int[] Unknown3 { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
    public byte[] ParsByHole { get; set; }
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
    public sbyte[] MinScoreByHole { get; set; }
    [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
    public sbyte[] MaxScoreByHole { get; set; }
}