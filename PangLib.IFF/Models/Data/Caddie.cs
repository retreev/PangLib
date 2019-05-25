using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Caddie
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        public uint Salary;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model;
        public ushort Power;
        public ushort Control;
        public ushort Accuracy;
        public ushort Spin;
        public ushort Curve;
    }
}
