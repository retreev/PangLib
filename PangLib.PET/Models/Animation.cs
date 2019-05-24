namespace PangLib.PET.Models
{
    /// <summary>
    /// Base animation structure for Puppet files
    /// </summary>
    public struct Animation
    {
        /// <summary>
        /// ID of the <see cref="PangLib.PET.Models.Bone"/> being animated
        /// </summary>
        public byte BoneID { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.PositionData"/> of this animation
        /// </summary>
        public PositionData[] PositionData { get; set; }
        
        /// <summary>
        /// Unknown value
        /// </summary>
        public uint Unknown1 { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.RotationData"/> of this animation
        /// </summary>
        public RotationData[] RotationData { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.ScalingData"/> of this animation
        /// </summary>
        public ScalingData[] ScalingData { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.AnimationFlag"/> of this animation
        /// </summary>
        public AnimationFlag[] AnimationFlags { get; set; }
    }
}