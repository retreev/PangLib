using System.IO;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    static class VersionReader
    {
        public static Version ReadVersion(BinaryReader sectionReader)
        {
            return new Version() {
                Minor = sectionReader.ReadByte(),
                Major = sectionReader.ReadByte()
            };
        }
    }
}