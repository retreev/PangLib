using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Course
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string ShortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string LocalizedName;
        public byte CourseFlag;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string PropertyFileName;
        public uint Unknown1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string CourseSequence;
    }
}
