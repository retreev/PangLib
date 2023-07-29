using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.WEP.Models.Color"/>/<see cref="PangLib.WEP.Models.ColorVertexMap"/> structures from WEP files
    /// </summary>
    public class ColorReader
    {
        /// <summary>
        /// Helper method to read a list of colors from a WEP file
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="count">Count of colors</param>
        /// <returns>List of colors from the WEP file</returns>
        public static List<Color> ReadAllColors(BinaryReader reader, int count)
        {
            List<Color> colors = new List<Color>();

            for (int i = 0; i < count; i++)
            {
                Color color = new Color();
                
                for (int j = 0; j <= 2; j++)
                {
                    color.Values.Add(reader.ReadInt32());
                }
                
                colors.Add(color);
            }

            return colors;
        }

        /// <summary>
        /// Helper method to read all vertex color maps from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <returns>List of vertex color maps from the WEP file</returns>
        public static List<VertexColorMap> ReadAllVertexColorMaps(BinaryReader reader)
        {
            List<VertexColorMap> vertexColorMaps = new List<VertexColorMap>();
            
            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                VertexColorMap vertexColorMap = new VertexColorMap();

                vertexColorMap.Name = reader.ReadPascalString();

                int colorCount = reader.ReadInt32();

                vertexColorMap.Colors = new List<Color>();

                for (int j = 0; j < colorCount; j++)
                {
                    Color color = new Color();
                    int valueCount = reader.ReadInt32();

                    for (int k = 0; k < valueCount; k++)
                    {
                        color.Values.Add(reader.ReadInt32());
                    }
                    
                    vertexColorMap.Colors.Add(color);
                }
                
                vertexColorMaps.Add(vertexColorMap);
            }

            return vertexColorMaps;
        }
    }
}