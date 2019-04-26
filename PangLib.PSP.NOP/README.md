# PangLib.PSP.NOP

Library to handle Pangya: Fantasy Golf (PSP) archive files (`.nop`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.PSP.NOP
```

## Usage

The main usage of this package right now is to load and extract PAK files

```cs
// Load the PSP NOP file into a new instance of NOPFile
NOPFile NOP = new NOPFile("./west_01_n.nop");

// Extracts the NOP file
// NOTE: NOP file paths are absolute, so the game will attempt to extract to
// c:\projectg_psp\projectg\data_umd\..
NOP.ExtractFiles();
```