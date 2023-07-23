using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    public struct Point
    {
        public float X;
        public float Z;
    }
    
    public struct MapCheck
    {
        public byte Par { get; set; }
        public List<Point> TeeType { get; set; }
        public List<Point> PinType1 { get; set; }
        public List<Point> PinType2 { get; set; }
    }
}