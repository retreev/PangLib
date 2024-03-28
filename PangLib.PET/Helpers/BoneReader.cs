using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.PET.Models.Bone"/> structures from Puppet files
/// </summary>
static class BoneReader
{
    /// <summary>
    /// Helper method to read all bones from a Puppet file and return a list of them
    /// </summary>
    /// <param name="sectionReader">BinaryReader instance containing the Bone section data</param>
    /// <param name="version">Version of the Puppet file</param>
    /// <returns>List of bones from the Puppet file</returns>
    public static List<Bone> ReadAllBones(BinaryReader sectionReader, Version version)
    {
        List<Bone> bones = new List<Bone>();

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
                
            bone.Matrix = new float[12];

            for (int j = 0; j < 12; j++)
            {
                bone.Matrix[j] = sectionReader.ReadSingle();
            }

            if (version.Minor >= 3)
            {
                bone.Unknown1 = sectionReader.ReadSingle();
            }

            bones.Add(bone);
        }

        return bones;
    }
}