using System.Runtime.InteropServices;
using PangLib.IFF.BitFlags;

namespace PangLib.IFF.GeneralModels
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IFFCommon
    {
        public uint Active;
        public uint ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name;
        public byte Level;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Icon;
        public uint Price;
        public uint DiscountPrice;
        public uint UsedPrice;
        public ShopFlag ShopFlag;
        public MoneyFlag MoneyFlag;
        public byte TimeFlag;
        public byte TimeByte;
        public uint Point;
        [MarshalAs(UnmanagedType.Struct)]
        public SystemTime StartTime;
        [MarshalAs(UnmanagedType.Struct)]
        public SystemTime EndTime;
    }
}
