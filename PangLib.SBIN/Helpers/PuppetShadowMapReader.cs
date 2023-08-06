using System.Collections.Generic;
using System.IO;
using PangLib.SBIN.Models;

namespace PangLib.SBIN.Helpers
{
    public class PuppetShadowMapReader
    {
        public static List<PuppetShadowMap> ReadAllPuppetShadowMaps(BinaryReader reader)
        {
            List<PuppetShadowMap> puppetShadowMaps = new List<PuppetShadowMap>();

            int puppetCount = reader.ReadInt32();

            for (int i = 0; i < puppetCount; i++)
            {
                puppetShadowMaps.Add(new PuppetShadowMap()
                {
                    Name = reader.ReadPascalString(),
                    ShadowMap = ShadowMapReader.ReadShadowMap(reader)
                });
            }

            return puppetShadowMaps;
        }
    }
}