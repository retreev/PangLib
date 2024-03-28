using System.Runtime.InteropServices;

namespace PangLib.IFF.Model.General;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct StatsStruct
{
    public ushort Power { get; set; }
    public ushort Control { get; set; }
    public ushort Accuracy { get; set; }
    public ushort Spin { get; set; }
    public ushort Curve { get; set; }
}