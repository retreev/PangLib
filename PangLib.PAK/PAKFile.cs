using System;
using System.Collections.Generic;
using System.IO;

namespace PangLib.PAK
{
    public class PAKFile
    {
        public string FilePath;

        private List<FileEntry> Entries = new List<FileEntry>();
        private BinaryReader Reader;
        private byte[] FileDataBytes;
        private uint FileListOffset;
        private uint FileCount;
        private byte Signature;

        public PAKFile(string filePath)
        {
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

                Entries.Add(fileEntry);
            }

            Reader.BaseStream.Seek(Position, SeekOrigin.Begin);
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
