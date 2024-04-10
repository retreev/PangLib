using PangLib.IFF.JP.Models.Flags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.JP.Models.Data
{
    #region Struct MemorialShopCoinItem.sff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class MemorialShopCoinItem
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public FilterCoinType CoinType { get; set; }//0 normal
        public uint Probabilities { get; set; }
        public uint Number { get; set; }
        public uint NumberMax { get; set; }
        public FilterType ItemType { get; set; }
        public uint Sex { get; set; }//Count??
        public uint Value_1 { get; set; }
        public uint Item { get; set; }
        public uint CharacterType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public byte[] UN;
    }
    #endregion

}
