using System.Collections.Generic;
using System.IO;
using PangLib.WEP.Models;

namespace PangLib.WEP.Helpers
{
    public class ElementReader
    {
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