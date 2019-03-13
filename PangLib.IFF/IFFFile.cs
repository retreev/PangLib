using System;
using System.Collections.Generic;
using System.IO;
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
        /// Parses the data from the IFF file and saves it into the Entries property
        /// 
        /// The bytes of a single entry are then marshalled into the structure provided by the
        /// generic type of the IFFFile instance
        /// </summary>
        /// <exception cref="InvalidCastException">Is thrown when the size of a single record mismatches the size of the given generic structure</exception>
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
