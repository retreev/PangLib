using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.WEP.Models.AreaNode"/> structures from WEP files
    /// </summary>
    public class AreaNodeReader
    {
        /// <summary>
        /// Helper method to read all area nodes from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="version">Version of the WEP file</param>
        /// <param name="count">Count of area nodes</param>
        /// <returns>List of area nodes from the WEP file</returns>
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