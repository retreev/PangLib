using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.JP.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
    public class IFFStats
    {
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 10)]
    public class IFFSlotStats 
    {
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }// { get => this.Control; set => this.Control = value; }
        public ushort ImpactSlot { get; set; }//{ get => this.Impact; set => this.Impact = value; }
        public ushort SpinSlot { get; set; }//{ get => this.Spin; set => this.Spin = value; }
        public ushort CurveSlot { get; set; }//{ get => this.Curve; set => this.Curve = value; }
    }
}
