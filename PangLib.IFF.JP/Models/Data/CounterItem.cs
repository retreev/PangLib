using PangLib.IFF.JP.Models.General;
using System.Runtime.InteropServices;

namespace PangLib.IFF.JP.Models.Data
{

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CounterItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        public byte[] Bytes { get; set; }//8 start position
    }
}