namespace PangLib.WEP.Models
{
    public struct CameraNode
    {
        public string Name { get; set; }
        public Vector3<float> Position { get; set; }
        public Vector3<float> Destination { get; set; }
        public float FOV { get; set; }
        public float Bank { get; set; }
        public Vector3<float> Position2 { get; set; }
        public Vector3<float> Destination2 { get; set; }
        public ExtraValues ExtraValues { get; set; }
    }
}