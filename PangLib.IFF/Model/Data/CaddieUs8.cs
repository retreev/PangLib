using System.Runtime.InteropServices;
using PangLib.IFF.Model.General;

namespace PangLib.IFF.Model.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct CaddieUs8
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IFFCommonUs8 Header { get; set; }
    
    public uint MonthRentalCost { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    
    public ushort Unknown { get; set; }
}