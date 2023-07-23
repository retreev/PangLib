using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class MapCheckReader
    {
        public static MapCheck ReadMapCheck(BinaryReader reader, int version)
        {
            MapCheck mapCheck = new MapCheck
            {
                Par = reader.ReadByte()
            };

            if (version == 113)
            {
                mapCheck.TeeType = new List<Point>();
                
                for (int i = 0; i <= 1; i++)
                {
                    mapCheck.TeeType.Add(reader.ReadPoint());
                }

                mapCheck.PinType1 = new List<Point>();
                
                for (int i = 0; i <= 2; i++)
                {
                    mapCheck.PinType1.Add(reader.ReadPoint());
                }

                mapCheck.PinType2 = new List<Point>();
                
                for (int i = 0; i <= 2; i++)
                {
                    mapCheck.PinType2.Add(reader.ReadPoint());
                }
            }

            return mapCheck;
        }
    }
}