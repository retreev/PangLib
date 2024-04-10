using PangLib.IFF.JP.Models.General;
using PangLib.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
using PangLib.IFF.JP.Extensions;

namespace PangLib.IFF.JP.Models.Data
{
    #region Struct Card.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Card : IFFCommon
    {
        public byte Rarity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public CardEffectFlag Effect { get; set; }
        public UInt16 EffectValue { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture3 { get; set; }
        public ushort EffectTime { get; set; }
        public ushort Volumn { get; set; }
        public UInt32 Position { get; set; }
        public UInt32 flag1 { get; set; }     // !@flag que guarda alguns valores de de N, R, SR, SC e etc
        public UInt32 flag2 { get; set; }       // flag que guarda alguns valores de de N, R, SR, SC e etc
        public Card()
        { }

        public Card(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            Rarity = reader.ReadByte();
            MPet = reader.ReadPStr(40);
            PowerSlot = reader.ReadUInt16();
            ControlSlot = reader.ReadUInt16();
            AccuracySlot = reader.ReadUInt16();
            SpinSlot = reader.ReadUInt16();
            CurveSlot = reader.ReadUInt16();
            Effect = (CardEffectFlag)reader.ReadUInt16();
            EffectValue = reader.ReadUInt16();
            AdditionalTexture1 = reader.ReadPStr(40);
            AdditionalTexture2 = reader.ReadPStr(40);
            AdditionalTexture3 = reader.ReadPStr(40);
            EffectTime = reader.ReadUInt16();
            Volumn = reader.ReadUInt16();
            Position = reader.ReadUInt32();
            flag1 = reader.ReadUInt32();
            flag2 = reader.ReadUInt32();
        }
    
    }
    #endregion
}
