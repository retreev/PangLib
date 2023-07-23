using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PangLib.WEP.Helpers;
using PangLib.WEP.Models;

namespace PangLib.WEP
{
    public class WEPFile
    {
        public int Version = 0;
        public List<CameraNode> CameraNodes { get; set; }
        public List<PointNode> PointNodes { get; set; }
        public List<AreaNode> AreaNodes { get; set; }
        public List<string> Textures { get; set; }
        public List<NodeList> NodeLists { get; set; }
        
        public Element BaseElement { get; set; }
        public List<Color> BaseColors { get; set; }
        public List<VertexColorMap> VertexColorMaps { get; set; }
        public List<Element> Elements { get; set; }
        public MapCheck MapCheck { get; set; }

        public WEPFile(Stream data)
        {
            Parse(data);
        }

        private void Parse(Stream data)
        {
            using (BinaryReader reader = new BinaryReader(data))
            {
                string magic = Encoding.UTF8.GetString(reader.ReadBytes(4));

                if (magic != "WEPX")
                {
                    throw new Exception("File is not a valid WEP file");
                }

                Version = reader.ReadInt32();
                
                int globalElementCount = reader.ReadInt32();
                int elementType0Count = reader.ReadInt32();
                int elementType1Count = reader.ReadInt32();
                int cameraNodeCount = reader.ReadInt32();
                int pointNodeCount = reader.ReadInt32();
                int areaNodeCount = reader.ReadInt32();
                int textureCount = reader.ReadInt32();
                int nodeListCount = reader.ReadInt32();
                int elementType2Count = 0;

                if (Version == 114)
                {
                    elementType2Count = reader.ReadInt32();   
                }

                CameraNodes = CameraNodeReader.ReadAllCameraNodes(reader, Version, cameraNodeCount);
                PointNodes = PointNodeReader.ReadAllPointNodes(reader, Version, pointNodeCount);
                AreaNodes = AreaNodeReader.ReadAllAreaNodes(reader, Version, areaNodeCount);
                Textures = TextureReader.ReadAllTextures(reader, textureCount);
                NodeLists = NodeListReader.ReadAllNodeLists(reader, Version, nodeListCount);

                int fullElementCount = globalElementCount + elementType0Count + elementType1Count;

                if (fullElementCount > 0)
                {
                    BaseElement = ElementReader.ReadElement(reader, Version);

                    if (Version == 113)
                    {
                        BaseColors = ColorReader.ReadAllColors(reader, BaseElement.VertexCount);
                    }
                    else
                    {
                        VertexColorMaps = ColorReader.ReadAllVertexColorMaps(reader);
                    }

                    Elements = ElementReader.ReadAllElements(reader, Version, fullElementCount);
                    Elements = Elements.Concat(ElementReader.ReadAllNewElements(reader, elementType2Count)).ToList();
                    
                    MapCheck = MapCheckReader.ReadMapCheck(reader, Version);
                }
            }
        }
    }
}
