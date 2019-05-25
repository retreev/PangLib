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
        /// <summary>
        /// List of IFF file entries
        /// </summary>
        public List<T> Entries { get; } = new List<T>();

        /// <summary>
        /// ID determining relation to other IFF files
        /// </summary>
        public ushort BindingID { get; set; }
        
        /// <summary>
        /// Version of this IFF file
        /// </summary>
        public uint Version { get; set; }

        /// <summary>
        /// Constructs a new IFFFile instance
        /// </summary>
        public IFFFile() { }

        /// <summary>
        /// Initializes a new IFFFile instance from a stream of IFF file data
        /// </summary>
        /// <param name="data">Stream containing IFF file data</param>
        public IFFFile(Stream data)
        {
            Parse(data);
        }
            
        /// <summary>
        /// Parses the data from the IFF file and saves it into the Entries property
        /// 
        /// The bytes of a single entry are then marshalled into the structure provided by the
        /// generic type of the IFFFile instance
        /// </summary>
        /// <param name="stream">Stream containing IFF file data</param>
        /// <exception cref="InvalidCastException">Is thrown when the size of a single record mismatches the size of the given generic structure</exception>
        private void Parse(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                if (new string(reader.ReadChars(2)) == "PK")
                {
                    throw new NotSupportedException("The given IFF file is a ZIP file, please unpack it before attempting to parse it");
                }

                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                ushort recordCount = reader.ReadUInt16();
                long recordLength = ((reader.BaseStream.Length - 8L) / (recordCount));
                BindingID = reader.ReadUInt16();
                Version = reader.ReadUInt32();

                for (int i = 0; i < recordCount; i++)
                {
                    reader.BaseStream.Seek(8L + (recordLength * i), System.IO.SeekOrigin.Begin);

                    byte[] recordData = reader.ReadBytes((int) recordLength);

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
    }
}
