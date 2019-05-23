using System.Collections.Generic;

namespace PangLib.PET.Models
{
    public struct Animation
    {
        public byte BoneID;
        public List<PositionData> PositionData;
        public uint Unknown1;
        public List<RotationData> RotationData;
        public List<ScalingData> ScalingData;
        public List<AnimationFlag> AnimationFlags;
    }
}