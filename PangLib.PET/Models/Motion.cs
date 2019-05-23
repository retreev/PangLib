namespace PangLib.PET.Models
{
    public struct Motion
    {
        public string Name { get; set; }
        public uint FrameStart { get; set; }
        public uint FrameEnd { get; set; }
        public string TargetName { get; set; }
        public string TypeName { get; set; }
        public uint Type { get; set; }
        public string BoneName { get; set; }
    }
}
