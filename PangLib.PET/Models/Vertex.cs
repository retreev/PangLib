using System.Collections.Generic;

namespace PangLib.PET.Models
{
    public class Vertex
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public List<BoneInformation> BoneInformation { get; set; }
    }
}
