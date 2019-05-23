using System.Collections.Generic;

namespace PangLib.PET.Models
{
    public struct PolygonIndex
    {
        public uint Index;
        public float X;
        public float Y;
        public float Z;
        public List<UVMapping> UVMappings;
    }
}
