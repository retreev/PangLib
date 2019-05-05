using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    static class BoneReader
    {
        public static List<Bone> ReadAllBones(BinaryReader sectionReader)
        {
            List<Bone> Bones = new List<Bone>();

            int boneCount = (int) sectionReader.ReadSByte();

            for (int i = 0; i < boneCount; i++)
            {
                Bone bone = new Bone();

                List<char> nameChars = new List<char>();

                while (sectionReader.PeekChar() != 0x00)
                {
                    nameChars.Add(sectionReader.ReadChar());
                }

                char[] chars = nameChars.ToArray();
                byte[] bytes = Encoding.UTF8.GetBytes(chars);

                bone.Name = Encoding.UTF8.GetString(bytes);
                sectionReader.BaseStream.Seek(1L, SeekOrigin.Current);

                bone.Parent = sectionReader.ReadByte();

                for (int j = 0; j < 12; j++)
                {
                    bone.Matrix[j] = sectionReader.ReadSingle();
                }

                Bones.Add(bone);
            }

            return Bones;
        }
    }
}
