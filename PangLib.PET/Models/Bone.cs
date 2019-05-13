namespace PangLib.PET.Models
{
    /// <summary>
    /// Base bone structure for Puppet files
    /// </summary>
    public struct Bone
    {
        /// <summary>
        /// Name of the bone
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// ID of the parent bone
        /// </summary>
        /// <remarks>
        /// If this ID is 255 the bone is a root bone
        /// </remarks>
        public byte Parent { get; set; }
        
        /// <summary>
        /// Perspective projection matrix of the bone
        /// </summary>
        public float[] Matrix { get; set; }
        
        /// <summary>
        /// Unknown value present in version 1.3 files
        /// </summary>
        public float Unknown1 { get; set; }
    }
}
