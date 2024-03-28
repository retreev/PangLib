using System.Runtime.InteropServices;
using PangLib.IFF.Model.Flag;
using PangLib.IFF.Model.General;

namespace PangLib.IFF.Model.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Card
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IFFCommonUs8 Header { get; set; }
    public byte Rarity { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture { get; set; }
    public ushort PowerSlot { get; set; }
    public ushort ControlSlot { get; set; }
    public ushort AccuracySlot { get; set; }
    public ushort SpinSlot { get; set; }
    public ushort CurveSlot { get; set; }
    public CardEffectFlag Effect { get; set; }
    public ushort EffectValue { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string AdditionalTexture1 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string AdditionalTexture2 { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string AdditionalTexture3 { get; set; }
    public ushort EffectTime { get; set; }
    public ushort Volume { get; set; }
    public ushort CardID { get; set; }
}