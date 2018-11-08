using System.Runtime.InteropServices;
using PangLib.IFF.GeneralModels;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Character {
    [MarshalAs (UnmanagedType.Struct)]
    public IFFCommon Header;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture1;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture2;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture3;
    public ushort Power;
    public ushort Control;
    public ushort Accuracy;
    public ushort Spin;
    public ushort Curve;
    public byte PowerSlot;
    public byte ControlSlot;
    public byte AccuracySlot;
    public byte SpinSlot;
    public byte CurveSlot;
    public byte Unknown1;
    public uint RankS;
    public byte RankSPowerSlot;
    public byte RankSControlSlot;
    public byte RankSAccuracySlot;
    public byte RankSSpinSlot;
    public byte RankSCurveSlot;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string AdditionalTexture;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 3)]
    public string Unknown2;
  }
}