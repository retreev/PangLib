using System.Runtime.InteropServices;
using PangLib.IFF.GeneralModels;

namespace PangLib.IFF.DataModels
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
