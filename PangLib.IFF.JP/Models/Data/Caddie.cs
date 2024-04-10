using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{

    #region Struct Caddie.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Caddie : IFFCommon
    {
        public uint Salary { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x27 + 1)]
        public string MPet { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Un4 { get; set; }

        public Caddie(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            Salary = reader.ReadUInt32();
            MPet = reader.ReadPStr(0x27 + 1);
            Power = reader.ReadUInt16();
            Control = reader.ReadUInt16();
            Impact = reader.ReadUInt16();
            Spin = reader.ReadUInt16();
            Curve = reader.ReadUInt16();
            Un4 = reader.ReadUInt16();
        }
        public Caddie()
        { }
    }
    #endregion
}
