using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    static class FrameReader
    {
        public static List<Frame> ReadAllFrames(BinaryReader sectionReader)
        {
            List<Frame> frames = new List<Frame>();
            
            uint frameCount = sectionReader.ReadUInt32();

            for (int i = 0; i < frameCount; i++)
            {
                Frame frame = new Frame();

                frame.Index = sectionReader.ReadUInt32();

                uint scriptLength = sectionReader.ReadUInt32();

                frame.Script = Encoding.UTF8.GetString(sectionReader.ReadBytes((int) scriptLength));

                frame.X = sectionReader.ReadSingle();
                frame.Y = sectionReader.ReadSingle();
                frame.Z = sectionReader.ReadSingle();
                
                frames.Add(frame);
            }
            
            return frames;
        }
    }
}