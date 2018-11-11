using System.Runtime.InteropServices;

namespace PangLib.IFF.DataModels
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Desc
    {
        public uint ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string Text;
    }
}
