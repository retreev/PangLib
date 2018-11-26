using System;

namespace PangLib.Utilities.Compression
{
    /// <summary>
    /// Main LZ77 compression class
    /// </summary>
    public static class LZ77
    {
        /// <summary>
        /// This method decompresses a given bytearray from LZ77
        ///
        /// It also includes the handling of a custom implementation
        /// which just XORs certain values as an added security mechanism
        ///
        /// This implementation is based on the C++ code of DaveDevils/PangTools:
        /// https://github.com/davedevils/PangTools/blob/master/Tools/PAK%20-%20Unpack-Pack/Pak-Pangya/Pak-Pangya.cpp
        /// </summary>
        /// <param name="data">Compressed data</param>
        /// <param name="dataSize">Size of compressed data</param>
        /// <param name="realDataSize">Size of the uncompressed data</param>
        /// <param name="type">Compression type, valid types are 1 (regular) and 3 (custom)</param>
        /// <returns>Uncompressed data</returns>
        public static byte[] Decompress (byte[] data, uint dataSize, uint realDataSize, byte type)
        {
            ushort[] LZ77Masks = new ushort[] { 65313, 33615, 26463, 52, 62007, 33119, 18277, 563};

            byte OriginalMask = 0;
            byte Mask = 0;
            int CountByte = 0;
            int Size = 0;
            int Offset, OffsetSize;

            byte[] dataDestination = new byte[realDataSize];

            for (int i = 0; i < dataSize;)
            {
                if (CountByte == 0)
                {
                    Mask = data[i++];
                    OriginalMask = Mask;

                    if (type == 3) {
                        Mask ^= 0xC8;
                    }
                }
                else
                {
                    Mask >>= 1;
                }

                if ((Mask & 1) == 1)
                {
                    ushort tmpShort = BitConverter.ToUInt16(data, i);
                    i += 2;

                    if (type == 3)
                    {
                        tmpShort ^= LZ77Masks[(OriginalMask >> 3) & 7];
                    }

                    Offset = tmpShort & 0x0FFF;
                    OffsetSize = (tmpShort >> 0x0C) + 2;

                    Array.Copy(dataDestination, Size - Offset, dataDestination, Size, OffsetSize);

                    Size += OffsetSize;
                }
                else
                {
                    dataDestination[Size++] = data[i++];
                }

                CountByte = (CountByte + 1) & 7;
            }

            return dataDestination;
        }
    }
}