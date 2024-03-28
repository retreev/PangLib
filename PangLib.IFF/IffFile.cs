using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace PangLib.IFF;

/// <summary>
/// Main IFF file class
/// </summary>
public class IffFile<T> where T : new()
{
    /// <summary>
    /// List of IFF file entries
    /// </summary>
    public List<T> Entries { get; } = [];

    /// <summary>
    /// ID determining relation to other IFF files
    /// </summary>
    public ushort BindingId { get; set; }
    
    /// <summary>
    /// Version of this IFF file
    /// </summary>
    public uint Version { get; set; }

    /// <summary>
    /// Constructs a new IFFFile instance
    /// </summary>
    public IffFile() { }

    /// <summary>
    /// Initializes a new IFFFile instance from a stream of IFF file data
    /// </summary>
    /// <param name="data">Stream containing IFF file data</param>
    public IffFile(Stream data)
    {
        Parse(data);
    }
        
    /// <summary>
    /// Parses the data from the IFF file and saves it into the Entries property
    /// 
    /// The bytes of a single entry are then marshalled into the structure provided by the
    /// generic type of the IffFile instance
    /// </summary>
    /// <param name="stream">Stream containing IFF file data</param>
    /// <exception cref="InvalidCastException">Is thrown when the size of a single record mismatches the size of the given generic structure</exception>
    private void Parse(Stream stream)
    {
        using BinaryReader reader = new(stream);
        
        if (new string(reader.ReadChars(2)) == "PK")
        {
            throw new NotSupportedException("The given IFF file is a ZIP file, please unpack it before attempting to parse it");
        }

        reader.BaseStream.Seek(0, SeekOrigin.Begin);

        ushort recordCount = reader.ReadUInt16();
        long recordLength = (reader.BaseStream.Length - 8L) / recordCount;
        BindingId = reader.ReadUInt16();
        Version = reader.ReadUInt32();
        
        Type type = typeof(T);
        
        int size = Marshal.SizeOf(new T());
        if (recordLength != size)
        {
            throw new ArgumentOutOfRangeException(nameof(size),
                "The requested model doesn't meet the size expectations of the given Iff File." +
                $"RequestedModel: '{type.FullName}' ModelSize: '{size}' ExpectedSize: {recordLength}");
        }

        for (int i = 0; i < recordCount; i++)
        {
            byte[] recordData = reader.ReadBytes((int) recordLength);

            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(recordData, 0, ptr, size);

            T data = (T) Marshal.PtrToStructure(ptr, type);
            Marshal.FreeHGlobal(ptr);

            Entries.Add(data);
        }
    }

    /// <summary>
    /// Save a IffFile instance to a file
    /// </summary>
    /// <param name="filePath">File path to save the IFF file to</param>
    public void Save(string filePath)
    {
        using BinaryWriter writer = new(File.Open(filePath, FileMode.Create, FileAccess.Write));
        
        writer.Write((ushort) Entries.Count);
        writer.Write(BindingId);
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