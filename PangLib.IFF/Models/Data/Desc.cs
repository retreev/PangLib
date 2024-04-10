using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.Models.Data
{

    #region Struct Desc.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Desc
    {
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        byte[] DescriptionInBytes { get; set; }//4 start position
        public string Description 
        {
            get
            {
              return  Encoding.UTF7.GetString(DescriptionInBytes).Replace("\0", "");
            }
            set 
            {

                DescriptionInBytes = new byte[512];
                Buffer.BlockCopy(Encoding.UTF7.GetBytes(value), 0, DescriptionInBytes, 0, Math.Min(value.Length, 512));
            }
        }

    }
    #endregion

}
