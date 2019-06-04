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
        /// <summary>
        /// List of all dialogue entries of the QST file
        /// </summary>
        public List<QSTDialogue> Entries { get; } = new List<QSTDialogue>();

        /// <summary>
        /// Constructor for QST file instance
        /// </summary>
        /// <param name="data">Stream containing the QST file data</param>
        public QSTFile (Stream data)
        {
            Parse(data);
        }

        /// <summary>
        /// Parses the contents of the QST file
        /// </summary>
        /// <param name="data">Stream containing the QST file data</param>
        private void Parse (Stream data)
        {
            using (BinaryReader reader = new BinaryReader(data))
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

    /// <summary>
    /// Main QST file dialogue structure
    /// </summary>
    public struct QSTDialogue : IEquatable<QSTDialogue>
    {
        /// <summary>
        /// ID of the occuring event
        /// </summary>
        public byte EventID { get; set; }
        
        /// <summary>
        /// Dialogue index/ID
        /// </summary>
        public byte ID { get; set; }
        
        /// <summary>
        /// ID of the character currently speaking
        /// </summary>
        public byte CharacterID { get; set; }
        
        /// <summary>
        /// Position of the current character
        /// </summary>
        public byte Position { get; set; }
        
        /// <summary>
        /// Portrait of the current character
        /// </summary>
        public string CharacterImage { get; set; }
        
        /// <summary>
        /// Current background image
        /// </summary>
        public string BackgroundImage { get; set; }
        
        /// <summary>
        /// Text of the current dialogue
        /// </summary>
        public string Text { get; set; }

        public bool Equals(QSTDialogue other)
        {
            return EventID == other.EventID && ID == other.ID;
        }
    }
}
