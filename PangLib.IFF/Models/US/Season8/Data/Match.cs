using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Match
{
    public uint Active { get; set; }
    public uint ID { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
    public string Name { get; set; }
    public byte Level { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string TrophyTexture1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string TrophyTexture2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string TrophyTexture3 { get; set; }
}