using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PangLib.Utilities.Cryptography;
using PangLib.Utilities.Compression;

namespace PangLib.PAK
{
    /// <summary>
    /// Main PAK file class
    /// </summary>
    public class PAKFile
    {
        /// <summary>
        /// File entries included in this archive
        /// </summary>
        public List<FileEntry> Entries { get; } = new List<FileEntry>();
        
        /// <summary>
        /// File path of the PAK archive
        /// </summary>
        private readonly string FilePath;

        /// <summary>
        /// Key used for en/decrypting parts of file entries
        /// </summary>
        private readonly dynamic Key;

        /// <summary>
        /// Constructor for the PAK file instance
        /// </summary>
        /// <param name="filePath">Path of the PAK file</param>
        /// <param name="key">Decryption key for encrypted fields</param>
        public PAKFile(string filePath, dynamic key)
        {
            FilePath = filePath;
            Key = key;

            ReadMetadata();
        }

        /// <summary>
        /// Reads the PAK file metadata, including file list information and the file list
        /// </summary>
        /// <exception cref="NotSupportedException">Is thrown if the given PAK file does not have a valid signature</exception>
        private void ReadMetadata()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                reader.BaseStream.Seek(-9L, SeekOrigin.End);

                uint fileListOffset = reader.ReadUInt32();
                uint fileCount = reader.ReadUInt32();

                if ((reader.ReadByte()) != 0x12)
                {
                    throw new NotSupportedException("The signature of this PAK file is invalid!");    
                }

                reader.BaseStream.Seek(fileListOffset, SeekOrigin.Begin);

                for (uint i = 0; i < fileCount; i++)
                {
                    FileEntry fileEntry = new FileEntry();

                    fileEntry.FileNameLength = reader.ReadByte();
                    fileEntry.Compression = reader.ReadByte();
                    fileEntry.Offset = reader.ReadUInt32();
                    fileEntry.FileSize = reader.ReadUInt32();
                    fileEntry.RealFileSize = reader.ReadUInt32();

                    byte[] tempName = reader.ReadBytes(fileEntry.FileNameLength);

                    if (fileEntry.Compression < 4 && fileEntry.Compression > -1)
                    {
                        uint decryptionKey = (uint) Key;

                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                        fileEntry.FileName = Encoding.UTF8.GetString(XOR.Cipher(tempName, decryptionKey));
                    }
                    else
                    {
                        uint[] decryptionKey = (uint[]) Key;

                        fileEntry.Compression ^= 0x20;

                        fileEntry.FileName = DecryptFileName(tempName, decryptionKey);

                        uint[] decryptionData = {
                            fileEntry.Offset,
                            fileEntry.RealFileSize
                        };

                        uint[] resultData = XTEA.Decipher(16, decryptionData, decryptionKey);

                        fileEntry.Offset = resultData[0];
                        fileEntry.RealFileSize = resultData[1]; 
                    }

                    Entries.Add(fileEntry);
                }
            }
        }

        /// <summary>
        /// Extracts the files from the file list
        ///
        /// Also performs decompression or creation of folders where necessary
        /// </summary>
        public void ExtractFiles()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                byte[] data = null;

                Entries.ForEach(fileEntry =>
                {
                    reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                    data = reader.ReadBytes((int)fileEntry.FileSize);

                    switch (fileEntry.Compression)
                    {
                        case 1:
                        case 3:
                            data = LZ77.Decompress(data, fileEntry.FileSize, fileEntry.RealFileSize, fileEntry.Compression);
                            break;
                        case 2:
                            Directory.CreateDirectory(fileEntry.FileName);
                            break;
                        default:
                            Debug.WriteLine($"Unknown compression value '{fileEntry.Compression.ToString()}'");
                            break;
                    }

                    if (fileEntry.FileSize != 0) {
                        File.WriteAllBytes(fileEntry.FileName, data);
                    }
                });
            }
        }

        /// <summary>
        /// Decrypts the name of a file using XTEA
        /// </summary>
        /// <param name="fileNameBuffer">Bytes of the file name</param>
        /// <param name="key">Key to decrypt the filename with</param>
        /// <returns>The decrypted filename</returns>
        private static string DecryptFileName(byte[] fileNameBuffer, uint[] key)
        {
            Span<byte> nameSpan = fileNameBuffer;

            for (int j = 0; j < nameSpan.Length; j = j + 8)
            {
                Span<byte> chunk = nameSpan.Slice(j, 8);
                Span<uint> decrypted = XTEA.Decipher(16, MemoryMarshal.Cast<byte, uint>(chunk).ToArray(), key);
                Span<byte> resource = MemoryMarshal.AsBytes(decrypted);
                resource.CopyTo(chunk);
            }

            return Encoding.UTF8.GetString(nameSpan.ToArray().TakeWhile(x => x != 0x00).ToArray());
        }
    }

    /// <summary>
    /// Main structure of file entries
    /// </summary>
    public struct FileEntry
    {
        /// <summary>
        /// Length of the file name
        /// </summary>
        public byte FileNameLength { get; set; }
        
        /// <summary>
        /// Compression flag determining if the file is compressed, or a directory
        /// </summary>
        public byte Compression { get; set; }
        
        /// <summary>
        /// Offset of the file data from the beginning of the archive
        /// </summary>
        public uint Offset { get; set; }
        
        /// <summary>
        /// (Compressed) size of the file
        /// </summary>
        public uint FileSize { get; set; }
        
        /// <summary>
        /// Real size of the file
        /// </summary>
        public uint RealFileSize { get; set; }
        
        /// <summary>
        /// Full path and name of the file
        /// </summary>
        public string FileName { get; set; }
    }
}
