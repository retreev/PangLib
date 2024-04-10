using PangLib.IFF.Models.General;
using System;
using System.Runtime.InteropServices;
using PangLib.IFF.Models.Flags;
namespace PangLib.IFF.Models.Data
{
    #region Struct SetItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetItem : IFFCommon
    {
        public uint Total { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public ushort[] Item_Qty { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats Stats { get; set; }
        public TypeSetFlag SetType { get; set; }       
        public string GetQntSet(int idx)
        {
            return  Convert.ToString(Item_Qty[idx]);//retorna 1 por causa do set item
        }

        public void SetQntSet(int idx, string text)
        {
            Item_Qty[idx] = ushort.Parse(text);
        }
    }
    #endregion

}
