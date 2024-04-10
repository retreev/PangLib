using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.JP.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class IFFPrice
    {
        public ushort Price1Day { get; set; }
        public ushort Price7Day { get; set; }
        public ushort Price15Day { get; set; }
        public ushort Price30Day { get; set; }
        public ushort Price365Day { get; set; }
    }
}
