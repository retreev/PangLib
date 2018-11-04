using System.Runtime.InteropServices;

namespace IFF.DataModels {

  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Character {
    public uint Active;
    public uint TypeId;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name;
    public byte Level;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon;
    public byte Flag1;
    public byte Flag2;
    public byte Flag3;
    public uint Price;
    public uint DiscountPrice;
    public uint UsedPrice;
    public uint FlagShop;
    public uint TikiPointsQuantity;
    public uint TikiPoints;
    public ushort RecylingPoints;
    public ushort BonusProbability;
    public ushort RecylingPoints2;
    public ushort RecylingPoints3;
    public uint TikiType;
    public uint TikiPang;
    public uint ActiveDate;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 16)]
    public string ActivationDate;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 16)]
    public string EndDate;
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