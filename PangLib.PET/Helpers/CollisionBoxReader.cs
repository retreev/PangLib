using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.PET.Models.CollisionBox"/> structures from Puppet files
/// </summary>
static class CollisionBoxReader
{
    /// <summary>
    /// Helper method to read all collision boxes from a Puppet file and return a list of them
    /// </summary>
    /// <param name="sectionReader">BinaryReader instance containing the Collision Box section data</param>
    /// <param name="version">Version of the Puppet file</param>
    /// <returns>List of collision boxes from the Puppet file</returns>
    public static List<CollisionBox> ReadAllCollisionBoxes(BinaryReader sectionReader, Version version)
    {
        List<CollisionBox> collisionBoxes = new List<CollisionBox>();

        uint collisionBoxCount = sectionReader.ReadUInt32();

        for (int i = 0; i < collisionBoxCount; i++)
        {
            CollisionBox collisionBox = new CollisionBox();

            collisionBox.Unknown1 = sectionReader.ReadUInt32();
            collisionBox.Unknown2 = sectionReader.ReadUInt32();

            uint nameLength = sectionReader.ReadUInt32();

            collisionBox.Name = Encoding.UTF8.GetString(sectionReader.ReadBytes((int) nameLength));

            uint boneNameLength = sectionReader.ReadUInt32();

            collisionBox.BoneName = Encoding.UTF8.GetString(sectionReader.ReadBytes((int) boneNameLength));

            uint scriptLength = sectionReader.ReadUInt32();
                
            collisionBox.Script = Encoding.UTF8.GetString(sectionReader.ReadBytes((int) scriptLength));

            collisionBox.Unknown3 = sectionReader.ReadUInt32();

            collisionBox.MinX = sectionReader.ReadSingle();
            collisionBox.MinY = sectionReader.ReadSingle();
            collisionBox.MinZ = sectionReader.ReadSingle();
            collisionBox.MaxX = sectionReader.ReadSingle();
            collisionBox.MaxY = sectionReader.ReadSingle();
            collisionBox.MaxZ = sectionReader.ReadSingle();

            collisionBoxes.Add(collisionBox);
        }

        return collisionBoxes;
    }
}