using PangLib.IFF.JP.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct AuxPart.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class AuxPart : IFFCommon
    {
        public ushort Price1Day { get; set; }
        public ushort Price7Day { get; set; }
        public ushort Price15Day { get; set; }
        public ushort Price30Day { get; set; }
        public ushort Price365Day { get; set; }
        public byte Power { get; set; }
        public byte Control { get; set; }
        public byte Impact { get; set; }
        public byte Spin { get; set; }
        public byte Curve { get; set; }
        public byte PowerSlot { get; set; }
        public byte ControlSlot { get; set; }
        public byte ImpactSlot { get; set; }
        public byte SpinSlot { get; set; }
        public byte CurveSlot { get; set; }
        public UInt16 Power_Drive { get; set; }
        public UInt16 Drop_Rate { get; set; }
        public UInt16 Power_Gauge { get; set; }
        public UInt16 Pang_Rate { get; set; }
        public UInt16 Exp_Rate { get; set; }
        public UInt16 ItemSlot { get; set; }
        public ushort Bonus_Pang { get; set; }
        public ushort Bonus_Flag { get; set; }
    }
    #endregion
}
