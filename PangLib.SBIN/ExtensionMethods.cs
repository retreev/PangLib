using System.IO;
using System.Linq;
using System.Text;
using PangLib.SBIN.Models;

namespace PangLib.SBIN;

public static class ExtensionMethods
{
    /// <summary>
    /// Read a string from a fixed amount of bytes
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <param name="length">String length</param>
    /// <param name="encoding">String encoding</param>
    /// <returns>The read string</returns>
    public static string ReadFixedString(this BinaryReader reader, int length, Encoding encoding = null)
    {
        if (encoding == null)
        {
            encoding = Encoding.GetEncoding(51949);
        }
            
        char[] chars = reader.ReadChars(length).TakeWhile(c => c != 0x00).ToArray();
        byte[] bytes = encoding.GetBytes(chars);
            
        return encoding.GetString(bytes);
    }

    /// <summary>
    /// Read a pascal-style string
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <param name="encoding">String encoding</param>
    /// <returns>The read string</returns>
    public static string ReadPascalString(this BinaryReader reader, Encoding encoding = null)
    {
        int length = reader.ReadInt32();
        return ReadFixedString(reader, length, encoding);
    }
        
    /// <summary>
    /// Read a vector from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Vector structure</returns>
    public static Vector2<float> ReadVector2(this BinaryReader reader)
    {
        return new Vector2<float>
        {
            X = reader.ReadSingle(),
            Y = reader.ReadSingle(),
        };
    }
        
    /// <summary>
    /// Read a vector from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Vector structure</returns>
    public static Vector3<float> ReadVector3(this BinaryReader reader)
    {
        return new Vector3<float>
        {
            X = reader.ReadSingle(),
            Y = reader.ReadSingle(),
            Z = reader.ReadSingle()
        };
    }

    /// <summary>
    /// Read a vertex from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Vertex structure</returns>
    public static Vertex ReadVertex(this BinaryReader reader)
    {
        return new Vertex
        {
            Number = reader.ReadInt32(),
            Index = reader.ReadInt32()
        };
    }
}