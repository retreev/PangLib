using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangLib.Wii.ECB
{
    /// <summary>
    /// Main Wii ECB file class
    /// </summary>
    public class ECBFile
    {
        private List<CharData> CharTable1 = new List<CharData>();
        private List<CharData> CharTable2 = new List<CharData>();

        public List<string> Dialogue = new List<string>();

        private string FilePath;

        /// <summary>
        /// Constructor for ECB file instance
        /// </summary>
        /// <param name="filePath">file path of the ECB file</param>
        public ECBFile (string filePath)
        {
            FilePath = filePath;

            Parse();
        }

        /// <summary>
        /// Parses the contents of the ECB file
        /// </summary>
        private void Parse ()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath)), Encoding.ASCII))
            {
                if (new string(reader.ReadChars(3)) != "ecb")
                    return;
                
                reader.BaseStream.Seek(6L, SeekOrigin.Current);

                uint charTable1Size = reader.ReadUInt16();
                uint charTable2Size = reader.ReadUInt16();

                reader.BaseStream.Seek(19L, SeekOrigin.Current);

                for (int i = 0; i < charTable1Size; i++)
                {
                    CharData charData = new CharData();

                    charData.TableIndex = reader.ReadByte();
                    charData.Index = reader.ReadByte();

                    reader.BaseStream.Seek(4L, SeekOrigin.Current);

                    charData.CharIndex = reader.ReadByte();
                    charData.Char = reader.ReadChar();

                    CharTable1.Add(charData);
                }

                for (int i = 0; i < charTable2Size; i++)
                {
                    CharData charData = new CharData();

                    charData.TableIndex = reader.ReadByte();
                    charData.Index = reader.ReadByte();

                    reader.BaseStream.Seek(4L, SeekOrigin.Current);

                    charData.CharIndex = reader.ReadByte();
                    charData.Char = reader.ReadChar();

                    CharTable2.Add(charData);
                }

                List<char> stringChars = new List<char>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    stringChars.Add(reader.ReadChar());
                }

                char[] chars = stringChars.ToArray();
                byte[] bytes = Encoding.ASCII.GetBytes(chars);

                string pureString = Encoding.ASCII.GetString(bytes);

                PrepareDialogue(pureString);
            }
        }

        /// <summary>
        /// Prepares dialogue strings before saving (splits at triple null byte and removes null bytes)
        /// </summary>
        /// <param name="pureString">Unchanged string from the parsing output</param>
        private void PrepareDialogue (string pureString)
        {
            string[] dialogues = pureString.Split(new string[] {"\0\0\0"}, StringSplitOptions.None);

            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogues[i] = dialogues[i].Replace("\0", "");
            }

            Dialogue = new List<string>(dialogues);
        }
    }

    public struct CharData
    {
        public byte TableIndex;
        public byte Index;
        public byte CharIndex;
        public char Char;
    }
}
