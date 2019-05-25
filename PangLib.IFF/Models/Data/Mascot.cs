using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Mascot
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2;
        public ushort Price1Day;
        public ushort Price7Day;
        public ushort Unknown1;
        public ushort Price30Day;
    }
}
