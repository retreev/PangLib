using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ClubSet
    {
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header { get; set; }
        public uint WoodID { get; set; }
        public uint IronID { get; set; }
        public uint WedgeID { get; set; }
        public uint PutterID { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
    }
}
