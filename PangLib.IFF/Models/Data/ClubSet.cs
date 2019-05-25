using System.Runtime.InteropServices;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct ClubSet
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        public uint WoodID;
        public uint IronID;
        public uint WedgeID;
        public uint PutterID;
        public ushort Power;
        public ushort Control;
        public ushort Accuracy;
        public ushort Spin;
        public ushort Curve;
        public ushort PowerSlot;
        public ushort ControlSlot;
        public ushort AccuracySlot;
        public ushort SpinSlot;
        public ushort CurveSlot;
    }
}
