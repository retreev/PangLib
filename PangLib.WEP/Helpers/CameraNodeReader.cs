using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class CameraNodeReader
    {
        public static List<CameraNode> ReadAllCameraNodes(BinaryReader reader, int version, int count)
        {
            List<CameraNode> cameraNodes = new List<CameraNode>();

            for (int i = 0; i < count; i++)
            {
                CameraNode cameraNode = new CameraNode
                {
                    Name = reader.ReadFixedString(32),
                    Position = reader.ReadVector3(),
                    Destination = reader.ReadVector3(),
                    FOV = reader.ReadSingle(),
                    Bank = reader.ReadSingle()
                };
                
                if (version == 114)
                {
                    cameraNode.Position2 = reader.ReadVector3();
                    cameraNode.Destination2 = reader.ReadVector3();
                    cameraNode.ExtraValues = reader.ReadExtraValues();
                }
                
                cameraNodes.Add(cameraNode);
            }

            return cameraNodes;
        }
    }
}