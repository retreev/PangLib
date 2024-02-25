using PangLib.IFF.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Item.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Item : IFFCommon
    {
        public uint ItemType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        // Aqui é o No Limit time preço, mas quando compra ele passa o preço de -1, mas no visual ele mostra o valor que está aqui
        public ushort Un1 { get; set; }
    }
    public enum TypeItem: uint
    {
        Active = 0,
        consumable = 1,
        Passive = 128,
        GM = 252,
    }
    #endregion
}