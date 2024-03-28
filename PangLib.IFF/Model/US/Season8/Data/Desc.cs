using System.Runtime.InteropServices;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Desc
{
    public uint ID { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
    public string Text { get; set; }
}