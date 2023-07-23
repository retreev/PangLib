using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class PointNodeReader
    {
        public static List<PointNode> ReadAllPointNodes(BinaryReader reader, int version, int count)
        {
            List<PointNode> pointNodes = new List<PointNode>();

            for (int i = 0; i < count; i++)
            {
                PointNode pointNode = new PointNode();

                pointNode.Type = (PointNodeType)reader.ReadByte();

                switch (pointNode.Type)
                {
                    case PointNodeType.Start:
                        pointNode.Name = reader.ReadFixedString(32);
                        pointNode.Position = reader.ReadVector3();

                        if (version == 114)
                        {
                            pointNode.Position2 = reader.ReadVector3();
                            pointNode.ExtraValues = reader.ReadExtraValues();
                        }

                        break;
                    case PointNodeType.Light:
                    case PointNodeType.Sun:
                    case PointNodeType.Sequence:
                    default:
                        pointNode.Name = reader.ReadFixedString(32);
                        pointNode.Position = reader.ReadVector3();
                        pointNode.Data = reader.ReadFixedString(64);
                        
                        if (version == 114)
                        {
                            pointNode.Position2 = reader.ReadVector3();
                            pointNode.ExtraValues = reader.ReadExtraValues();
                        }

                        break;
                }
                
                pointNodes.Add(pointNode);
            }

            return pointNodes;
        }
    }
}