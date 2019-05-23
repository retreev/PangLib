using System.Collections.Generic;
using System.IO;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers
{
    public class AnimationReader
    {
        public static List<Animation> ReadAllAnimations(BinaryReader sectionReader, Version version)
        {
            List<Animation> Animations = new List<Animation>();

            while (sectionReader.BaseStream.Position < sectionReader.BaseStream.Length)
            {
                Animation animation = new Animation();

                animation.BoneID = sectionReader.ReadByte();

                if (animation.BoneID == 255)
                    break;

                uint positionDataCount = sectionReader.ReadUInt32();
                animation.PositionData = new List<PositionData>();

                for (int i = 0; i < positionDataCount; i++)
                {
                    PositionData positionData = new PositionData() {
                        Time = sectionReader.ReadSingle(),
                        X = sectionReader.ReadSingle(),
                        Y = sectionReader.ReadSingle(),
                        Z = sectionReader.ReadSingle(),
                    };

                    animation.PositionData.Add(positionData);
                }

                uint rotationDataCount = sectionReader.ReadUInt32();
                animation.RotationData = new List<RotationData>();

                if (version.Minor == 0)
                {
                    // TODO: Check if this is an unknown value or just padding
                    animation.Unknown1 = sectionReader.ReadUInt32();
                }

                for (int i = 0; i < rotationDataCount; i++)
                {
                    RotationData rotationData;

                    if (version.Minor >= 2)
                    {
                        rotationData = new RotationData() {
                            Time = sectionReader.ReadSingle(),
                            X = sectionReader.ReadSingle(),
                            Y = sectionReader.ReadSingle(),
                            Z = sectionReader.ReadSingle(),
                            W = sectionReader.ReadSingle()
                        };
                    }
                    else {
                        rotationData = new RotationData() {
                            X = sectionReader.ReadSingle(),
                            Y = sectionReader.ReadSingle(),
                            Z = sectionReader.ReadSingle(),
                            W = sectionReader.ReadSingle(),
                            Time = sectionReader.ReadSingle()
                        };
                    }
                    animation.RotationData.Add(rotationData);
                }

                if (version.Minor >= 2)
                {
                    uint scalingDataCount = sectionReader.ReadUInt32();
                    animation.ScalingData = new List<ScalingData>();

                    for (int i = 0; i < scalingDataCount; i++)
                    {
                        ScalingData scalingData = new ScalingData() {
                            Time = sectionReader.ReadSingle(),
                            X = sectionReader.ReadSingle(),
                            Y = sectionReader.ReadSingle(),
                            Z = sectionReader.ReadSingle()
                        };

                        animation.ScalingData.Add(scalingData);
                    }
                }

                if (version.Minor >= 3)
                {
                    uint animationFlagCount = sectionReader.ReadUInt32();
                    animation.AnimationFlags = new List<AnimationFlag>();

                    for (int i = 0; i < animationFlagCount; i++)
                    {
                        AnimationFlag animationFlag = new AnimationFlag() {
                            Time = sectionReader.ReadSingle(),
                            Value = sectionReader.ReadSingle()
                        };

                        animation.AnimationFlags.Add(animationFlag);
                    }
                }

                Animations.Add(animation);
            }

            return Animations;
        }
    }
}