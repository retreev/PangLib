using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangLib.PSP.PAK
{
    /// <summary>
    /// Main PSP PAKFile class
    /// </summary>
    public class PAKFile
    {
        private List<FileEntry> Entries = new List<FileEntry>();
        
        private string ListFilePath;
        private string DataFilePath;
        
        /// <summary>
        /// Constructor for PAK file instance
        /// </summary>
        /// <param name="listFilePath">Path of the PAK file entry file (psppackfilelist.pak)</param>
        /// <param name="dataFilePath">Path of the PAK data file (pspdata.pak)</param>
        public PAKFile(string listFilePath, string dataFilePath)
        {
            ListFilePath = listFilePath;
            DataFilePath = dataFilePath;
            
            ReadListFile(listFilePath);
        }

        /// <summary>
        /// Reads the PAK file entry file to retrieve the list of file entries
        /// </summary>
        /// <param name="listFilePath">Path of the PAK file entry file</param>
        private void ReadListFile(string listFilePath)
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(listFilePath))))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    FileEntry fileEntry = new FileEntry
                    {
                        Type = reader.ReadUInt16(),
                        Unknown1 = reader.ReadUInt16(),
                        Offset = reader.ReadUInt32(),
                        FileSize = reader.ReadUInt32(),
                        RealFileSize = reader.ReadUInt32()
                    };

                    List<char> stringChars = new List<char>();

                    while (reader.PeekChar() != 0x00)
                    {
                        stringChars.Add(reader.ReadChar());
                    }

                    char[] chars = stringChars.ToArray();
                    byte[] bytes = Encoding.UTF8.GetBytes(chars);

                    fileEntry.FileName = Encoding.UTF8.GetString(bytes);

                    while (reader.PeekChar() == 0x00)
                    {
                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                    }
                    
                    Entries.Add(fileEntry);
                }
            }
        }

        /// <summary>
        /// Extracts the PAK data file
        /// </summary>
        /// <param name="extractPath">Path to extract the PAK contents to</param>
        public void ExtractFiles(string extractPath)
        {
            byte[] data = null;

            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(DataFilePath))))
            {
                Entries.ForEach(fileEntry =>
                {
                    reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                    data = reader.ReadBytes((int)fileEntry.FileSize);
                    
                    File.WriteAllBytes(Path.Combine(extractPath, fileEntry.FileName), data);
                });   
            }
        }
    }

    public struct FileEntry
    {
        public ushort Type;
        public ushort Unknown1;
        public uint Offset;
        public uint FileSize;
        public uint RealFileSize;
        public string FileName;
    }
}