namespace PangLib.WEP.Models
{
    public enum PointNodeType : byte
    {
        Start = 0,
        Light = 1,
        Sun = 2,
        Sequence = 3
    }

    public struct PointNode
    {
        public PointNodeType Type { get; set; }
        public string Name { get; set; }
        public Vector3<float> Position { get; set; }
        public string Data { get; set; }
        public Vector3<float> Position2 { get; set; }
        public ExtraValues ExtraValues { get; set; }
    }
}