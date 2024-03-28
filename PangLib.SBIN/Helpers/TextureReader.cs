using System.Collections.Generic;
using System.IO;
using PangLib.SBIN.Models;

namespace PangLib.SBIN.Helpers;

public class TextureReader
{
    public static List<Texture> ReadAllTextures(BinaryReader reader)
    {
        List<Texture> textures = new List<Texture>();

        int textureCount = reader.ReadInt32();
            
        for (int i = 0; i < textureCount; i++)
        {
            Texture texture = new Texture()
            {
                Width = reader.ReadInt32(),
                Height = reader.ReadInt32()
            };

            texture.TextureData = reader.ReadBytes((texture.Height * texture.Width) / 2);

            int ddsMapCount = reader.ReadInt32();

            if (ddsMapCount > 0)
            {
                List<DDSMap> ddsMaps = new List<DDSMap>();

                for (int j = 0; i < ddsMapCount; i++)
                {
                    ddsMaps.Add(new DDSMap() { Values = reader.ReadBytes(16) });
                }

                texture.DDSMaps = ddsMaps;
            }
        }

        return textures;
    }
}