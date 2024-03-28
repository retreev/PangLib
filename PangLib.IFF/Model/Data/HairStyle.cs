using System.Runtime.InteropServices;
using PangLib.IFF.Model.General;

namespace PangLib.IFF.Model.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct HairStyle
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IFFCommonUs8 Header { get; set; }
    public uint Unknown1 { get; set; }
    public uint HairStyleID { get; set; }
}