using System.Runtime.InteropServices;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct ClubSet {
    public uint Active;  
    public uint ID;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name;
    public byte Level;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon;
    public uint Price;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 48)]
    public string Unknown1;
    public uint WoodID;
    public uint IronID;
    public uint WedgeID;
    public uint PutterID;
    public ushort Power;
    public ushort Control;
    public ushort Accuracy;
    public ushort Spin;
    public ushort Curve;
    public ushort PowerSlot;
    public ushort ControlSlot;
    public ushort AccuracySlot;
    public ushort SpinSlot;
    public ushort CurveSlot;
  }
}