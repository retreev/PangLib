using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    /// <summary>
    /// Point coordinate structure
    /// </summary>
    public struct Point
    {
        /// <summary>
        /// X coordinate value
        /// </summary>
        public float X;
        
        /// <summary>
        /// Z coordinate value
        /// </summary>
        public float Z;
    }
    
    /// <summary>
    /// Map check structure
    /// </summary>
    public struct MapCheck
    {
        /// <summary>
        /// Par count of the current hole
        /// </summary>
        public byte Par { get; set; }
        
        /// <summary>
        /// Tee type
        /// </summary>
        public List<Point> TeeType { get; set; }
        
        /// <summary>
        /// Pin type 1
        /// </summary>
        public List<Point> PinType1 { get; set; }
        
        /// <summary>
        /// Pin type 2
        /// </summary>
        public List<Point> PinType2 { get; set; }
    }
}