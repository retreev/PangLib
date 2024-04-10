using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace PangLib.IFF.JP.Extensions
{
    public class ZipFileEx : IDisposable
    {
        private ZipArchive _archive;
        private MemoryStream _stream;

        public ZipFileEx()
        {
            _stream = new MemoryStream();
            _archive = new ZipArchive(_stream, ZipArchiveMode.Create, leaveOpen: true);
        }

        public ZipFileEx(Stream stream)
        {
            _stream = new MemoryStream();
            stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(_stream);
            _archive = new ZipArchive(_stream, ZipArchiveMode.Update, leaveOpen: true);
        }

        public ZipFileEx(string filePath)
        {
            _stream = new MemoryStream();
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                fileStream.CopyTo(_stream);
            }
            _archive = new ZipArchive(_stream, ZipArchiveMode.Update, leaveOpen: true);
        }

        public async Task AddFileAsync(string fileName, Stream stream)
        {
            var entry = _archive.CreateEntry(fileName);
            using (var entryStream = entry.Open())
            {
                await stream.CopyToAsync(entryStream);
            }
        }

        public void AddFile(string fileName, Stream stream)
        {
            var entry = _archive.CreateEntry(fileName);
            using (var entryStream = entry.Open())
            {
                stream.CopyTo(entryStream);
            }
        }

        public void Update(string fileName, Stream stream)
        {
            var entry = _archive.GetEntry(fileName);
            entry.Delete();
            // Criar um arquivo temporário e copiar o conteúdo do stream para ele
            var tempFilePath = Path.GetTempFileName();
            using (var fileStream = File.OpenWrite(tempFilePath))
            {
                stream.CopyTo(fileStream);
            }
           _archive.CreateEntryFromFile(tempFilePath, fileName);
        }


        public async Task AddFileAsync(string fileName, string filePath)
        {
            var entry = _archive.CreateEntry(fileName);
            using (var entryStream = entry.Open())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    await fileStream.CopyToAsync(entryStream);
                }
            }
        }

        public void AddFile(string fileName, string filePath)
        {
            var entry = _archive.CreateEntry(fileName);
            using (var entryStream = entry.Open())
            {
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    fileStream.CopyTo(entryStream);
                }
            }
        }

        public void Extract(string directory)
        {
            _archive.ExtractToDirectory(directory);
        }

        public void Save(Stream stream)
        {
            DisposeArchive();
            _stream.Seek(0, SeekOrigin.Begin);
            _stream.CopyTo(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }

        public void Save(string filePath)
        {
            DisposeArchive();
            _stream.Seek(0, SeekOrigin.Begin);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                _stream.CopyTo(fileStream);
            }
        }

        public async Task SaveAsync(Stream stream)
        {
            DisposeArchive();
            _stream.Seek(0, SeekOrigin.Begin);
            await _stream.CopyToAsync(stream);
            stream.Seek(0, SeekOrigin.Begin);
        }

        public async Task SaveAsync(string filePath)
        {
            DisposeArchive();
            _stream.Seek(0, SeekOrigin.Begin);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await _stream.CopyToAsync(fileStream);
            }
        }

        private void DisposeArchive()
        {
            _archive.Dispose();
            _archive = null;
        }

        public void Dispose()
        {
            if (_archive != null)
            {
                _archive.Dispose();
                _archive = null;
            }

            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }
        }
    }
}