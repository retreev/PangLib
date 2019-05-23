using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;
using PangLib.PET.Helpers;

namespace PangLib.PET
{
    public class PETFile
    {
        private string FilePath;

        public Version Version = new Version {
            Major = 1,
            Minor = 0
        };

        public List<Animation> Animations;
        public List<Frame> Frames;
        public List<CollisionBox> CollisionBoxes;
        public List<Motion> Motions;
        public List<Bone> Bones;
        public List<Texture> Textures;
        public Mesh Mesh;

        public PETFile(string filePath)
        {
            FilePath = filePath;

            Parse();
        }

        private void Parse()
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
                                Version = VersionReader.ReadVersion(sectionReader);
                                break;
                            case "TEXT":
                                Textures = TextureReader.ReadAllTextures(sectionReader);
                                break;
                            case "SMTL":
                                // TODO: Implement parsing of SMTL section
                                break;
                            case "BONE":
                                Bones = BoneReader.ReadAllBones(sectionReader);
                                break;
                            case "ANIM":
                                Animations = AnimationReader.ReadAllAnimations(sectionReader, Version);
                                break;
                            case "MESH":
                                Mesh = MeshReader.ReadMesh(sectionReader, Version);
                                break;
                            case "FANM":
                                // TODO: Implement parsing of FANM section
                                break;
                            case "FRAM":
                                Frames = FrameReader.ReadAllFrames(sectionReader);
                                break;
                            case "MOTI":
                                Motions = MotionReader.ReadAllMotions(sectionReader);
                                break;
                            case "COLL":
                                CollisionBoxes = CollisionBoxReader.ReadAllCollisionBoxes(sectionReader, Version);
                                break;
                        }
                    }
                }
            }
        }
    }
}
