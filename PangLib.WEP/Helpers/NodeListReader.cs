using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class NodeListReader
    {
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