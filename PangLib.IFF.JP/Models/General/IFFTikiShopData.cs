using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.JP.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 24)]
    public class IFFTikiShopData
    {
        public IFFTikiShopData()
        {
            Bonus = new short[2];
        }
        public bool IsActived()
        {
            return (Type_TikiShop == 1u || Type_TikiShop == 2u || Type_TikiShop == 3u) && Tiki_Pang > 0u && Mileage_Pts > 0u;
        }

        public uint Tiki_Qnt_Pts { get; set; }//132 start position,4
        public uint Tiki_Pts { get; set; }// 136 positon,8
        public ushort Mileage_Pts { get; set; }// 140 start position,10
        public ushort Bonus_Prob { get; set; }// 142 start position,12
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] Bonus { get; set; }// (bonus[0] min_bonus, bonus[1] max_bonus)144 start position,16 
        public uint Type_TikiShop { get; set; }// 148 start position,20
        public uint Tiki_Pang { get; set; }// 152 start position,24
    }
}
