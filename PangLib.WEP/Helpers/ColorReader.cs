using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class ColorReader
    {
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