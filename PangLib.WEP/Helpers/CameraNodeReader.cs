using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.WEP.Models.CameraNode"/> structures from WEP files
    /// </summary>
    public class CameraNodeReader
    {
        /// <summary>
        /// Helper method to read all camera nodes from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="version">Version of the WEP file</param>
        /// <param name="count">Count of camera nodes</param>
        /// <returns>List of camera nodes from the WEP file</returns>
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