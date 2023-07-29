using System.Collections.Generic;
using System.IO;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read textures from WEP files
    /// </summary>
    public class TextureReader
    {
        /// <summary>
        /// Helper method to read all textures from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="count">Count of textures</param>
        /// <returns>List of textures from the WEP file</returns>
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