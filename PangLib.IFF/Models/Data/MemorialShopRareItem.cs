using PangLib.IFF.Models.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.Models.Data
{
    #region Struct MemorialRareItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class MemorialShopRareItem
    {
        public uint Enabled { get; set; }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public class Gacha
        {
            public uint Number { get; set; }
            public uint Count { get; set; }
        }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 8)]
        public Gacha gacha { get; set; }
        public uint TypeID { get; set; }
        public uint Probabilities { get; set; }
        public MemorialRareType RareType { get; set; }// Tipo Raro, EX: -1 - 0 normal, 1 - 2 raro, 3 - 4 Super raro
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] filter { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]//28 se for byte
        public string Version { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]//28 se for byte
        public int[] Null_Bytes { get; set; }
        public MemorialShopRareItem New()
        {
            filter = new int[5];
            Version = "S99";
            Null_Bytes = new int[6];
            return this;
        }
      
        public FilterType GetItemType(string type)
        {
            switch (type)
            {
                case "SPRING":
                    return FilterType.SPRING;
                case "SUMMER":
                    return FilterType.SUMMER;
                case "FALL":
                    return FilterType.FALL;
                case "WINTER":
                    return FilterType.WINTER;
                case "CLUBSET":
                    return FilterType.CLUBSET;
                case "SETITEM":
                    return FilterType.SETITEM;
                case "EAR":
                    return FilterType.EAR;
                case "WING":
                    return FilterType.WING;
                case "LUVA":
                    return FilterType.LUVA;
                case "RING_R":
                    return FilterType.RING_R;
                case "RING_L":
                    return FilterType.RING_L;
                case "CADDIE":
                    return FilterType.CADDIE;
                case "MASCOT":
                    return FilterType.MASCOT;
                case "SUMMER_HOLYDAY":
                    return FilterType.SUMMER_HOLYDAY;
                case "XMAS":
                    return FilterType.XMAS;
                case "HALLOWEEN":
                    return FilterType.HALLOWEEN;
                case "MAN":
                    return FilterType.MAN;
                case "WOMAN":
                    return FilterType.WOMAN;
                case "NURI":
                    return FilterType.NURI;
                case "HANA":
                    return FilterType.HANA;
                case "AZER":
                    return FilterType.AZER;
                case "CECI":
                    return FilterType.CECI;
                case "MAX":
                    return FilterType.MAX;
                case "KOOH":
                    return FilterType.KOOH;
                case "ARIN":
                    return FilterType.ARIN;
                case "KAZ":
                    return FilterType.KAZ;
                case "LUCIA":
                    return FilterType.LUCIA;
                case "NELL":
                    return FilterType.NELL;
                case "SPIKA":
                    return FilterType.SPIKA;
                case "NURI_R":
                    return FilterType.NURI_R;
                case "HANA_R":
                    return FilterType.HANA_R;
                case "AZER_R":
                    return FilterType.AZER_R;
                case "CECI_R":
                    return FilterType.CECI_R;
                default:
                    break;
            }
            return 0;
        }

        public MemorialRareType GetMemorialRareType(string type)
        {
            switch (type)
            {
                case "Default":
                    return MemorialRareType.Default;
                case "Normal":
                    return MemorialRareType.Normal_Rare0;
                case "NRare":
                    return MemorialRareType.Normal_Rare1;
                case "NRare2":
                    return MemorialRareType.Normal_Rare2;
                case "SR1":
                    return MemorialRareType.Super_Rare1;
                case "SR2":
                    return MemorialRareType.Super_Rare2;
                default:
                    break;
            }
            return 0;
        }


    }
    #endregion
}
