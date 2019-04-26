using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangLib.PSP.QST
{
    /// <summary>
    /// Main PSP QST file class
    /// </summary>
    public class QSTFile
    {
        public List<QSTDialogue> Entries = new List<QSTDialogue>();

        private string FilePath;

        /// <summary>
        /// Constructor for QST file instance
        /// </summary>
        /// <param name="filePath">file path of the QST file</param>
        public QSTFile (string filePath)
        {
            FilePath = filePath;

            Parse();
        }

        /// <summary>
        /// Parses the contents of the QST file
        /// </summary>
        private void Parse ()
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                int dialogueCount = (int) reader.ReadByte();

                for (int i = 0; i < dialogueCount; i++)
                {
                    QSTDialogue dialogue = new QSTDialogue();

                    reader.BaseStream.Seek(3L, SeekOrigin.Current);

                    dialogue.EventID = reader.ReadByte();
                    dialogue.ID = reader.ReadByte();
                    dialogue.CharacterID = reader.ReadByte();
                    dialogue.Position = reader.ReadByte();
                    dialogue.CharacterImage = Encoding.UTF8.GetString(reader.ReadBytes(32));
                    dialogue.BackgroundImage = Encoding.UTF8.GetString(reader.ReadBytes(32));
                    dialogue.Text = Encoding.UTF8.GetString(reader.ReadBytes(192));

                    reader.BaseStream.Seek(8L, SeekOrigin.Current);

                    Entries.Add(dialogue);
                }
            }
        }
    }

    public struct QSTDialogue 
    {
        public byte EventID;
        public byte ID;
        public byte CharacterID;
        public byte Position;
        public string CharacterImage;
        public string BackgroundImage;
        public string Text;
    }
}
