using System.Collections.Generic;
using System.IO;
using PangLib.SBIN.Models;

namespace PangLib.SBIN.Helpers
{
    public class ShadowMapReader
    {
        public static ShadowMap ReadShadowMap(BinaryReader reader)
        {
            ShadowMap shadowMap = new ShadowMap();
            
            int meshCount = reader.ReadInt32();
            List<Vertex> vertices = new List<Vertex>();

            for (int i = 0; i < meshCount; i++)
            {
                vertices.Add(reader.ReadVertex());
            }

            shadowMap.Vertices = vertices;

            int mesh3DCount = reader.ReadInt32();
            int mesh2DCount = reader.ReadInt32();

            List<Vector3<float>> mesh3D = new List<Vector3<float>>();
            
            for (int i = 0; i < mesh3DCount; i++)
            {
                mesh3D.Add(reader.ReadVector3());
            }
            
            List<Vector2<float>> mesh2D = new List<Vector2<float>>();
            
            for (int i = 0; i < mesh2DCount; i++)
            {
                mesh2D.Add(reader.ReadVector2());
            }

            shadowMap.Mesh3D = mesh3D;
            shadowMap.Mesh2D = mesh2D;

            int globalTextureSize = reader.ReadInt32();

            if (globalTextureSize > 0)
            {
                shadowMap.GlobalTextures = TextureReader.ReadAllTextures(reader);
            }

            int type0TextureSize = reader.ReadInt32();

            if (type0TextureSize > 0)
            {
                shadowMap.Type0Textures = TextureReader.ReadAllTextures(reader);
            }
            
            int type1TextureSize = reader.ReadInt32();

            if (type1TextureSize > 0)
            {
                shadowMap.Type1Textures = TextureReader.ReadAllTextures(reader);
            }

            int globalValueCount = reader.ReadInt32();
            int type0ValueCount = reader.ReadInt32();
            int type1ValueCount = reader.ReadInt32();

            List<int> globalNumberValues = new List<int>();

            if (globalValueCount > 0)
            {
                for (int i = 0; i < meshCount; i++)
                {
                    globalNumberValues.Add(reader.ReadInt32());
                }
            }
            
            List<int> type0NumberValues = new List<int>();

            if (type0ValueCount > 0)
            {
                for (int i = 0; i < meshCount; i++)
                {
                    type0NumberValues.Add(reader.ReadInt32());
                }
            }
            
            List<int> type1NumberValues = new List<int>();

            if (type1ValueCount > 0)
            {
                for (int i = 0; i < meshCount; i++)
                {
                    type1NumberValues.Add(reader.ReadInt32());
                }
            }

            shadowMap.GlobalNumberValues = globalNumberValues;
            shadowMap.Type0NumberValues = type0NumberValues;
            shadowMap.Type1NumberValues = type1NumberValues;

            List<long> globalValues = new List<long>();
            
            if (globalValueCount > 0)
            {
                for (int i = 0; i < globalValueCount; i++)
                {
                    globalValues.Add(reader.ReadInt64());
                }
            }

            List<long> type0Values = new List<long>();
            
            if (type0ValueCount > 0)
            {
                for (int i = 0; i < type0ValueCount; i++)
                {
                    type0Values.Add(reader.ReadInt64());
                }
            }
            
            List<long> type1Values = new List<long>();
            
            if (type1ValueCount > 0)
            {
                for (int i = 0; i < type1ValueCount; i++)
                {
                    type1Values.Add(reader.ReadInt64());
                }
            }

            shadowMap.GlobalValues = globalValues;
            shadowMap.Type0Values = type0Values;
            shadowMap.Type1Values = type1Values;

            return shadowMap;
        }
    }
}