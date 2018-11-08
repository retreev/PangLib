using System.Runtime.InteropServices;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Ball {
    public uint Active;
    public uint ID;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name;
    public byte Level;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon;
    public uint Price;
    public uint DiscountPrice;
    public uint UsedPrice;
    public uint ShopFlag;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 36)]
    public string Unknown1;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture;
    public uint Unknown2;
    public uint Unknown3;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence0;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence1;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence2;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence3;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence4;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence5;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string BallSequence6;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string EffectName;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 240)]
    public string Unknown4;
    public uint PangBonus;
  }
}