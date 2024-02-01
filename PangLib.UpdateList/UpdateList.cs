using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using PangLib.Utilities.Cryptography;

namespace PangLib.UpdateList
{
    /// <summary>
    /// Main UpdateList file class
    /// </summary>
    public class UpdateList
    {
        public string Document;

        private uint[] DecryptionKey;
        private string FilePath;

        /// <summary>
        /// Constructor for the UpdateList class
        /// </summary>
        /// <param name="filePath">Path to the updatelist file</param>
        public UpdateList(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// Decrypts and parses the updatelist file
        ///
        /// Saves the parsed updatelist in the Document instance attribute
        /// </summary>
        public void Parse(bool decrypt = true)
        {
            if (DecryptionKey == null)
            {
                throw new NullReferenceException("DecryptionKey needs to be set using the SetDecryptionKey instance method!");
            }

            Span<byte> updateList = File.ReadAllBytes(FilePath);
if(decrypt)
{      for (int i = 0; i < updateList.Length; i += 8)
            {
                Span<byte> chunk = updateList.Slice(i, 8);
                Span<uint> decrypted = XTEA.Decipher(16, MemoryMarshal.Cast<byte, uint>(chunk).ToArray(), DecryptionKey);
                Span<byte> resource = MemoryMarshal.AsBytes(decrypted);
                resource.CopyTo(chunk);
            }
}
            else
            {

               var newArray = new byte[updateList.Length - updateList.Length % 8 + 8];
		updateList.CopyTo(newArray);
		updateList = newArray;
		for (int i = 0; i < updateList.Length; i += 8)
		{
			Span<byte> chunk = updateList.Slice(i, 8);
			MemoryMarshal.AsBytes<uint>(XTEA.Encipher(16, MemoryMarshal.Cast<byte, uint>(chunk).ToArray(), DecryptionKey)).CopyTo(chunk);
		}
            }
            Document = Encoding.UTF8.GetString(updateList.ToArray());
        }

        /// <summary>
        /// Sets the decryption key for the updatelist decryption
        /// </summary>
        /// <param name="key">Decryption key</param>
        public void SetDecryptionKey(uint[] key)
        {
            DecryptionKey = key;
        }
    }
}
