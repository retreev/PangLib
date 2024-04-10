using PangLib.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct Achievement.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Achievement : IFFCommon
    {
        public uint TypeID_Quest_Index { get; set; }
        public uint Achievement_Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName6 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName7 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName8 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        public string QuestName9 { get; set; }
        public short S_Unknown { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Quest_TypeID { get; set; }
        public uint T_Unknown { get; set; }
    }
    #endregion
}
