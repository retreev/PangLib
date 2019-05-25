using System.Runtime.InteropServices;
using PangLib.IFF.Models.Flags;

namespace PangLib.IFF.Models.General
{
    /// <summary>
    /// Common data structure found at the head of many IFF datasets
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct IFFCommon
    {
        /// <summary>
        /// Status of this object
        /// </summary>
        public uint Active { get; set; }
        
        /// <summary>
        /// ID of this object
        /// </summary>
        public uint ID { get; set; }
        
        /// <summary>
        /// Name of this object
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }
        
        /// <summary>
        /// Level requirement for this object
        /// </summary>
        public byte Level { get; set; }
        
        /// <summary>
        /// Icon for this object
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Icon { get; set; }
        
        /// <summary>
        /// Price of this object
        /// </summary>
        public uint Price { get; set; }
        
        /// <summary>
        /// Discounted price of this object
        /// </summary>
        public uint DiscountPrice { get; set; }
        
        /// <summary>
        /// Used price of this object
        /// </summary>
        public uint UsedPrice { get; set; }
        
        /// <summary>
        /// Instance of <see cref="PangLib.IFF.Models.Flags.ShopFlag"/>
        /// </summary>
        public ShopFlag ShopFlag { get; set; }
        
        /// <summary>
        /// Instance of <see cref="PangLib.IFF.Models.Flags.MoneyFlag"/>
        /// </summary>
        public MoneyFlag MoneyFlag { get; set; }
        
        /// <summary>
        /// A time flag
        /// </summary>
        public byte TimeFlag { get; set; }
        
        /// <summary>
        /// A time byte
        /// </summary>
        public byte TimeByte { get; set; }
        
        /// <summary>
        /// Point price of this object
        /// </summary>
        public uint Point { get; set; }
        
        /// <summary>
        /// Time this object becomes available
        /// </summary>
        [field: MarshalAs(UnmanagedType.Struct)]
        public SystemTime StartTime { get; set; }
        
        /// <summary>
        /// Time this object stops being available
        /// </summary>
        [field: MarshalAs(UnmanagedType.Struct)]
        public SystemTime EndTime { get; set; }
    }
}
