using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;
using PangLib.PET.Helpers;

namespace PangLib.PET
{
    /// <summary>
    /// Main PET file class
    /// </summary>
    public class PETFile
    {
        /// <summary>
        /// Version of the Puppet file
        /// </summary>
        /// <remarks>
        /// Initializes with a 1.0 version because some Puppet files don't have a Version section
        /// these files are regarded as 1.0
        /// </remarks>
        public Version Version { get; set; } = new Version
        {
            Major = 1,
            Minor = 0
        };

        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Animation"/> parsed from this Puppet file
        /// </summary>
        public List<Animation> Animations { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Frame"/> parsed from this Puppet file
        /// </summary>
        public List<Frame> Frames { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.CollisionBox"/> parsed from this Puppet file
        /// </summary>
        public List<CollisionBox> CollisionBoxes { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Motion"/> parsed from this Puppet file
        /// </summary>
        public List<Motion> Motions { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Bone"/> parsed from this Puppet file
        /// </summary>
        public List<Bone> Bones { get; set; }
        
        /// <summary>
        /// List of <see cref="PangLib.PET.Models.Texture"/> parsed from this Puppet file
        /// </summary>
        public List<Texture> Textures { get; set; }
        
        /// <summary>
        /// <see cref="PangLib.PET.Models.Mesh"/> parsed from this Puppet file
        /// </summary>
        public Mesh Mesh { get; set; }

        /// <summary>
        /// Initializes a new instance of <see cref="PETFile"/> from the provided stream
        /// </summary>
        /// <param name="data">Stream containing the Puppet file data</param>
        public PETFile(Stream data)
        {
            Parse(data);
        }

        /// <summary>
        /// Parses the passed Stream into Puppet structures
        /// </summary>
        /// <param name="data">Stream containing the Puppet file data</param>
        private void Parse(Stream data)
        {
            using (BinaryReader reader = new BinaryReader(data))
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
                                Bones = BoneReader.ReadAllBones(sectionReader, Version);
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
