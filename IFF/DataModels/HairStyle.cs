using System.Runtime.InteropServices;

namespace IFF.DataModels {

  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct HairStyle {
    public uint Active;
    public uint ID;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name;
    public byte Level;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon;
    public uint Price;
    public uint DiscountPrice;
    public uint Unknown1;
    public uint ShopFlag;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 32)]
    public string Unknown2;
    public uint Unknown3;
    public uint HairStyleID;
  }
}