using System.Collections.Generic;

namespace PangLib.WEP.Models
{
    public struct NodeList
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Type { get; set; }
        public List<Vector3<float>> Vectors { get; set; }
    }
}