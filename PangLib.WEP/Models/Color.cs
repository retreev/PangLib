using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    /// <summary>
    /// Base color type
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// Color values
        /// </summary>
        public List<int> Values { get; set; }
    }

    /// <summary>
    /// Color values for puppet models
    /// </summary>
    public struct VertexColorMap
    {
        /// <summary>
        /// Puppet model name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// List of color values
        /// </summary>
        public List<Color> Colors { get; set; }
    }
}