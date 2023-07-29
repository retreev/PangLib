namespace PangLib.WEP.Models
{
    /// <summary>
    /// Base matrix type
    ///
    /// NOTE: This is most likely used incorrectly and just contains multiple unknown values.
    /// </summary>
    public struct Matrix
    {
        /// <summary>
        /// First column in the Matrix
        /// </summary>
        public Vector3<float> Column1 { get; set; }
        
        /// <summary>
        /// Second column in the Matrix
        /// </summary>
        public Vector3<float> Column2 { get; set; }
        
        /// <summary>
        /// Third column in the Matrix
        /// </summary>
        public Vector3<float> Column3 { get; set; }
        
        /// <summary>
        /// Fourth column in the Matrix
        /// </summary>
        public Vector3<float> Column4 { get; set; }
    }
}