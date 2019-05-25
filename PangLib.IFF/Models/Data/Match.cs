using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Match
    {
        public uint Active;
        public uint ID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string Name;
        public byte Level;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture3;
    }
}
