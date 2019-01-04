using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace PangLib.UCC
{
    public class UCCFile
    {
        private ZipArchive ZIPFile;

        public UCCFile(string filePath)
        {
            ZIPFile = ZipFile.Open(filePath, ZipArchiveMode.Read);
        }

        public Bitmap GetBitmapFromFileEntry(string entryName)
        {
            int width;
            int height;
            int posX = 0;
            int posY = 0;

            ZipArchiveEntry entry = ZIPFile.GetEntry(entryName);

            MemoryStream memoryStream = new MemoryStream();
            entry.Open().CopyTo(memoryStream);
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

            Bitmap bitmap = new Bitmap(width, height);

            using (BinaryReader reader = new BinaryReader(memoryStream))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int loopCount = 3;

                    if (entryName == "icon")
                    {
                        loopCount = 4;
                    }

                    int[] hexColor = new int[4];

                    for (int i = 0; i < loopCount; i++)
                    {
                        hexColor[i] = reader.ReadByte();

                        if (hexColor[i] < 0)
                        {
                            hexColor[i] = 0;
                        }
                        else if (hexColor[i] > 255)
                        {
                            hexColor[i] = 255;
                        }
                    }

                    Color color = Color.FromArgb(entryName == "icon" ? hexColor[3] : 255, hexColor[2], hexColor[1], hexColor[0]);

                    bitmap.SetPixel(posX, posY, color);

                    posX++;

                    if (posX != width) continue;
                    
                    posY++;
                    posX = 0;
                }
            }

            return bitmap;
        }
    }
}


