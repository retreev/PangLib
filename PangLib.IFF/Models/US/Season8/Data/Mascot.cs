using System.Runtime.InteropServices;
using PangLib.IFF.Models.US.Season8.General;

namespace PangLib.IFF.Models.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Mascot
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture2 { get; set; }
    public ushort Price1Day { get; set; }
    public ushort Price7Day { get; set; }
    public ushort Unknown1 { get; set; }
    public ushort Price30Day { get; set; }
}