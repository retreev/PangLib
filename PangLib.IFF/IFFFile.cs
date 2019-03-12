using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace PangLib.IFF
{
    /// <summary>
    /// Main IFF file class
    /// </summary>
    public class IFFFile<T> where T : new()
    {
        public List<T> Entries = new List<T>();
        public string FilePath;
        public bool IsZIPFile;

        private ushort RecordCount;
        private ushort BindingID;
        private uint Version;

        private long RecordLength;

        /// <summary>
        /// Constructs a new IFFFile instance
        /// </summary>
        /// <param name="filePath">The file path of the IFF file</param>
        public IFFFile(string filePath)
        {
            FilePath = filePath;

            Parse();
        }

        /// <summary>
        /// If the IFF file is a ZIP file, this method will extract it to a given path
        /// </summary>
        /// <param name="extractPath">Path to extract the IFF file to</param>
        public void ExtractToDirectory(string extractPath)
        {
            if (IsZIPFile)
            {
                using (ZipArchive archive = ZipFile.Open(FilePath, ZipArchiveMode.Update))
                {
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
        private void Parse()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                if ((IsZIPFile = (new string(reader.ReadChars(2)) == "PK")) == true)
                    return;

                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                RecordCount = reader.ReadUInt16();
                RecordLength = (long) ((reader.BaseStream.Length - 8L) / ((long) RecordCount));
                BindingID = reader.ReadUInt16();
                Version = reader.ReadUInt32();

                for (int i = 0; i < RecordCount; i++)
                {
                    reader.BaseStream.Seek(8L + (RecordLength * i), System.IO.SeekOrigin.Begin);

                    byte[] recordData = reader.ReadBytes((int) RecordLength);

                    T data = new T();

                    int size = Marshal.SizeOf(data);
                    IntPtr ptr = Marshal.AllocHGlobal(size);

                    if (recordData.Length != size)
                    {
                        throw new InvalidCastException(
                            $"The record length ({recordData.Length}) mismatches the length of the passed structure ({size})");
                    }

                    Marshal.Copy(recordData, 0, ptr, size);

                    data = (T) Marshal.PtrToStructure(ptr, data.GetType());
                    Marshal.FreeHGlobal(ptr);

                    Entries.Add(data);
                }
            }
        }
    }
}
