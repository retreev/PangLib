using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace PangLib.DAT
{
    public class DATFile
    {
        public List<string> Entries = new List<string> ();

        private BinaryReader Reader;

        public string FilePath;

        private byte[] FileDataBytes;

        private Encoding FileEncoding;

        public DATFile (string filePath) {
            this.FileDataBytes = File.ReadAllBytes (filePath);
            this.FilePath = filePath;
            this.FileEncoding = this.GetEncodingFromFileName();

            this.Reader = new BinaryReader(new MemoryStream(this.FileDataBytes), this.FileEncoding);
        }

        public void Parse () {
            List<char> stringChars = new List<char>();

            while (this.Reader.BaseStream.Position < this.Reader.BaseStream.Length)
            {
                if (this.Reader.PeekChar() != 0x00)
                {
                    stringChars.Add(this.Reader.ReadChar());
                }
                else
                {
                    char[] chars = stringChars.ToArray();
                    byte[] bytes = this.FileEncoding.GetBytes(chars);

                    this.Entries.Add(this.FileEncoding.GetString(bytes));

                    this.Reader.BaseStream.Seek(1L, SeekOrigin.Current);
                    stringChars = new List<char>();
                }
            }
        }

        private Encoding GetEncodingFromFileName () {
            string fileName = Path.GetFileNameWithoutExtension (this.FilePath).ToLower();

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

        public void SetEncoding (Encoding encoding) {
            this.FileEncoding = encoding;
        }
    }
}
