using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct AuxPart
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header { get; set; }
        public byte Amount { get; set; }
        public byte Unknown1 { get; set; }
        public byte Unknown2 { get; set; }
        public byte Unknown3 { get; set; }
        public byte Unknown4 { get; set; }
        public byte Unknown5 { get; set; }
        public byte Unknown6 { get; set; }
        public byte Unknown7 { get; set; }
        public byte Unknown8 { get; set; }
        public byte Unknown9 { get; set; }
        public byte Power { get; set; }
        public byte Control { get; set; }
        public byte Accuracy { get; set; }
        public byte Spin { get; set; }
        public byte Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte AccuracySlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public ushort ClubDistance { get; set; }
        public ushort Luck { get; set; }
        public ushort PowerGauge { get; set; }
        public ushort PangBonus { get; set; }
        public ushort ExperiencePercentage { get; set; }
        public byte Unknown24 { get; set; }
        public byte Unknown25 { get; set; }
        public byte Unknown26 { get; set; }
        public byte Unknown27 { get; set; }
    }
}
