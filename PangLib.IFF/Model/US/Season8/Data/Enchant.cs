using System.Runtime.InteropServices;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Enchant
{
    public uint Active { get; set; }
    public uint ID { get; set; }
    public uint Price { get; set; }
}