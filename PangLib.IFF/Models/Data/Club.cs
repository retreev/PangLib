using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Club
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model;
    }
}
