using System.Runtime.InteropServices;
using PangLib.IFF.Models.Flags;

namespace PangLib.IFF.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IFFCommon
    {
        public uint Active { get; set; }
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }
        public byte Level { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Icon { get; set; }
        public uint Price { get; set; }
        public uint DiscountPrice { get; set; }
        public uint UsedPrice { get; set; }
        public ShopFlag ShopFlag { get; set; }
        public MoneyFlag MoneyFlag { get; set; }
        public byte TimeFlag { get; set; }
        public byte TimeByte { get; set; }
        public uint Point { get; set; }
        [field: MarshalAs(UnmanagedType.Struct)]
        public SystemTime StartTime { get; set; }
        [field: MarshalAs(UnmanagedType.Struct)]
        public SystemTime EndTime { get; set; }
    }
}
