namespace PangLib.PET.Models
{
    public struct CollisionBox
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public string Name { get; set; }
        public string BoneName { get; set; }
        public byte Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public float MinX { get; set; }
        public float MinY { get; set; }
        public float MinZ { get; set; }
        public float MaxX { get; set; }
        public float MaxY { get; set; }
        public float MaxZ { get; set; }
    }
}
