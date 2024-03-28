using System.Runtime.InteropServices;
using PangLib.IFF.Model.General;

namespace PangLib.IFF.Model.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct BallUs8
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IFFCommonUs8 Header { get; set; }
    
    public uint Unknown { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model { get; set; }
    
    public uint Unknown2 { get; set; }
    public uint Unknown3 { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence3 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence4 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence5 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence6 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence7 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx3 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx4 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx5 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx6 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallFx7 { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    
    public ushort Unknown4 { get; set; }
}