using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    /// <summary>
    /// Is Struct file Furniture.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Furniture : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model { get; set; }
        public ushort Unknown { get; set; }
        public ushort Unknown2 { get; set; }
        public ushort Unknown3 { get; set; }
        public ushort Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint Unknown6 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string Texture { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string Texture2 { get; set; }
    }
}
