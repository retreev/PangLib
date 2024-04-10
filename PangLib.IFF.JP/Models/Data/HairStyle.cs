using PangLib.IFF.JP.Models.General;
using PangLib.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct HairStyle.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class HairStyle : IFFCommon
    {
        public byte Color { get; set; }
        public CharTypeByHairColor Character { get; set; }
        public ushort Blank { get; set; }
    }
    #endregion
}
