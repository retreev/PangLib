# PAK - `*.pak`

The PAK (Package) File format is Pangya: Fantasy Golfs archive/packaging format. The PSP archive consists of two files `psppackfilelist.pak` and `pspdata.pak`

## `psppackfilelist.pak`

As the name suggests, it contains the list of files of the archive. Inside the file, you read following structure until the end of the file:

```
public struct FileEntry
{
    public ushort Type;
    public ushort Unknown1;
    public uint Offset;
    public uint FileSize;
    public uint RealFileSize;
    public string FileName;
}
```

## `pspdata.pak`

Use the acquired `FileEntries` from `psppackfilelist.pak` to read the data. Just start reading `FileSize` from `Offset` and save it to `FileName`. There is no compression or encryption, that's why `FileSize` and `RealFileSize` match for all entries.