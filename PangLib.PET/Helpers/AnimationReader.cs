using System.Collections.Generic;
using System.IO;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    public class AnimationReader
    {
        public static List<Animation> ReadAllAnimations(BinaryReader sectionReader)
        {
            List<Animation> Animations = new List<Animation>();

            while (sectionReader.BaseStream.Position < sectionReader.BaseStream.Length)
            {
                Animation animation = new Animation();

                animation.BoneID = sectionReader.ReadByte();

                if (animation.BoneID == 255)
                    break;

                uint positionDataCount = sectionReader.ReadUInt32();

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
                animation.Unknown1 = sectionReader.ReadUInt32();

                for (int i = 0; i < rotationDataCount; i++)
                {
                    RotationData rotationData = new RotationData() {
                        X = sectionReader.ReadSingle(),
                        Y = sectionReader.ReadSingle(),
                        Z = sectionReader.ReadSingle(),
                        W = sectionReader.ReadSingle(),
                        Time = sectionReader.ReadSingle()
                    };

                    animation.RotationData.Add(rotationData);
                }

                Animations.Add(animation);
            }

            return Animations;
        }
    }
}