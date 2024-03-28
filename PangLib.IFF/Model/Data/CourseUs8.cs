using System.Runtime.InteropServices;
using PangLib.IFF.Model.General;

namespace PangLib.IFF.Model.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct CourseUs8
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IFFCommonUs8 Header { get; set; }
    
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