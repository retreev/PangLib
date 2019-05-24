namespace PangLib.PET.Models
{
    /// <summary>
    /// AnimationFlag structure used inside <see cref="PangLib.PET.Models.Animation"/>
    /// </summary>
    public struct AnimationFlag
    {
        /// <summary>
        /// Time in seconds
        /// </summary>
        public float Time { get; set; }
        
        /// <summary>
        /// Value of the flag at <see cref="Time"/>
        /// </summary>
        public float Value { get; set; }
    }
}