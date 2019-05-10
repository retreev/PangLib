using System.Collections.Generic;
using System.IO;
using PangLib.PET.DataModels;

namespace PangLib.PET.Helpers
{
    static class PolygonReader
    {
        public static List<Polygon> ReadAllPolygons(BinaryReader sectionReader, Version version)
        {
            List<Polygon> Polygons = new List<Polygon>();

            uint polygonCount = sectionReader.ReadUInt32();

            for (int i = 0; i < polygonCount; i++)
            {
                Polygon polygon = new Polygon();

                for (int j = 0; j < 3; j++)
                {
                    PolygonIndex polygonIndex = new PolygonIndex();

                    polygonIndex.Index = sectionReader.ReadUInt32();
                    polygonIndex.X = sectionReader.ReadSingle();
                    polygonIndex.Y = sectionReader.ReadSingle();
                    polygonIndex.Z = sectionReader.ReadSingle();

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

                Polygons.Add(polygon);
            }

            for (int i = 0; i < polygonCount; i++)
            {
                Polygons[i].TextureIndex = sectionReader.ReadByte();
            }

            return Polygons;
        }
    }
}
