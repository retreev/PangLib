using System.IO;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers
{
    /// <summary>
    /// Helper class to read a <see cref="PangLib.PET.Models.Version"/> structure from Puppet files
    /// </summary>
    static class VersionReader
    {
        /// <summary>
        /// Helper method to read the version from a Puppet file and return it
        /// </summary>
        /// <param name="sectionReader">BinaryReader instance containing the Version section data</param>
        /// <returns>The version of the Puppet file</returns>
        public static Version ReadVersion(BinaryReader sectionReader)
        {
            return new Version() {
                Minor = sectionReader.ReadByte(),
                Major = sectionReader.ReadByte()
            };
        }
    }
}