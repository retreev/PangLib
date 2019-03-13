using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
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
        
        public ushort BindingID { get; set; }
        public uint Version { get; set; }

        private ushort RecordCount;
        private long RecordLength;

        /// <summary>
        /// Constructs a new IFFFile instance
        /// </summary>
        /// <param name="filePath">The file path of the IFF file</param>
        public IFFFile() { }

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

        /// <summary>
        /// Save a IFFFile instance to a file
        /// </summary>
        /// <param name="filePath">File path to save the IFF file to</param>
        public void Save(string filePath)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create, FileAccess.Write)))
            {
                writer.Write((ushort) Entries.Count);
                writer.Write(BindingID);
                writer.Write(Version);
                
                Entries.ForEach(entry =>
                {
                    int size = Marshal.SizeOf(entry);
                    byte[] arr = new byte[size];

                    IntPtr ptr = Marshal.AllocHGlobal(size);
                    Marshal.StructureToPtr(entry, ptr, true);
                    Marshal.Copy(ptr, arr, 0, size);
                    Marshal.FreeHGlobal(ptr);
                    
                    writer.Write(arr);
                });
            }
        }

        /// <summary>
        /// Load an IFF file into an IFF
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static IFFFile<T> Load(string filePath)
        {
            IFFFile<T> IFF = new IFFFile<T> {FilePath = filePath};

            IFF.Parse();

            return IFF;
        }
    }
}
