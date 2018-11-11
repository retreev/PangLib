namespace PangLib.Utilities.Cryptography
{
    /// <summary>
    /// Main XTEA cipher class
    /// </summary>
    public static class XTEA
    {
        /// <summary>
        /// Enciphers the given data with the given key with given rounds
        /// </summary>
        /// <param name="rounds">Number of rounds the data should be enciphered</param>
        /// <param name="data">Array of 2 32-bit sized data blocks to be enciphered</param>
        /// <param name="key">Array of 4 32-bit sized key blocks to encipher the data with</param>
        /// <returns>Enciphered data</returns>
        public static uint[] Encipher(int rounds, uint[] data, uint[] key)
        {
            uint delta = 0x61C88647;
            uint sum = 0;
            uint data0 = data[0];
            uint data1 = data[1];

            for (int i = 0; i < rounds; i++)
            {
                data0 += (((data1 << 4) ^ (data1 >> 5)) + data1) ^ (sum + key[sum & 3]);
                sum -= delta;
                data1 += (((data0 << 4) ^ (data0 >> 5)) + data0) ^ (sum + key[(sum >> 11) & 3]);
            }

            data[0] = data0;
            data[1] = data1;

            return data;
        }

        /// <summary>
        /// Deciphers the given data with the given key with given rounds
        /// </summary>
        /// <param name="rounds">Number of rounds the data should be deciphered</param>
        /// <param name="data">Array of 2 32-bit sized data blocks to be deciphered</param>
        /// <param name="key">Array of 4 32-bit sized key blocks to decipher the data with</param>
        /// <returns>Deciphered data</returns>
        public static uint[] Decipher(int rounds, uint[] data, uint[] key)
        {
            uint delta = 0x61C88647;
            uint sum = 0xE3779B90;
            uint data0 = data[0];
            uint data1 = data[1];

            for (int i = 0; i < rounds; i++)
            {
                data1 -= (((data0 << 4) ^ (data0 >> 5)) + data0) ^ (sum + key[(sum >> 11) & 3]);
                sum += delta;
                data0 -= (((data1 << 4) ^ (data1 >> 5)) + data1) ^ (sum + key[sum & 3]);
            }

            data[0] = data0;
            data[1] = data1;

            return data;
        }
    }
}
