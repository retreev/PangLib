using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    /// <summary>
    /// Is Struct file Course.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Course : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Mpet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Gbin { get; set; }
        public byte Star { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]
        public string XML { get; set; }
        public float RatePang { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] Seq { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public uint[] ulUnknown { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Par_Hole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Min_Score_Hole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Max_Score_Hole { get; set; }
        public ushort usUnknown { get; set; }

    }
}
