namespace PangLib.WEP.Models
{
    public struct CameraNode
    {
        /// <summary>
        /// Name of the camera
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Position of the camera
        /// </summary>
        public Vector3<float> Position { get; set; }
        
        /// <summary>
        /// Destination of the camera
        /// </summary>
        public Vector3<float> Destination { get; set; }
        
        /// <summary>
        /// FOV of the camera
        /// </summary>
        public float FOV { get; set; }
        
        /// <summary>
        /// Camera bank value
        /// </summary>
        public float Bank { get; set; }
        
        /// <summary>
        /// Second position of the camera
        /// </summary>
        public Vector3<float> Position2 { get; set; }
                
        /// <summary>
        /// Second destination of the camera
        /// </summary>
        public Vector3<float> Destination2 { get; set; }
                
        /// <summary>
        /// Extra values section
        /// </summary>
        public ExtraValues ExtraValues { get; set; }
    }
}