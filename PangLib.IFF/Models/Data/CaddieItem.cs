using PangLib.IFF.Models.General;
using PangLib.IFF.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{

    #region Struct CaddieItem.iff
    enum CaddieType : byte {
				COOKIE,		// CASH
				PANG,		// PANG
				ESPECIAL,	// ACHO, por que não tem nenhum item com esse, não vi pelo menos
				UPGRADE
}
[StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CaddieItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TexTure { get; set; }
        public UInt16 Price1Day { get; set; }
        public UInt16 Price7Day { get; set; }
        public UInt16 Price15Day { get; set; }
        public UInt16 Price30Day { get; set; }
        public uint unit_power_guage_start { get; set; }
    }
    #endregion

}
