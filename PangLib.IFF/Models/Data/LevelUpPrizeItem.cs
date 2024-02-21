using PangLib.IFF.Models.General;
using PangLib.IFF.Models.Flags;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.Models.Data
{



    #region Struct LevelUpItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class LevelUpPrizeItem
    {
        public byte Active { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        byte[] NameInBytes { get; set; }//8 start position
        public string Name { get => Encoding.UTF7.GetString(NameInBytes); set => NameInBytes = Encoding.UTF7.GetBytes(value.PadRight(33, '\0')); }

        public ushort Level { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Quantity;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Time;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        byte[] DescriptionInBytes { get; set; }//8 start position
        public string Description { get => Encoding.UTF7.GetString(DescriptionInBytes); set => DescriptionInBytes = Encoding.UTF7.GetBytes(value.PadRight(132, '\0')); }

    }
    #endregion

}
