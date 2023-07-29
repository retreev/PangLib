using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.WEP.Models.NodeList"/> structures from WEP files
    /// </summary>
    public class NodeListReader
    {
        /// <summary>
        /// Helper method to read all node lists from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="version">Version of the WEP file</param>
        /// <param name="count">Count of node lists</param>
        /// <returns>List of node lists from the WEP file</returns>
        public static List<NodeList> ReadAllNodeLists(BinaryReader reader, int version, int count)
        {
            List<NodeList> nodeLists = new List<NodeList>();

            for (int i = 0; i < count; i++)
            {
                NodeList nodeList = new NodeList();

                if (version == 113)
                {
                    nodeList.Name = reader.ReadFixedString(16);
                }
                else
                {
                    nodeList.Name = reader.ReadFixedString(32);
                }

                nodeList.Length = reader.ReadInt32();
                nodeList.Type = reader.ReadInt32();

                nodeList.Vectors = new List<Vector3<float>>();

                for (int j = 0; j < nodeList.Length; j++)
                {
                    nodeList.Vectors.Add(reader.ReadVector3());
                }
                
                nodeLists.Add(nodeList);
            }

            return nodeLists;
        }
    }
}