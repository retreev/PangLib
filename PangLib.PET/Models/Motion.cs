namespace PangLib.PET.Models
{
    /// <summary>
    /// Base motion structure for Puppet files
    /// </summary>
    public struct Motion
    {
        /// <summary>
        /// Name of the motion
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Start <see cref="PangLib.PET.Models.Frame"/> index
        /// </summary>
        public uint FrameStart { get; set; }
        
        /// <summary>
        /// End <see cref="PangLib.PET.Models.Frame"/> index
        /// </summary>
        public uint FrameEnd { get; set; }
        
        /// <summary>
        /// Target name
        /// </summary>
        public string TargetName { get; set; }
        
        /// <summary>
        /// Type of motion
        /// </summary>
        public string TypeName { get; set; }
        
        /// <summary>
        /// Type identifier
        /// </summary>
        public uint Type { get; set; }
        
        /// <summary>
        /// Name of the <see cref="PangLib.PET.Models.Bone"/> this motion belongs to
        /// </summary>
        public string BoneName { get; set; }
    }
}
