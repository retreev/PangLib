using System.Collections.Generic;
using System.IO;
using PangLib.SBIN.Helpers;
using PangLib.SBIN.Models;

namespace PangLib.SBIN
{
    public class SBINFile
    {
        public List<PuppetShadowMap> PuppetShadowMaps;
        public ShadowMap ShadowMap;

        public SBINFile(Stream data)
        {
            Parse(data);
        }

        private void Parse(Stream data)
        {
            using (BinaryReader reader = new BinaryReader(data))
            {
                int version = reader.ReadInt32();

                if (version > 0xFFFE000)
                {
                    PuppetShadowMaps = PuppetShadowMapReader.ReadAllPuppetShadowMaps(reader);
                }
                else
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    ShadowMap = ShadowMapReader.ReadShadowMap(reader);
                }
            }
        }
    }    
}
