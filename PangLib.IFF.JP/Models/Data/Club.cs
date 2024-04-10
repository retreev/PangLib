using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{

    #region Struct Club.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Club : IFFCommon
    {
        public Club(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            MPet = reader.ReadPStr(40);
            ClubType = reader.ReadUInt16(); 
            Power = reader.ReadUInt16();
            Control = reader.ReadUInt16();
            Impact = reader.ReadUInt16();
            Spin = reader.ReadUInt16();
            Curve = reader.ReadUInt16();
        }
        public Club()
        { }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort ClubType { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }

    }
    #endregion

}
