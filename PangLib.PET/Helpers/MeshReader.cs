using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers
{
    static class MeshReader
    {
        public static Mesh ReadMesh(BinaryReader sectionReader, Version version)
        {
            Mesh mesh = new Mesh();

            uint vertexCount = sectionReader.ReadUInt32();
            mesh.Vertices = new List<Vertex>();

            for (int i = 0; i < vertexCount; i++)
            {
                mesh.Vertices.Add(ReadVertex(sectionReader));
            }
            
            uint polygonCount = sectionReader.ReadUInt32();
            mesh.Polygons = new List<Polygon>();

            for (int i = 0; i < polygonCount; i++)
            {
                mesh.Polygons.Add(ReadPolygon(sectionReader, version));
            }
            
            mesh.TextureMap = new uint[polygonCount];
            
            for (int i = 0; i < polygonCount; i++)
            {
                mesh.TextureMap[i] = sectionReader.ReadByte();
            }

            return mesh;
        }

        public static Vertex ReadVertex(BinaryReader sectionReader)
        {
            Vertex vertex = new Vertex();

            vertex.X = sectionReader.ReadSingle();
            vertex.Y = sectionReader.ReadSingle();
            vertex.Z = sectionReader.ReadSingle();

            byte fullWeight = 0;
            int readCount = 0;
                
            vertex.BoneInformation = new List<BoneInformation>();

            while (fullWeight != 255 || readCount < 2)
            {
                BoneInformation boneInformation = new BoneInformation();

                byte weight = sectionReader.ReadByte();

                boneInformation.Weight = weight;
                fullWeight += weight;

                boneInformation.BoneID = sectionReader.ReadByte();

                vertex.BoneInformation.Add(boneInformation);
                readCount += 1;
            }

            return vertex;
        }

        public static Polygon ReadPolygon(BinaryReader sectionReader, Version version)
        {
            Polygon polygon = new Polygon();
            polygon.PolygonIndices = new List<PolygonIndex>();

            for (int j = 0; j < 3; j++)
            {
                PolygonIndex polygonIndex = new PolygonIndex();

                polygonIndex.Index = sectionReader.ReadUInt32();
                polygonIndex.X = sectionReader.ReadSingle();
                polygonIndex.Y = sectionReader.ReadSingle();
                polygonIndex.Z = sectionReader.ReadSingle();
                    
                polygonIndex.UVMappings = new List<UVMapping>();

                if (version.Minor >= 2)
                {
                    byte uvMapCount = sectionReader.ReadByte();

                    for (int k = 0; k < uvMapCount; k++)
                    {
                        UVMapping uvMapping = new UVMapping() {
                            U = sectionReader.ReadSingle(),
                            V = sectionReader.ReadSingle()
                        };

                        polygonIndex.UVMappings.Add(uvMapping);
                    }
                }
                else
                {
                    UVMapping uvMapping = new UVMapping() {
                        U = sectionReader.ReadSingle(),
                        V = sectionReader.ReadSingle()
                    };

                    polygonIndex.UVMappings.Add(uvMapping);
                }

                polygon.PolygonIndices.Add(polygonIndex);
            }

            return polygon;
        }
    }
}