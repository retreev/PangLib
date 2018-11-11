namespace PangLib.Utilities.Cryptography
{
    public static class XTEA
    {
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
