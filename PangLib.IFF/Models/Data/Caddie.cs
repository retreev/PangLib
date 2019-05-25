using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Caddie
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header { get; set; }
        public uint Salary { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
    }
}
