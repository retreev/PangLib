using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct CutinInformation.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CutinInformation
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public uint Seq { get; set; }
        public uint Sector { get; set; }
        public uint Num1 { get; set; }
        public uint Num2 { get; set; }
        public uint NumImg1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG1 { get; set; }
        public uint NumImg2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG2{ get; set; }
        public uint NumImg3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string IMG3;
        public uint Time { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 41)]
        public byte[] UN { get; set; }
        public uint Num4 { get; set; }
    }
    #endregion
}
