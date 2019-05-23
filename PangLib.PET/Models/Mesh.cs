using System.Collections.Generic;

namespace PangLib.PET.Models
{
    public struct Mesh
    {
        public List<Vertex> Vertices;
        public List<Polygon> Polygons;
        public uint[] TextureMap;
    }
}