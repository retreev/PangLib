using PangLib.IFF.Models.General;
using PangLib.IFF.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Skin.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Skin : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort Flag_Roll { get; set; }
        public ushort Price1Day { get; set; }
        public ushort Price7Day { get; set; }
        public ushort Price15Day { get; set; }
        public ushort Price30Day { get; set; }
        public ushort Price365Day { get; set; }
    }
    #endregion

}
