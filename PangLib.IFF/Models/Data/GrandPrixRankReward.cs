using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.Data
{
    #region Struct GrandPrixRankReward.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]

    public class GrandPrixRankReward
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public uint Rank { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] RewardTypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Quantity;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string Unknown { get; set; }
        public uint Trophy { get; set; }
    }
    #endregion

}
