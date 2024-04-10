using PangLib.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct QuestStuff.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class QuestStuff : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Time { get; set; }
    }

    #endregion

}
