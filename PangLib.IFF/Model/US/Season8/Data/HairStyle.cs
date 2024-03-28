using System.Runtime.InteropServices;
using PangLib.IFF.Model.US.Season8.General;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct HairStyle
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    public uint Unknown1 { get; set; }
    public uint HairStyleID { get; set; }
}