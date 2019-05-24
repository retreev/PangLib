using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.PET.Models.Motion"/> structures from Puppet files
    /// </summary>
    static class MotionReader
    {
        /// <summary>
        /// Helper method to read all motions from a Puppet file and return a list of them
        /// </summary>
        /// <param name="sectionReader">BinaryReader instance containing the Motion section data</param>
        /// <returns>List of motions from the Puppet file</returns>
        public static List<Motion> ReadAllMotions(BinaryReader sectionReader)
        {
            List<Motion> motions = new List<Motion>();

            uint motionCount = sectionReader.ReadUInt32();

            for (int i = 0; i < motionCount; i++)
            {
                Motion motion = new Motion();

                int nameLength = sectionReader.ReadInt32();

                motion.Name = Encoding.UTF8.GetString(sectionReader.ReadBytes(nameLength));

                motion.FrameStart = sectionReader.ReadUInt32();
                motion.FrameEnd = sectionReader.ReadUInt32();

                int targetNameLength = sectionReader.ReadInt32();

                motion.TargetName = Encoding.UTF8.GetString(sectionReader.ReadBytes(targetNameLength));

                int typeNameLength = sectionReader.ReadInt32();

                motion.TypeName = Encoding.UTF8.GetString(sectionReader.ReadBytes(typeNameLength));

                motion.Type = sectionReader.ReadUInt32();

                int boneNameLength = sectionReader.ReadInt32();

                motion.BoneName = Encoding.UTF8.GetString(sectionReader.ReadBytes(boneNameLength));

                motions.Add(motion);
            }

            return motions;
        }
    }
}
