# PAK - `*.pak`

The PAK (Package) file format is Pangya's game archive/packaging format. These files contain multiple
other files and are distributed with patches.

## File Structure

### File Header

At the end of the file we have our header data, following this structure:

```csharp
struct PAKHeader
{
    uint FileListOffset;
    uint FileCount;
    byte Signature;
}
```

`FileListOffset` tells us the offset of the file entry list from the beginning of the file. `FileCount` tells us
how many files there are in this archive and `Signature` determines if this is a Pangya archive. If the signature
is anything else than `0x12`, it's not valid.

### File Entries

File entries tell us more about a single file being present in the archive, you start reading them in `FileCount` times
starting from the `FileListOffset` from the file header. The entries follow this structure:

```csharp
struct PAKFileEntry
{
    byte FileNameLength;
    byte Compression;
    uint Offset;
    uint FileSize;
    uint RealFileSize;
    string FileName;
    byte Unknown1;
}
```

You start reading in the values as denoted in the structure up until the file name. Different as from other Pangya file formats,
the string length isn't automatically 40 bytes, we now have a `FileNameLength` field telling us the length.

So after reading in `FileNameLength` bytes for `FileName` we need to do another check. We need to check the `Compression` value.

If compression is a value between 0 and 4, this is a pre-Season 4 archive and we need to use XOR, and if the compression value is
way off, we need to use XTEA for the metadata.

#### XOR

The old legacy archives only have a single value enciphered with the XOR, and that's the file name. Simply XOR the filename's bytes
with the XOR key and you get the proper filename.

After reading in the filename, there is also another byte-value you need to read in, as denoted by the `PAKFileEntry` structure, we
just call it `Unknown1`, this value is not present in XTEA-archives.

#### XTEA

With XTEA, you need to decrypt a few more values before you can read in the files data from the archive. Simply use the region-specific
XTEA-key for those values:

- `FileName`
- `Offset`
- `RealFileSize`

#### Compression

Before we handle the step-by-step reading of a file, let's handle the `Compression` field from `PAKFileEntry` once more, the values we
get from it are important for handling the files in the extraction process!

| Compression Value | Description                                                  |
| ----------------- | ------------------------------------------------------------ |
| `0`               | No compression                                               |
| `1`               | LZ77                                                         |
| `2`               | No compression, this file entry denotes a directory          |
| `3`               | Custom LZ77 (uses a mask offset and custom LZ77 mask values) |

### Archive Body

Starting from the beginning of the file up to the file list we have the archive body, containing all file data.

To read the file entries properly, just use the data provided by the `PAKFileEntry`s acquired just earlier.

First check the `Compression` value of the file entry, if the value is `2`, simply take the `FileName` and create
a directory based on the `FileName`, if the value is anything different, continue.

With any other value for `Compression`, simply read in `FileSize` bytes starting from `Offset`. If compression is
applied, decompress the data with the given algorithm and check if the decompressed size matches `RealFileSize`. If
your filesize doesn't match, there has been an issue with decompression and the file is most likely going to be corrupt.

Save the resulting data into the location given with `FileName`, and voilà, the archive is unpacked!
