# PangLib.IFF

Library to handle and parse data from Pangya metadata and item (`.iff`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.IFF
```

## Usage

```cs
// Create new instance and load file into it
IFFFile IFF = new IFFFile("./Caddie.iff");

// Parse contents of IFF file
IFF.Parse();

// You can now access the IFF file entries on IFF.Entries
// Beware that you have to cast them to the proper
// DataModels structure as IFFFile only saves object types
// in it's dictionary
Caddie Papel = (Caddie) IFF.Entries.Get(1);
```

## Known Issues

- You can't save IFF files back to disk
- No way to create an empty instance of `IFFFile`
