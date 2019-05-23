using System.Collections.Generic;

namespace PangLib.PET.Models
{
    public struct Animation
    {
        public byte BoneID;
        public PositionData[] PositionData;
        public uint Unknown1;
        public RotationData[] RotationData;
        public ScalingData[] ScalingData;
        public AnimationFlag[] AnimationFlags;
    }
}