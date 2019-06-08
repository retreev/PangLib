namespace PangLib.PET.Models
{
    /// <summary>
    /// Base collision box structure for Puppet files
    /// </summary>
    public struct CollisionBox
    {
        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown1 { get; set; }
        
        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown2 { get; set; }
        
        /// <summary>
        /// Name of the collision box
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Name of the <see cref="PangLib.PET.Models.Bone"/> this collision box is attached to
        /// </summary>
        public string BoneName { get; set; }
        
        /// <summary>
        /// Script executed on this collision box
        /// </summary>
        public string Script { get; set; }
        
        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown3 { get; set; }
        
        /// <summary>
        /// Minimal X coordinate
        /// </summary>
        public float MinX { get; set; }
        
        /// <summary>
        /// Minimal Y coordinate
        /// </summary>
        public float MinY { get; set; }
        
        /// <summary>
        /// Minimal Z coordinate
        /// </summary>
        public float MinZ { get; set; }
        
        /// <summary>
        /// Maximal X coordinate
        /// </summary>
        public float MaxX { get; set; }
        
        /// <summary>
        /// Maximal Y coordinate
        /// </summary>
        public float MaxY { get; set; }
        
        /// <summary>
        /// Maximal Z coordinate
        /// </summary>
        public float MaxZ { get; set; }
    }
}
