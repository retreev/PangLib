using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.DataModels;
using PangLib.PET.Helpers;

namespace PangLib.PET
{
    public class PETFile
    {
        private string FilePath;

        public List<CollisionBox> CollisionBoxes;
        public List<Motion> Motions;
        public List<Vertex> Vertices;
        public List<Polygon> Polygons;
        public List<Bone> Bones;

        public PETFile(string filePath)
        {
            FilePath = filePath;
        }

        public void Parse()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string sectionName = Encoding.UTF8.GetString(reader.ReadBytes(4));
                    int sectionLength = reader.ReadInt32();
                    byte[] sectionBytes = reader.ReadBytes(sectionLength);

                    using (BinaryReader sectionReader = new BinaryReader(new MemoryStream(sectionBytes)))
                    {
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
                    }
                }
            }
        }
    }
}
