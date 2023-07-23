using System.Collections.Generic;
using System.IO;

namespace PangLib.WEP.Helpers
{
    public class TextureReader
    {
        public static List<string> ReadAllTextures(BinaryReader reader, int count)
        {
            List<string> textures = new List<string>();

            for (int i = 0; i < count; i++)
            {
                textures.Add(reader.ReadFixedString(32));
            }

            return textures;
        }
    }
}