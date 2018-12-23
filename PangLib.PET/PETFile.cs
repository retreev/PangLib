using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.DataModels;
using PangLib.PET.Helpers;

namespace PangLib.PET
{
    public class PETFile
    {
        private BinaryReader Reader;
        private byte[] FileDataBytes;

        private List<CollisionBox> CollisionBoxes;
        private List<Motion> Motions;
        private List<Vertex> Vertices;
        private List<Polygon> Polygons;
        private List<Bone> Bones;

        public PETFile(string filePath)
        {
            FileDataBytes = File.ReadAllBytes(filePath);

            Reader = new BinaryReader(new MemoryStream(FileDataBytes));
        }

        public void Parse()
        {
            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                string sectionName = Encoding.UTF8.GetString(Reader.ReadBytes(4));
                int sectionLength = Reader.ReadInt32();
                byte[] sectionBytes = Reader.ReadBytes(sectionLength);

                BinaryReader sectionReader = new BinaryReader(new MemoryStream(sectionBytes));

                switch (sectionName)
                {
                    case "VERS":
                        // TODO: Implement parsing of VERS section
                        break;
                    case "TEXT":
                        // TODO: Implement parsing of TEXT section
                        break;
                    case "SMTL":
                        // TODO: Implement parsing of SMTL section
                        break;
                    case "BONE":
                        Bones = BoneReader.ReadAllBones(sectionReader);
                        break;
                    case "ANIM":
                        // TODO: Implement parsing of ANIM section
                        break;
                    case "MESH":
                        Vertices = VertexReader.ReadAllVertices(sectionReader);
                        Polygons = PolygonReader.ReadAllPolygons(sectionReader);
                        break;
                    case "FANM":
                        // TODO: Implement parsing of FANM section
                        break;
                    case "FRAM":
                        // TODO: Implement parsing of FRAM section
                        break;
                    case "MOTI":
                        Motions = MotionReader.ReadAllMotions(sectionReader);
                        break;
                    case "COLL":
                        CollisionBoxes = CollisionBoxReader.ReadAllCollisionBoxes(sectionReader);
                        break;
                }

                sectionReader.Close();
            }
        }
    }
}
