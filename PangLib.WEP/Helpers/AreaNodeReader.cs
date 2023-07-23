using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class AreaNodeReader
    {
        public static List<AreaNode> ReadAllAreaNodes(BinaryReader reader, int version, int count)
        {
            List<AreaNode> areaNodes = new List<AreaNode>();

            for (int i = 0; i < count; i++)
            {
                AreaNode areaNode = new AreaNode
                {
                    Type = reader.ReadByte(),
                    Sequence = reader.ReadFixedString(64),
                    Area = reader.ReadArea()
                };

                if (version == 114)
                {
                    areaNode.Area2 = reader.ReadArea();
                    areaNode.ExtraValues = reader.ReadExtraValues();
                }
            }

            return areaNodes;
        }
    }
}