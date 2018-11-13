using System.Runtime.InteropServices;
using PangLib.IFF.GeneralModels;

namespace PangLib.IFF.DataModels
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct AuxPart
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        public byte Amount;
        public byte Unknown1;
        public byte Unknown2;
        public byte Unknown3;
        public byte Unknown4;
        public byte Unknown5;
        public byte Unknown6;
        public byte Unknown7;
        public byte Unknown8;
        public byte Unknown9;
        public byte Power;
        public byte Control;
        public byte Accuracy;
        public byte Spin;
        public byte Curve;
        public byte PowerSlot;
        public byte ControlSlot;
        public byte AccuracySlot;
        public byte SpinSlot;
        public byte CurveSlot;
        public ushort ClubDistance;
        public ushort Luck;
        public ushort PowerGauge;
        public ushort PangBonus;
        public ushort ExperiencePercentage;
        public byte Unknown24;
        public byte Unknown25;
        public byte Unknown26;
        public byte Unknown27;
    }
}
