using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    static class CollisionBoxReader
    {
        public static List<CollisionBox> ReadAllCollisionBoxes(BinaryReader sectionReader)
        {
            List<CollisionBox> CollisionBoxes = new List<CollisionBox>();

            uint collisionBoxCount = sectionReader.ReadUInt32();

            for (int i = 0; i < collisionBoxCount; i++)
            {
                CollisionBox collisionBox = new CollisionBox();

                collisionBox.Unknown1 = sectionReader.ReadUInt32();
                collisionBox.Unknown2 = sectionReader.ReadUInt32();

                int nameLength = sectionReader.ReadInt32();

                collisionBox.Name = Encoding.UTF8.GetString(sectionReader.ReadBytes(nameLength));

                int boneNameLength = sectionReader.ReadInt32();

                collisionBox.BoneName = Encoding.UTF8.GetString(sectionReader.ReadBytes(boneNameLength));

                collisionBox.Unknown3 = sectionReader.ReadByte();
                collisionBox.Unknown4 = sectionReader.ReadUInt32();
                collisionBox.Unknown5 = sectionReader.ReadUInt32();

                collisionBox.MinX = sectionReader.ReadSingle();
                collisionBox.MinY = sectionReader.ReadSingle();
                collisionBox.MinZ = sectionReader.ReadSingle();
                collisionBox.MaxX = sectionReader.ReadSingle();
                collisionBox.MaxY = sectionReader.ReadSingle();
                collisionBox.MaxZ = sectionReader.ReadSingle();

                CollisionBoxes.Add(collisionBox);
            }

            return CollisionBoxes;
        }
    }
}
