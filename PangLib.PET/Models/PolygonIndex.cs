namespace PangLib.PET.Models
{
    public struct PolygonIndex
    {
        public uint Index { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public UVMapping[] UVMappings { get; set; }
    }
}
