namespace PangLib.PET.Models
{
    /// <summary>
    /// Polygon index/point structure used inside <see cref="PangLib.PET.Models.Polygon"/>
    /// </summary>
    public struct PolygonIndex
    {
        /// <summary>
        /// Index of the <see cref="PangLib.PET.Models.Vertex"/> this polygon index belongs to
        /// </summary>
        public uint Index { get; set; }
        
        /// <summary>
        /// X coordinate of this polygon point
        /// </summary>
        public float X { get; set; }
        
        /// <summary>
        /// Y coordinate of this polygon point
        /// </summary>
        public float Y { get; set; }
        
        /// <summary>
        /// Z coordinate of this polygon point
        /// </summary>
        public float Z { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.UVMapping"/> of this polygon index
        /// </summary>
        public UVMapping[] UVMappings { get; set; }
    }
}
