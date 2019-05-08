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

                uint animPropertyCount = sectionReader.ReadUInt32();

                for (int i = 0; i < animPropertyCount; i++)
                {
                    AnimationProperty animProperty = new AnimationProperty();

                    animProperty.Time = sectionReader.ReadSingle();
                    animProperty.Position = new float[3];

                    for (int j = 0; j < 3; j++)
                    {
                        animProperty.Position[j] = sectionReader.ReadSingle();
                    }

                    animation.AnimationProperties.Add(animProperty);
                }

                uint rotationDataCount = sectionReader.ReadUInt32();
                animation.Unknown1 = sectionReader.ReadUInt32();

                for (int i = 0; i < rotationDataCount; i++)
                {
                    RotationData rotationData = new RotationData() {
                        W = sectionReader.ReadSingle(),
                        X = sectionReader.ReadSingle(),
                        Y = sectionReader.ReadSingle(),
                        Z = sectionReader.ReadSingle(),
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