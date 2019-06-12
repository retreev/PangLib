using System.IO;
using System.IO.Compression;
using SkiaSharp;

namespace PangLib.UCC
{
    /// <summary>
    /// Main UCC file class
    /// </summary>
    public class UCCFile
    {
        /// <summary>
        /// ZIPArchive instance for the UCC file containing the self-design parts
        /// </summary>
        private ZipArchive ZIPFile;

        /// <summary>
        /// Constructor for UCC file instance
        /// </summary>
        /// <param name="data">Stream containing the UCC file data</param>
        public UCCFile(Stream data)
        {
            ZIPFile = new ZipArchive(data);
        }
        
        /// <summary>
        /// Get the specified entry of the UCC file and return it as a bitmap
        /// </summary>
        /// <param name="entryName">Name of the entry</param>
        /// <returns>Bitmap instance of the specified entry</returns>
        public SKBitmap GetBitmapFromFileEntry(string entryName)
        {
            int width;
            int height;
            int posX = 0;
            int posY = 0;

            ZipArchiveEntry entry = ZIPFile.GetEntry(entryName);

            MemoryStream memoryStream = new MemoryStream();
            entry?.Open().CopyTo(memoryStream);
            memoryStream.Position = 0;

            if (memoryStream.Length > 65536)
            {
                width = 256;
                height = 256;
            }
            else if (memoryStream.Length > 32768)
            {
                width = 128;
                height = 64;
            }
            else if (entryName == "icon")
            {
                width = 64;
                height = 84;
            }
            else
            {
                width = 128;
                height = 128;
            }

            SKBitmap bitmap = new SKBitmap(width, height);

            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int loopCount = 3;

                    if (entryName == "icon")
                    {
                        loopCount = 4;
                    }

                    byte[] hexColor = new byte[4];

                    for (byte i = 0; i < loopCount; i++)
                    {
                        hexColor[i] = reader.ReadByte();
                    }

                    SKColor color = new SKColor(hexColor[2], hexColor[1], hexColor[0], entryName == "icon" ? hexColor[3] : (byte) 255);

                    bitmap.SetPixel(posX, posY, color);

                    posX++;

                    if (posX != width)
                    {
                        continue;
                    }
                    
                    posY++;
                    posX = 0;
                }
            }

            return bitmap;
        }
    }
}
