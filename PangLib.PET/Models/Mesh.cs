namespace PangLib.PET.Models
{
    /// <summary>
    /// Base mesh structure for Puppet files
    /// </summary>
    public struct Mesh
    {
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Vertex"/> making up this mesh
        /// </summary>
        public Vertex[] Vertices { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Polygon"/> making up this mesh
        /// </summary>
        public Polygon[] Polygons { get; set; }
        
        /// <summary>
        /// Texture mapping of <see cref="Polygons"/> to <see cref="PangLib.PET.Models.Texture"/>
        /// </summary>
        public uint[] TextureMap { get; set; }
    }
}