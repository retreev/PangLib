using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{

    #region Struct Club.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Club : IFFCommon
    {
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
