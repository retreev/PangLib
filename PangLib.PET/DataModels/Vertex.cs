using System;
using System.Collections.Generic;

namespace PangLib.PET.DataModels
{
    class Vertex
    {
        public float X;
        public float Y;
        public float Z;
        public List<BoneInformation> BoneInformation = new List<BoneInformation>();
    }
}
