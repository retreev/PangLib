using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{


    #region Struct Item.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Item : IFFCommon
    {
        public uint ItemType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]

        public string Texture { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Unkown { get; set; }
        public Item(PangyaBinaryReader reader, uint len)
        {
            Load(ref reader, 40);
            ItemType = reader.ReadUInt32();
            Texture = reader.ReadPStr(40);
            Power = reader.ReadUInt16();
            Control = reader.ReadUInt16();
            Accuracy = reader.ReadUInt16();
            Spin = reader.ReadUInt16();
            Curve = reader.ReadUInt16();
            Unkown = reader.ReadUInt16();
        }
        public Item()
        {
        }
    }
    #endregion
}