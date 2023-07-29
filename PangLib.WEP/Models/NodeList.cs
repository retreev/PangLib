using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    /// <summary>
    /// Node list structure
    /// </summary>
    public struct NodeList
    {
        /// <summary>
        /// Name of the node list
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Count of vectors in this node list
        /// </summary>
        public int Length { get; set; }
        
        /// <summary>
        /// Type of node list
        /// </summary>
        public int Type { get; set; }
        
        /// <summary>
        /// List of vectors in this node list
        /// </summary>
        public List<Vector3<float>> Vectors { get; set; }
    }
}