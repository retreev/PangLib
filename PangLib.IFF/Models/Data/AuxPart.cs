using PangLib.IFF.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct AuxPart.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class AuxPart : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFPrice sPrice { get; set; }
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
        public ushort Power_Drive { get; set; }
        public ushort Drop_Rate { get; set; }
        public ushort Power_Gauge { get; set; }
        public ushort Pang_Rate { get; set; }
        public ushort Exp_Rate { get; set; }
        public ushort ItemSlot { get; set; }
        public ushort Bonus_Pang { get; set; }
        public ushort Bonus_Flag { get; set; }
    }
    #endregion
}
