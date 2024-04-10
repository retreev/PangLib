using PangLib.IFF.Models.Flags;
using PangLib.IFF.Models.General;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.Models.Data
{
    #region Struct Part.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Part : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public PartType type_item { get; set; }// o tipo do item, 0, 2 normal, 8 e 9 UCC, 5 acho que é base ou commom Item
        public uint PosMask { get; set; }
        public uint HideMask { get; set; }
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
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats Stats { get; set; }
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFSlotStats SlotStats { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        byte[] _EquippableWith { get; set; }
        public string EquippableWith
        {
            get => Encoding.UTF7.GetString(_EquippableWith).Replace("\0", "");
            set => _EquippableWith = Encoding.UTF7.GetBytes(value.PadRight(64, '\0'));
        }
        public uint SubPart1 { get; set; }
        public uint SubPart2 { get; set; }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class CardSlot
        {
            public ushort CharSlot { get; set; }//Bonus Char Slot
            public ushort CaddieSlot { get; set; }//Bonus Card Slot
        }
        [field: MarshalAs(UnmanagedType.Struct)]
        public CardSlot _CardSlot { get; set; }
        public uint Points { get; set; }//mastery points?
        public uint RentPang { get; set; }
        public uint Un1 { get; set; }
        public uint EquipmentCategory { get => Convert.ToUInt32(type_item); set => type_item = (PartType)value; }
        public uint CharacterType => (uint)((ID & 0x3fc0000) / Math.Pow(2.0, 18.0));
        public ushort Character_Raw => (ushort)(((double)(ID & 0x3fc0000)) / Math.Pow(2.0, 18.0));

        public int getPersonagemNome() => (int)CharacterType;
        public object newTypeid(object charSerial, object Pos, object Group, object Type, object serial)
        {
            int num = 0;
            try
            {
                num = (int)(2.0 * Math.Pow(2.0, 26.0) +
                            (double)charSerial * Math.Pow(2.0, 18.0) +
                            (double)Pos * Math.Pow(2.0, 13.0) +
                            (double)Group * Math.Pow(2.0, 11.0) +
                            (double)Type * Math.Pow(2.0, 9.0) +
                            (double)serial);
            }
            catch (Exception)
            {
                num = 0;
            }
            return num;
        }

    }
    #endregion
}
