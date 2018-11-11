using System;

namespace PangLib.Utilities.Cryptography
{
    public static class XOR
    {
        public static byte[] Cipher(byte[] data, uint key)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] ^= (byte) key;
            }

            return data;
        }
    }
}
