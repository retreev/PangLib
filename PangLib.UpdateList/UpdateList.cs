using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using PangLib.Utilities.Cryptography;

namespace PangLib.UpdateList
{
    public class UpdateList
    {
        public string Document;

        private uint[] DecryptionKey;
        private string FilePath;

        public UpdateList(string filePath)
        {
            FilePath = filePath;
        }

        public void Parse()
        {
            if (DecryptionKey == null)
            {
                throw new NullReferenceException("DecryptionKey needs to be set using the SetDecryptionKey instance method!");
            }

            Span<byte> updateList = File.ReadAllBytes(FilePath);

            for (int i = 0; i < updateList.Length; i += 8)
            {
                Span<byte> chunk = updateList.Slice(i, 8);
                Span<uint> decrypted = XTEA.Decipher(16, MemoryMarshal.Cast<byte, uint>(chunk).ToArray(), DecryptionKey);
                Span<byte> resource = MemoryMarshal.AsBytes(decrypted);
                resource.CopyTo(chunk);
            }

            Document = Encoding.UTF8.GetString(updateList.ToArray());
        }

        public void SetDecryptionKey(uint[] key)
        {
            DecryptionKey = key;
        }
    }
}
