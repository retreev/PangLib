using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using PangLib.IFF.DataModels;

namespace PangLib.IFF 
{
    /// <summary>
    /// Main IFF file class
    /// </summary>
    public class IFFFile 
    {
        /// <summary>
        /// IFF File header magic numbers, if these aren't 
        /// at position 4, the file is not a valid IFF
        /// </summary>
        private ushort[] MagicNumber = new ushort[] { 11, 12, 13 };

        /// <summary>
        /// Currently supported IFF data models
        /// </summary>
        private List<string> DataModels = new List<string>() {
            "AuxPart",
            "Ball",
            "Caddie",
            "Card",
            "Character",
            "Desc",
            "Course",
            "Club",
            "ClubSet",
            "Enchant",
            "HairStyle",
            "Mascot",
            "Match",
            "Title"
        };

        public List<object> Entries = new List<object>();
        public string FilePath;
        public bool IsZIPFile;

        private BinaryReader Reader;
        private string FileDataString;
        private byte[] FileDataBytes;
        private ushort RecordCount;
        private long RecordLength;
        private string Type;

        /// <summary>
        /// Constructs a new IFFFile instance
        /// </summary>
        /// <param name="filePath">The file path of the IFF file</param>
        public IFFFile(string filePath) {
            FileDataString = File.ReadAllText(filePath);
            FileDataBytes = File.ReadAllBytes(filePath);
            FilePath = filePath;
            IsZIPFile = CheckIfZIPFile();
            Type = GetTypeFromFileName();

            if (!IsZIPFile) {
                Reader = new BinaryReader (new MemoryStream(FileDataBytes));

                RecordLength = GetRecordLength();
                RecordCount = GetRecordCount();
            }
        }

        /// <summary>
        /// Checks if a IFF file is a ZIP file
        /// </summary>
        /// <returns>A boolean representing the file being an archive</returns>
        public bool CheckIfZIPFile() {
            return FileDataString.StartsWith("PK");
        }

        /// <summary>
        /// If the IFF file is a ZIP file, this method will extract it to a given path
        /// </summary>
        /// <param name="extractPath">Path to extract the IFF file to</param>
        public void ExtractToDirectory(string extractPath) {
            if (IsZIPFile) {
                using (ZipArchive archive = ZipFile.Open(FilePath, ZipArchiveMode.Update)) {
                    archive.ExtractToDirectory(extractPath);
                }
            }
        }

        /// <summary>
        /// Parses the data from the IFF file and saves it into the Entries property
        /// 
        /// The bytes of a single entry are then marshalled onto a dynamically fetched structure
        /// from PangLib.IFF.DataModels
        /// </summary>
        public void Parse() {
            if (!IsZIPFile && Type != "Unknown") {
                if (CheckMagicNumber()) {
                    for (int i = 0; i < RecordCount; i++) {
                        JumpToRecord(i);

                        byte[] recordData = Reader.ReadBytes((int) RecordLength);

                        var data = Activator.CreateInstance(System.Type.GetType ("PangLib.IFF.DataModels." + Type));

                        int size = Marshal.SizeOf(data);
                        IntPtr ptr = Marshal.AllocHGlobal(size);

                        Array.Resize(ref recordData, size);

                        Marshal.Copy(recordData, 0, ptr, size);

                        data = Marshal.PtrToStructure(ptr, data.GetType ());
                        Marshal.FreeHGlobal(ptr);

                        Entries.Add(data);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the IFF file has one of the magic numbers
        /// </summary>
        /// <returns>A boolean representing the file having a magic number</returns>
        public bool CheckMagicNumber() {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek(4L, SeekOrigin.Begin);
            ushort MagicNumber = Reader.ReadUInt16();
            Reader.BaseStream.Seek(Position, SeekOrigin.Begin);
            return this.MagicNumber.Contains<ushort>(MagicNumber);
        }

        /// <summary>
        /// Gets the record count from the IFF file (the first UInt16)
        /// </summary>
        public ushort GetRecordCount() {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
            ushort RecordCount = Reader.ReadUInt16();
            Reader.BaseStream.Seek(Position, SeekOrigin.Begin);
            return RecordCount;
        }

        /// <summary>
        /// Gets the length of a single record from the IFF file
        ///
        /// This is based on the result from GetRecordCount and the
        /// amount of bytes we have minus the first 8 (header) bytes
        /// </summary>
        /// <returns>The length of a single record</returns>
        public long GetRecordLength() {
            long Position = Reader.BaseStream.Position;
            ushort RecordCount = GetRecordCount();
            long DataLength = Reader.BaseStream.Length - 8L;
            return (long) (DataLength / ((long) RecordCount));
        }

        /// <summary>
        /// Seeks the IFFFile instances BinaryReader to  
        /// the starting position of a given record index
        /// </summary>
        /// <param name="index">Index of the record to seek to</param>
        public void JumpToRecord(int index) {
            Reader.BaseStream.Seek(8L + (RecordLength * index), System.IO.SeekOrigin.Begin);
        }

        /// <summary>
        /// Gets and checks the record type from the file name
        /// of the IFF file
        /// </summary>
        /// <returns>The type of a record if valid, and "Unknown" if invalid</returns>
        public string GetTypeFromFileName() {
            string type = Path.GetFileNameWithoutExtension(FilePath);

            if (DataModels.Contains(type)) {
                return type;
            } 
            else
            {
                return "Unknown";
            }
        }
    }
}