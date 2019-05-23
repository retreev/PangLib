namespace PangLib.PET.Models
{
    public struct Animation
    {
        public byte BoneID { get; set; }
        public PositionData[] PositionData { get; set; }
        public uint Unknown1 { get; set; }
        public RotationData[] RotationData { get; set; }
        public ScalingData[] ScalingData { get; set; }
        public AnimationFlag[] AnimationFlags { get; set; }
    }
}