using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    /// <summary>
    /// Helper class to read <see cref="PangLib.WEP.Models.Element"/> structures from WEP files
    /// </summary>
    public class ElementReader
    {
        /// <summary>
        /// Helper method to read a single element from a WEP file
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="version">Version of the WEP file</param>
        /// <returns>A parsed element structure</returns>
        public static Element ReadElement(BinaryReader reader, int version)
        {
            Element element = new Element
            {
                Unknown = reader.ReadInt32(),
                VertexCount = reader.ReadInt32(),
                Name = reader.ReadFixedString(32),
                Matrix1 = reader.ReadMatrix(),
                Matrix2 = reader.ReadMatrix(),
                CourseType = reader.ReadInt32(),
                ClassName = reader.ReadFixedString(32)
            };

            if (version == 114)
            {
                element.Matrix3 = reader.ReadMatrix();
                element.ExtraValues = reader.ReadExtraValues();
            }

            return element;
        }

        /// <summary>
        /// Helper method to read all new elements from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="count">Count of new elements</param>
        /// <returns>List of new elements from the WEP file</returns>
        public static List<Element> ReadAllNewElements(BinaryReader reader, int count)
        {
            List<Element> elements = new List<Element>();

            for (int i = 0; i < count; i++)
            {
                elements.Add(new Element
                    {
                        ExtraValues = reader.ReadExtraValues(),
                        Name = reader.ReadFixedString(64),
                        Matrix1 = reader.ReadMatrix(),
                        Matrix2 = reader.ReadMatrix(),
                        CourseType = reader.ReadInt32()
                    }
                );
            }

            return elements;
        }

        /// <summary>
        /// Helper method to read all elements from a WEP file and return a list of them
        /// </summary>
        /// <param name="reader">BinaryReader instance</param>
        /// <param name="version">Version of the WEP file</param>
        /// <param name="count">Count of elements</param>
        /// <returns>List of elements from the WEP file</returns>
        public static List<Element> ReadAllElements(BinaryReader reader, int version, int count)
        {
            List<Element> elements = new List<Element>();

            for (int i = 0; i < count; i++)
            {
                elements.Add(ReadElement(reader, version));
            }

            return elements;
        }
    }
}