using PangLib.IFF.Models.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.Models.Data
{
    #region Struct MemorialShopCoinItem.sff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class MemorialShopCoinItem
    {
        public uint Enable { get; set; }//4
        public uint TypeID { get; set; }//8
        public FilterCoinType CoinType { get; set; }//0 normal//12
        public uint Probabilities { get; set; }//16
        public uint Number { get; set; }//20
        public uint NumberMax { get; set; }//24
        public FilterType ItemType { get; set; }//9-28
        public uint Sex { get; set; }//Count??8-32
        public uint Value_1 { get; set; }//7-36
        public uint Item { get; set; }//6-40
        public uint CharacterType { get; set; }//5-44
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] filter { get; set; }
        public bool empty()
        {
            return (Number == 0 && NumberMax == 0);
        }
      public  bool isBetweenGacha(uint _number)
        {
            return (Number <= _number && _number <= NumberMax);
        }
        public bool hasFilter(int _filter)
        {
            var New_filter = new int[] { (int)ItemType, (int)Sex, (int)Value_1, (int)Item, (int)CharacterType, filter[0], filter[1], filter[2], filter[3], filter[4], };
            if (_filter == 0)
                return false;

            for (var i = 0u; i < 10; ++i)
                if (New_filter[i] == _filter)
                    return true;

            return false;
        }
        public bool emptyFilter()
        {
            var New_filter = new int[] { (int)ItemType, (int)Sex, (int)Value_1, (int)Item, (int)CharacterType, filter[0], filter[1], filter[2], filter[3], filter[4], };
            int count = 0;

            for (var i = 0u; i < 10; ++i)
                count += New_filter[i];

            return count == 0;
        }
    }
    #endregion

}
