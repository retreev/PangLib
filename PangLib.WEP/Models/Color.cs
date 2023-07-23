using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    public struct Color
    {
        public List<int> Values { get; set; }
    }

    public struct VertexColorMap
    {
        public string Name { get; set; }
        public List<Color> Colors { get; set; }
    }
}