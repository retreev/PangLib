using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.General;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PangLib.IFF.JP.Models.Data
{
    #region Struct Part.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Part : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public uint EquipmentCategory { get; set; }// o tipo do item, 0, 2 normal, 8 e 9 UCC, 5 acho que é base ou commom Item
        public short PosMask { get; set; }
        public short HideMask { get; set; }
        public UInt32 Un2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture6 { get; set; }
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
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] EquippableWith { get; set; }
        public uint SubPart1 { get; set; }
        public uint SubPart2 { get; set; }
        public ushort CardCharSlots { get; set; }
        public ushort CardCaddieSlots { get; set; }
        public uint Points { get; set; }
        public uint RentPang { get; set; }
        public UInt32 Un4 { get; set; }
 
        public Part(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            MPet = reader.ReadPStr(40);
            EquipmentCategory = reader.ReadUInt32();// o tipo do item, 0, 2 normal, 8 e 9 UCC, 5 acho que é base ou commom Item
            PosMask = reader.ReadInt16();
            HideMask = reader.ReadInt16();
            Un2 = reader.ReadUInt32();

            Texture1 = reader.ReadPStr(40);

            Texture2 = reader.ReadPStr(40);

            Texture3 = reader.ReadPStr(40);

            Texture4 = reader.ReadPStr(40);

            Texture5 = reader.ReadPStr(40);
            Texture6 = reader.ReadPStr(40);
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
            EquippableWith = reader.ReadBytes(40);
            SubPart1 = reader.ReadUInt32();
            SubPart2 = reader.ReadUInt32();
            CardCharSlots = reader.ReadUInt16();
            CardCaddieSlots = reader.ReadUInt16();
            Points = reader.ReadUInt32();
            RentPang = reader.ReadUInt32();
            Un4 = reader.ReadUInt32();
            reader.Close();
        }
        public Part()
        {
        }
        
    }
    #endregion
}
