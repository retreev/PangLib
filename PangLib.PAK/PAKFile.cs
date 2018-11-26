using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PangLib.Utilities.Cryptography;
using PangLib.Utilities.Compression;

namespace PangLib.PAK
{
    public class PAKFile
    {
        public List<FileEntry> Entries = new List<FileEntry>();
        public string FilePath;

        private BinaryReader Reader;
        private byte[] FileDataBytes;
        private uint FileListOffset;
        private uint FileCount;
        private byte Signature;

        private dynamic Key;

        public PAKFile(string filePath, dynamic key)
        {
            Key = key;
            FileDataBytes = File.ReadAllBytes(filePath);

            Reader = new BinaryReader(new MemoryStream(FileDataBytes));

            ReadFileHeader();
            ReadFileEntries();
        }

        public void ReadFileHeader()
        {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek(-9L, SeekOrigin.End);

            FileListOffset = Reader.ReadUInt32();
            FileCount = Reader.ReadUInt32();
            Signature = Reader.ReadByte();

            Reader.BaseStream.Seek(Position, SeekOrigin.Begin);
        }

        public void ReadFileEntries()
        {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek(FileListOffset, SeekOrigin.Begin);

            for (uint i = 0; i < FileCount; i++)
            {
                FileEntry fileEntry = new FileEntry();

                fileEntry.FileNameLength = Reader.ReadByte();
                fileEntry.Compression = Reader.ReadByte();
                fileEntry.Offset = Reader.ReadUInt32();
                fileEntry.FileSize = Reader.ReadUInt32();
                fileEntry.RealFileSize = Reader.ReadUInt32();

                byte[] tempName = Reader.ReadBytes(fileEntry.FileNameLength);

                if (fileEntry.Compression < 4 && fileEntry.Compression > -1)
                {
                    uint decryptionKey = (uint) Key;

                    fileEntry.Unknown1 = Reader.ReadByte();
                    fileEntry.FileName = Encoding.UTF8.GetString(XOR.Cipher(tempName, decryptionKey));
                }
                else
                {
                    uint[] decryptionKey = (uint[]) Key;

                    fileEntry.Compression ^= 0x20;

                    fileEntry.FileName = DecryptFileName(tempName, decryptionKey);

                    uint[] decryptionData = new uint[]
                    {
                        fileEntry.Offset,
                        fileEntry.RealFileSize
                    };

                    uint[] resultData = XTEA.Decipher(16, decryptionData, decryptionKey);

                    fileEntry.Offset = resultData[0];
                    fileEntry.RealFileSize = resultData[1];
                }

                Entries.Add(fileEntry);
            }

            Reader.BaseStream.Seek(Position, SeekOrigin.Begin);
        }

        public void ReadFiles()
        {
            byte[] uncompressedData;
            byte[] compressedData;
            byte[] decompressedData;
            Entries.ForEach(fileEntry =>
            {
                switch (fileEntry.Compression)
                {
                    case 0:
                        Reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                        uncompressedData = Reader.ReadBytes((int)fileEntry.FileSize);
                        File.WriteAllBytes(fileEntry.FileName, uncompressedData);
                        break;
                    case 1:
                        Reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                        compressedData = Reader.ReadBytes((int)fileEntry.FileSize);
                        decompressedData = LZ77.Decompress(compressedData, fileEntry.FileSize, fileEntry.RealFileSize, fileEntry.Compression);
                        File.WriteAllBytes(fileEntry.FileName, decompressedData);
                        break;
                    case 2:
                        Directory.CreateDirectory(fileEntry.FileName);
                        break;
                    case 3:
                        Reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                        compressedData = Reader.ReadBytes((int)fileEntry.FileSize);
                        decompressedData = LZ77.Decompress(compressedData, fileEntry.FileSize, fileEntry.RealFileSize, fileEntry.Compression);
                        File.WriteAllBytes(fileEntry.FileName, decompressedData);
                        break;
                }
            });
        }

        private string DecryptFileName(byte[] fileNameBuffer, uint[] key)
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

    public struct FileEntry
    {
        public byte FileNameLength;
        public byte Compression;
        public uint Offset;
        public uint FileSize;
        public uint RealFileSize;
        public string FileName;
        public byte Unknown1;
    }
}
