using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Mascot.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Mascot : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1 { get; set; }
        public ushort Price1Day { get; set; }
        public ushort Price7Day { get; set; }
        public ushort Price15Day { get; set; }
        public ushort PriceUnknownDay { get; set; }
        public ushort Price30Day { get; set; }
        public byte Power { get; set; }
        public byte Control { get; set; }
        public byte Impact { get; set; }
        public byte Spin { get; set; }
        public byte Curve { get; set; }
        public byte Power_Drive { get; set; }
        public byte Drop_Rate { get; set; }
        public byte Power_Gauge { get; set; }
        public byte Pang_Rate { get; set; }
        public byte Exp_Rate { get; set; }
        public byte ItemSlot { get; set; }
        public ushort Active_Message { get; set; }
        public ushort Flag_Message { get; set; }
        public uint Change_Price { get; set; }
        public ushort Bonus_Pang { get; set; }
        public ushort Bonus_Flag { get; set; }
        public ushort GetDay()
        {
            return 7;
        }
    }
    #endregion

}
