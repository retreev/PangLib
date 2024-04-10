using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.JP.Models.Data
{
    #region Struct GrandPrixSpecialHole.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GrandPrixSpecialHole
    {
        public UInt32 Enable { get; set; }
        public UInt32 TypeID { get; set; }
        public UInt32 HolePOS { get; set; }
        public UInt32 Map { get; set; }
        public UInt32 Hole { get; set; }
    }
    #endregion
}
