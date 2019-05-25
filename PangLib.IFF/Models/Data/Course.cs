using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Course
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string ShortName { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string LocalizedName { get; set; }
        public byte CourseFlag { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string PropertyFileName { get; set; }
        public uint Unknown1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string CourseSequence { get; set; }
    }
}
