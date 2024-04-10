using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.JP.Models.Data
{

    #region Struct Desc.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Desc
    {
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        byte[] DescriptionInBytes { get; set; }//4 start position
        public string Description { get => Encoding.GetEncoding("Shift_JIS").GetString(DescriptionInBytes).Replace("\0", ""); set => DescriptionInBytes = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(512, '\0')); }

    }
    #endregion

}
