using PangLib.IFF.Models.General;
using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{

    #region Struct Caddie.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Caddie : IFFCommon
    {
        public uint Salary { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x27 + 1)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats Stats { get; set; }
        public ushort Un4 { get; set; }
    }
    #endregion
}
