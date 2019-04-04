using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangLib.PSP.NOP
{
    /// <summary>
    /// Main PSP NOP file class
    /// </summary>
    public class NOPFile
    {
        private List<FileEntry> Entries = new List<FileEntry>();
        
        private string FilePath;

        private uint FileListOffset;
        private uint FileCount;
        private uint Signature;
        
        /// <summary>
        /// Constructor for NOP file instance
        /// </summary>
        /// <param name="filePath"></param>
        public NOPFile(string filePath)
        {
            FilePath = filePath;
            
            ReadMetadata();
        }

        /// <summary>
        /// Reads the NOP file metadata, including file list information and the file list
        /// </summary>
        private void ReadMetadata()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                reader.BaseStream.Seek(-9L, SeekOrigin.End);

                FileListOffset = reader.ReadUInt32();
                FileCount = reader.ReadUInt32();
                Signature = reader.ReadByte();
                
                reader.BaseStream.Seek(FileListOffset, SeekOrigin.Begin);

                for (uint i = 0; i < FileCount; i++)
                {
                    FileEntry fileEntry = new FileEntry
                    {
                        FileNameLength = reader.ReadByte(),
                        Type = reader.ReadByte(),
                        Offset = reader.ReadUInt32(),
                        FileSize = reader.ReadUInt32(),
                        RealFileSize = reader.ReadUInt32()
                    };

                    fileEntry.FileName = Encoding.UTF8.GetString(reader.ReadBytes(fileEntry.FileNameLength));
                    
                    Entries.Add(fileEntry);
                    
                    reader.BaseStream.Seek(1L, SeekOrigin.Current);
                }
            }
        }

        /// <summary>
        /// Extracts the files from the file list
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

                    string directory = Path.GetDirectoryName(fileEntry.FileName);

                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }

                    File.WriteAllBytes(fileEntry.FileName, data);
                });
            }
        }
    }

    public struct FileEntry
    {
        public byte FileNameLength;
        public byte Type;
        public uint Offset;
        public uint FileSize;
        public uint RealFileSize;
        public string FileName;
    }
}