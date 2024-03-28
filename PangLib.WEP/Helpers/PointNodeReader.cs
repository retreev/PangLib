using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.WEP.Models.PointNode"/> structures from WEP files
/// </summary>
public class PointNodeReader
{
    /// <summary>
    /// Helper method to read all point nodes from a WEP file and return a list of them
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <param name="version">Version of the WEP file</param>
    /// <param name="count">Count of point nodes</param>
    /// <returns>List of point nodes from the WEP file</returns>
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