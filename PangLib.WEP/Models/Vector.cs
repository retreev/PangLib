namespace PangLib.WEP.Models
{
    /// <summary>
    /// Base vector type
    /// </summary>
    /// <typeparam name="T">Number type</typeparam>
    public struct Vector3<T>
    {
        /// <summary>
        /// X coordinate value
        /// </summary>
        public T X { get; set; }
        
        /// <summary>
        /// Y coordinate value
        /// </summary>
        public T Y { get; set; }
        
        /// <summary>
        /// Z coordinate value
        /// </summary>
        
        public T Z { get; set; }
    }
}