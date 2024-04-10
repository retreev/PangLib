using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Course : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Mpet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        byte[] _Gbin { get; set; }
        public string Gbin
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(_Gbin).Replace("\0", "");
            set => _Gbin = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(64, '\0'));
        }
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
        public sbyte[] Min_Score_Hole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public sbyte[] Max_Score_Hole { get; set; }
        public ushort usUnknown { get; set; }

    }
}
