using PangLib.IFF.Models.General;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    /// <summary>
    /// Is Struct file CadieMagicBoxRandom.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CadieMagicBoxRandom
    {
        public uint Index { get; set; }
        public uint TypeID { get; set; }

        public uint Qty { get; set; }

        public uint Rate { get; set; }
    }
}
