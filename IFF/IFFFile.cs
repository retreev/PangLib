using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using IFF.DataModels;

namespace IFF {
    public class IFFFile {

        private ushort[] MagicNumber = new ushort[] { 11, 12, 13 };

        private List<string> DataModels = new List<string> () {
            "Character",
            "Desc",
            "Course",
            "Club",
            "ClubSet"
        };

        public List<object> Entries = new List<object> ();

        private BinaryReader Reader;

        public string FilePath;

        private string FileDataString;

        private byte[] FileDataBytes;

        public bool IsZIPFile;

        private ushort RecordCount;

        private long RecordLength;

        private string Type;

        public IFFFile (string filePath) {
            this.FileDataString = File.ReadAllText (filePath);
            this.FileDataBytes = File.ReadAllBytes (filePath);
            this.FilePath = filePath;
            this.IsZIPFile = CheckIfZIPFile ();
            this.Type = GetTypeFromFileName ();

            if (!this.IsZIPFile) {
                this.Reader = new BinaryReader (new MemoryStream (FileDataBytes));

                this.RecordLength = this.GetRecordLength ();
                this.RecordCount = this.GetRecordCount ();
            }
        }

        public bool CheckIfZIPFile () {
            return FileDataString.StartsWith ("PK");
        }

        public void ExtractToDirectory (string extractPath) {
            if (this.IsZIPFile) {
                using (ZipArchive archive = ZipFile.Open (FilePath, ZipArchiveMode.Update)) {
                    archive.ExtractToDirectory (extractPath);
                }
            }
        }

        public void Parse () {
            if (!this.IsZIPFile && this.Type != "Unknown") {
                if (this.CheckMagicNumber ()) {
                    for (int i = 0; i < this.RecordCount; i++) {
                        this.JumpToRecord (i);

                        byte[] recordData = Reader.ReadBytes ((int) this.RecordLength);

                        var data = Activator.CreateInstance (System.Type.GetType ("IFF.DataModels." + this.Type));

                        int size = Marshal.SizeOf (data);
                        IntPtr ptr = Marshal.AllocHGlobal (size);

                        Array.Resize (ref recordData, size);

                        Marshal.Copy (recordData, 0, ptr, size);

                        data = Marshal.PtrToStructure (ptr, data.GetType ());
                        Marshal.FreeHGlobal (ptr);

                        this.Entries.Add (data);
                    }
                }
            }
        }

        public bool CheckMagicNumber () {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek (4L, SeekOrigin.Begin);
            ushort MagicNumber = Reader.ReadUInt16 ();
            Reader.BaseStream.Seek (Position, SeekOrigin.Begin);
            return this.MagicNumber.Contains<ushort> (MagicNumber);
        }

        public ushort GetRecordCount () {
            long Position = Reader.BaseStream.Position;
            Reader.BaseStream.Seek (0, System.IO.SeekOrigin.Begin);
            ushort RecordCount = Reader.ReadUInt16 ();
            Reader.BaseStream.Seek (Position, SeekOrigin.Begin);
            return RecordCount;
        }

        public long GetRecordLength () {
            long Position = Reader.BaseStream.Position;
            ushort RecordCount = this.GetRecordCount ();
            long DataLength = Reader.BaseStream.Length - 8L;
            return (long) (DataLength / ((long) RecordCount));
        }

        public void JumpToRecord (int index) {
            Reader.BaseStream.Seek (8L + (this.RecordLength * index), System.IO.SeekOrigin.Begin);
        }

        public string GetTypeFromFileName () {
            string type = Path.GetFileNameWithoutExtension (this.FilePath);

            if (this.DataModels.Contains (type)) {
                return type;
            } else {
                return "Unknown";
            }
        }
    }
}