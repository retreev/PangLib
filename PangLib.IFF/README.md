# PangLib.IFF

Library to handle and parse data from Pangya metadata and item (`.iff`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.IFF
```

## Usage

```cs
using PangLib.IFF;
using PangLib.IFF.DataModels;

// Create new instance and load file into it
IFFFile<Caddie> IFF = new IFFFile<Caddie>("./Caddie.iff");

// You can now access the IFF file entries on IFF.Entries
Caddie Papel = IFF.Entries.Get(1);
```

## Known Issues

- You can't save IFF files back to disk
- No way to create an empty instance of `IFFFile`
