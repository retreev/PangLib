using System.Collections.Generic;

namespace PangLib.SBIN.Models
{
    public struct Texture
    {
        public int Width;
        public int Height;
        public byte[] TextureData;
        public List<DDSMap> DDSMaps;
    }
}