using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct HairStyle
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        public uint Unknown3;
        public uint HairStyleID;
    }
}
