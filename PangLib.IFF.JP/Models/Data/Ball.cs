using PangLib.IFF.JP.Models.General;
using PangLib.IFF.JP.Models.Flags;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct Ball.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ball : IFFCommon
    {
        public uint Unknown0 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Model;
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx1;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx2;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx3;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx4;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx5;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx6;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx7;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx8;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx9;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx10;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx11;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx12;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx13;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string BallFx14;
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Unknown4 { get; set; }
    }
#endregion

}
