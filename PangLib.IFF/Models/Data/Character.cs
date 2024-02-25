using PangLib.IFF.Models.General;
using System.IO;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{

    #region Struct Character.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Character : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture3 { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte ImpactSlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public byte Un1 { get; set; }
        public float Scale_club_set { get; set; }
        public byte Stat1 { get; set; }
        public byte Stat2 { get; set; }
        public byte Stat3 { get; set; }
        public byte Stat4 { get; set; }
        public byte Stat5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]
        public string Texture4 { get; set; }

    }
    #endregion
}
