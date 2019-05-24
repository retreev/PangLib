using System.Collections.Generic;

namespace PangLib.PET.Models
{
    /// <summary>
    /// Vertex structure used inside <see cref="PangLib.PET.Models.Mesh"/>
    /// </summary>
    public class Vertex
    {
        /// <summary>
        /// X coordinate of the vertex
        /// </summary>
        public float X { get; set; }
        
        /// <summary>
        /// Y coordinate of the vertex
        /// </summary>
        public float Y { get; set; }
        
        /// <summary>
        /// Z coordinate of the vertex
        /// </summary>
        public float Z { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.BoneInformation"/> tied to this vertex
        /// </summary>
        public List<BoneInformation> BoneInformation { get; set; }
    }
}
