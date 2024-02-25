using PangLib.IFF.Models.Flags;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.Models.Data
{
    /// <summary>
    /// Is Struct file Match.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Match
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        byte[] NameInBytes { get; set; }
        public string Name { get => Encoding.UTF7.GetString(NameInBytes).Replace("\0", ""); set => NameInBytes = Encoding.UTF7.GetBytes(value.PadRight(80, '\0')); }
        public ItemLevelEnum Level { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TrophyTexture6 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Blank { get; set; }
    }
}
