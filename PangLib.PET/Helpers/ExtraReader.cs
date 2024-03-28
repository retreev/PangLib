using System.IO;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers;

/// <summary>
/// Helper class to read <see cref="PangLib.PET.Models.Extra"/> structures from Puppet files
/// </summary>
static class ExtraReader
{
    /// <summary>
    /// Helper method to read the extra section of a Puppet file and return the contained data as a structure
    /// </summary>
    /// <param name="sectionReader">BinaryReader instance containing the Extra section data</param>
    /// <returns>An instance of <see cref="PangLib.PET.Models.Extra"/> containing parsed data</returns>
    public static Extra ReadExtra(BinaryReader sectionReader)
    {
        Extra extra = new Extra();

        uint charCount = sectionReader.ReadUInt32();
        extra.CharacterSet = new char[charCount];

        for (int i = 0; i < charCount; i++)
        {
            extra.CharacterSet[i] = sectionReader.ReadChar();
        }

        return extra;
    }
}