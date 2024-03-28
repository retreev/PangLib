using System.IO;
using System.Linq;
using System.Text;
using PangLib.WEP.Models;

namespace PangLib.WEP;

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
    /// Read extra values from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed extra values</returns>
    public static ExtraValues ReadExtraValues(this BinaryReader reader)
    {
        return new ExtraValues
        {
            GUID = reader.ReadInt32(),
            Unknown = reader.ReadInt32()
        };
    }

    /// <summary>
    /// Read an area from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Area structure</returns>
    public static Area ReadArea(this BinaryReader reader)
    {
        return new Area
        {
            Min = reader.ReadVector3(),
            Max = reader.ReadVector3()
        };
    }

    /// <summary>
    /// Read a matrix from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Matrix structure</returns>
    public static Matrix ReadMatrix(this BinaryReader reader)
    {
        return new Matrix
        {
            Column1 = reader.ReadVector3(),
            Column2 = reader.ReadVector3(),
            Column3 = reader.ReadVector3(),
            Column4 = reader.ReadVector3()
        };
    }

    /// <summary>
    /// Read a point from the current stream
    /// </summary>
    /// <param name="reader">BinaryReader instance</param>
    /// <returns>The parsed Point structure</returns>
    public static Point ReadPoint(this BinaryReader reader)
    {
        return new Point
        {
            X = reader.ReadSingle(),
            Z = reader.ReadSingle()
        };
    }
}