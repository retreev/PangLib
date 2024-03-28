using System.Runtime.InteropServices;
using PangLib.IFF.Model.US.Season8.General;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Caddie
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    
    public uint MonthRentalCost { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model { get; set; }
    
    [field: MarshalAs(UnmanagedType.Struct)]
    public StatsStruct Stats { get; set; }
    
    public ushort Unknown { get; set; }
}