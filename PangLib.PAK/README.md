# PangLib.PAK

Library to handle Pangya archive files (`.pak`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.PAK
```

## Usage

The main usage of this package right now is to load and extract PAK files

```cs
// Load a PAK file into a new PAKFile instance
// The second argument is a dynamic key which either
// is a uint or a uint[] required to decrypt certain parts
// of the PAK file
PAKFile PAK = new PAKFile("./projectg500+_gb.pak", key);

// Extracts the PAK file into the current directory
PAK.ExtractFiles();
```

## Known Issues

- You can't add files to a PAK nor save them back to disk
- You can't create an empty PAK file instance to fill yourself
- You can't specify a path to extract the PAK file to
- You can't access single files of the PAK file instance
