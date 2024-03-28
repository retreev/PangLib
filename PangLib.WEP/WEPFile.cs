using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PangLib.WEP.Helpers;
using PangLib.WEP.Models;

namespace PangLib.WEP;

public class WEPFile
{
    /// <summary>
    /// Version of the WEP file
    /// </summary>
    public int Version = 0;
        
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.CameraNode"/> parsed from this WEP file
    /// </summary>
    public List<CameraNode> CameraNodes { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.PointNode"/> parsed from this WEP file
    /// </summary>
    public List<PointNode> PointNodes { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.AreaNode"/> parsed from this WEP file
    /// </summary>
    public List<AreaNode> AreaNodes { get; set; }
                
    /// <summary>
    /// List of textures parsed from this WEP file
    /// </summary>
    public List<string> Textures { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.NodeList"/> parsed from this WEP file
    /// </summary>
    public List<NodeList> NodeLists { get; set; }

    /// <summary>
    /// Base <see cref="PangLib.WEP.Models.Element"/> of this WEP file
    /// </summary>
    public Element BaseElement { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.Color"/> parsed from this WEP file
    /// </summary>
    public List<Color> BaseColors { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.VertexColorMap"/> parsed from this WEP file
    /// </summary>
    public List<VertexColorMap> VertexColorMaps { get; set; }
                
    /// <summary>
    /// List of <see cref="PangLib.WEP.Models.Element"/> parsed from this WEP file
    /// </summary>
    public List<Element> Elements { get; set; }
        
    /// <summary>
    /// <see cref="PangLib.WEP.Models.MapCheck"/> of this WEP file
    /// </summary>
    public MapCheck MapCheck { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="WEPFile"/> from the provided stream
    /// </summary>
    /// <param name="data">Stream containing the WEP file data</param>
    public WEPFile(Stream data)
    {
        Parse(data);
    }

    /// <summary>
    /// Parses the passed Stream into WEP file structures
    /// </summary>
    /// <param name="data">Stream containing the WEP file data</param>
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