using System.Collections.Generic;
using System.IO;
using System.Text;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.PET.Models.Frame"/> structures from Puppet files
/// </summary>
static class FrameReader
{
    /// <summary>
    /// Helper method to read all frames from a Puppet file and return a list of them
    /// </summary>
    /// <param name="sectionReader">BinaryReader instance containing the Frame section data</param>
    /// <returns>List of frames from the Puppet file</returns>
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