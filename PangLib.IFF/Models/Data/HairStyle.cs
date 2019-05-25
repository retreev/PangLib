using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct HairStyle
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header { get; set; }
        public uint Unknown1 { get; set; }
        public uint HairStyleID { get; set; }
    }
}
