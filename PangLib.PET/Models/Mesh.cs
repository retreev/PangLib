namespace PangLib.PET.Models
{
    public struct Mesh
    {
        public Vertex[] Vertices { get; set; }
        public Polygon[] Polygons { get; set; }
        public uint[] TextureMap { get; set; }
    }
}