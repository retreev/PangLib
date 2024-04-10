using PangLib.IFF.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct ClubSet.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClubSet : IFFCommon
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class ClubType
        {
            public uint Wood { get; set; }
            public uint Iron { get; set; }
            public uint Wedge { get; set; }
            public uint Putter { get; set; }
        }
        [field: MarshalAs(UnmanagedType.Struct)]
        public ClubType Club { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats Stats { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats SlotStats { get; set; }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class WorkShop
        {
            public uint tipo { get; set; }
            public uint rank_s_stat { get; set; }
            public uint total_recovery { get; set; }
            public float rate { get; set; }
            public uint tipo_rank_s { get; set; }
            public uint flag_transformar { get; set; }
        }
        [field: MarshalAs(UnmanagedType.Struct)]
        public WorkShop work_shop { get; set; }
        public uint ulUnknown { get; set; }
        public uint text_pangya { get; set; }
    }
    #endregion

}
