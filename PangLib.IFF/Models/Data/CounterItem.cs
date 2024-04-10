using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CounterItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        public byte[] Bytes { get; set; }//8 start position
    }
}