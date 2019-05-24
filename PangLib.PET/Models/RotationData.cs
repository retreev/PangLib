namespace PangLib.PET.Models
{
    /// <summary>
    /// Rotational data used inside <see cref="PangLib.PET.Models.Animation"/>, determining rotation changes
    /// </summary>
    /// <remarks>
    /// The structure and maths for rotations in Pangya are based around Quaternions
    /// </remarks>
    public struct RotationData
    {
        /// <summary>
        /// Time in seconds
        /// </summary>
        public float Time { get; set; }
        
        /// <summary>
        /// X coordinate of the rotation axis at <see cref="Time"/>
        /// </summary>
        public float X { get; set; }
        
        /// <summary>
        /// Y coordinate of the rotation axis at <see cref="Time"/>
        /// </summary>
        public float Y { get; set; }
        
        /// <summary>
        /// Z coordinate of the rotation axis at <see cref="Time"/>
        /// </summary>
        public float Z { get; set; }
        
        /// <summary>
        /// Scalar value for rotation around the X/Y/Z-axis at <see cref="Time"/>
        /// </summary>
        public float W { get; set; }
    }
}