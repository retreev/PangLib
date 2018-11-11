using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangLib.DAT
{
    /// <summary>
    /// Main DAT file class
    /// </summary>
    public class DATFile
    {
        public List<string> Entries = new List<string>();
        public string FilePath;

        private BinaryReader Reader;
        private byte[] FileDataBytes;
        private Encoding FileEncoding;

        /// <summary>
        /// Constructs a new DATFile instance
        /// </summary>
        /// <param name="filePath">The file path of the DAT file</param>
        public DATFile(string filePath)
        {
            FileDataBytes = File.ReadAllBytes(filePath);
            FilePath = filePath;
            FileEncoding = GetEncodingFromFileName();

            Reader = new BinaryReader(new MemoryStream(FileDataBytes), FileEncoding);
        }

        /// <summary>
        /// Parses the data from the DAT file
        /// </summary>
        public void Parse()
        {
            List<char> stringChars = new List<char>();

            while (Reader.BaseStream.Position < Reader.BaseStream.Length)
            {
                if (Reader.PeekChar() != 0x00)
                {
                    stringChars.Add(Reader.ReadChar());
                }
                else
                {
                    char[] chars = stringChars.ToArray();
                    byte[] bytes = FileEncoding.GetBytes(chars);

                    Entries.Add(FileEncoding.GetString(bytes));

                    Reader.BaseStream.Seek(1L, SeekOrigin.Current);
                    stringChars = new List<char>();
                }
            }
        }

        /// <summary>
        /// Tries to get the file encoding based on
        /// the naming scheme of the files
        ///
        /// Falls back on UTF-8 as default
        /// </summary>
        /// <returns>Encoding of the DAT file</returns>
        private Encoding GetEncodingFromFileName()
        {
            string fileName = Path.GetFileNameWithoutExtension(FilePath).ToLower();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Encoding targetEncoding;

            switch (fileName)
            {
                case "korea":
                    targetEncoding = Encoding.GetEncoding(51949);
                    break;
                case "japan":
                    targetEncoding = Encoding.GetEncoding(932);
                    break;
                case "english":
                    targetEncoding = Encoding.GetEncoding(65001);
                    break;
                case "thailand":
                    targetEncoding = Encoding.GetEncoding(874);
                    break;
                case "indonesia":
                    targetEncoding = Encoding.GetEncoding(65001);
                    break;
                case "brasil":
                case "spanish":
                case "german":
                case "french":
                    targetEncoding = Encoding.GetEncoding(28591);
                    break;
                default:
                    targetEncoding = Encoding.GetEncoding(65001);
                    break;
            }

            return targetEncoding;
        }

        /// <summary>
        /// Sets the encoding to be used by the DATFile instance
        /// </summary>
        /// <param name="encoding">Encoding to set</param>
        public void SetEncoding(Encoding encoding)
        {
            FileEncoding = encoding;
        }
    }
}
