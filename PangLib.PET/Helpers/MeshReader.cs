using System.Collections.Generic;
using System.IO;
using PangLib.PET.Models;

namespace PangLib.PET.Helpers
{
    static class MeshReader
    {
        public static Mesh ReadMesh(BinaryReader sectionReader, Version version)
        {
            Mesh mesh = new Mesh();

            uint vertexCount = sectionReader.ReadUInt32();
            mesh.Vertices = new Vertex[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                mesh.Vertices[i] = ReadVertex(sectionReader);
            }
            
            uint polygonCount = sectionReader.ReadUInt32();
            mesh.Polygons = new Polygon[polygonCount];

            for (int i = 0; i < polygonCount; i++)
            {
                mesh.Polygons[i] = ReadPolygon(sectionReader, version);
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
            polygon.PolygonIndices = new PolygonIndex[3];

            for (int i = 0; i < 3; i++)
            {
                PolygonIndex polygonIndex = new PolygonIndex
                {
                    Index = sectionReader.ReadUInt32(),
                    X = sectionReader.ReadSingle(),
                    Y = sectionReader.ReadSingle(),
                    Z = sectionReader.ReadSingle()
                };

                if (version.Minor >= 2)
                {
                    byte uvMapCount = sectionReader.ReadByte();
                    polygonIndex.UVMappings = new UVMapping[uvMapCount];

                    for (int j = 0; j < uvMapCount; j++)
                    {
                        UVMapping uvMapping = new UVMapping {
                            U = sectionReader.ReadSingle(),
                            V = sectionReader.ReadSingle()
                        };

                        polygonIndex.UVMappings[j] = uvMapping;
                    }
                }
                else
                {
                    polygonIndex.UVMappings = new UVMapping[1];
                    
                    UVMapping uvMapping = new UVMapping {
                        U = sectionReader.ReadSingle(),
                        V = sectionReader.ReadSingle()
                    };

                    polygonIndex.UVMappings[0] = uvMapping;
                }

                polygon.PolygonIndices[i] = polygonIndex;
            }

            return polygon;
        }
    }
}