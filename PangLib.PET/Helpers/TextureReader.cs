using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.PET.Models.Texture"/> structures from Puppet files
/// </summary>
static class TextureReader
{
    /// <summary>
    /// Helper method to read all textures from a Puppet file and return a list of them
    /// </summary>
    /// <param name="sectionReader">BinaryReader instance containing the Texture section data</param>
    /// <returns>List of textures from the Puppet file</returns>
    public static List<Texture> ReadAllTextures(BinaryReader sectionReader)
    {
        List<Texture> textures = new List<Texture>();

        uint textureCount = sectionReader.ReadUInt32();

        for (int i = 0; i < textureCount; i++)
        {
            Texture texture = new Texture();

            // TODO each texture section is 44 bytes, currently only the filename is read from the beginning of each
            char[] chars = sectionReader.ReadChars(44).TakeWhile(c => c != 0x00).ToArray();
            byte[] bytes = Encoding.UTF8.GetBytes(chars);
            texture.FileName = Encoding.UTF8.GetString(bytes);

            textures.Add(texture);
        }

        return textures;
    }
}