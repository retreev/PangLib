namespace PangLib.WEP.Models
{
    /// <summary>
    /// Base area type
    /// </summary>
    public struct Area
    {
        /// <summary>
        /// Minimum area coordinate
        /// </summary>
        public Vector3<float> Min { get; set; }
        
        /// <summary>
        /// Maximum area coordinate
        /// </summary>
        public Vector3<float> Max { get; set; }
    }
}