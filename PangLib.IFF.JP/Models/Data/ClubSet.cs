using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct ClubSet.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClubSet : IFFCommon
    {
        public ClubSet(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            Wood = reader.ReadUInt32();
            Iron = reader.ReadUInt32();
            Wedge = reader.ReadUInt32();
            Putter = reader.ReadUInt32();
            Power = reader.ReadUInt16();
            Control = reader.ReadUInt16();
            Impact = reader.ReadUInt16();
            Spin = reader.ReadUInt16();
            Curve = reader.ReadUInt16();
            PowerSlot = reader.ReadUInt16();
            ControlSlot = reader.ReadUInt16();
            ImpactSlot = reader.ReadUInt16();
            SpinSlot = reader.ReadUInt16();
            CurveSlot = reader.ReadUInt16();
            ClubType = reader.ReadUInt32();
            ClubSPoint = reader.ReadUInt32();
            RecoveryLimit = reader.ReadUInt32();
            RateWorkshop = reader.ReadSingle();
            Rank_WorkShop = reader.ReadUInt32();
            Transafer = reader.ReadUInt16();
            Flag1 = reader.ReadUInt16();
            Unknown7 = reader.ReadUInt32();
            Real_TypeID = reader.ReadUInt32();
        }
        public ClubSet()
        {

        }
        public uint Wood { get; set; }
        public uint Iron { get; set; }
        public uint Wedge { get; set; }
        public uint Putter { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort ImpactSlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public uint ClubType { get; set; }
        public uint ClubSPoint { get; set; }
        public uint RecoveryLimit { get; set; }
        public float RateWorkshop { get; set; }
        public uint Rank_WorkShop { get; set; }
        public ushort Transafer { get; set; }
        public ushort Flag1 { get; set; }
        public uint Unknown7 { get; set; }
        public uint Real_TypeID { get; set; }
    }
    #endregion

}
