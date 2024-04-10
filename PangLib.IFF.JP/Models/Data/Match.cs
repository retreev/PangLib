using PangLib.IFF.JP.Models.Flags;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.JP.Models.Data
{
    /// <summary>
    /// Is Struct file Match.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Match
    {
        public uint Enable { get; set; }
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]//is 64, 2 short unknown
        public byte[] NameInBytes { get; set; }
        public string Name { get => Encoding.GetEncoding("Shift_JIS").GetString(NameInBytes).Replace("\0", ""); set => NameInBytes = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(80, '\0')); }

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
