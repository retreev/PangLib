using PangLib.IFF.JP.Models.General;
using PangLib.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
using PangLib.IFF.JP.Extensions;
using System.Globalization;

namespace PangLib.IFF.JP.Models.Data
{

    #region Struct CaddieItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CaddieItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TexTure { get; set; }
        public UInt16 Price1Day { get; set; }
        public UInt16 Price7Day { get; set; }
        public UInt16 Price15Day { get; set; }
        public UInt16 Price30Day { get; set; }
        public UInt32 FlagRoll { get; set; }
        public CaddieItem(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            MPet = reader.ReadPStr(40);
            TexTure = reader.ReadPStr(40);
            Price1Day = reader.ReadUInt16();
            Price7Day = reader.ReadUInt16();
            Price15Day = reader.ReadUInt16();
            Price30Day = reader.ReadUInt16();
            FlagRoll = reader.ReadUInt32();

        }
        public CaddieItem()
        { }
    }
    #endregion

}
