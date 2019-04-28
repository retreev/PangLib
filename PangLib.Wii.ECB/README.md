# PangLib.Wii.ECB

Library to handle Pangya: Super Swing Golf (Wii) dialogue and character table files (`.ecb`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.Wii.ECB
```

## Usage

The main usage of this package right now is to load and parse ECB files

```cs
// Load the PSP PAK file pair into a new instance of PAKFile
ECBFile ECB = new ECBFile("./EVENT_AR.ECB");

// You can now access, export, and work with the dialogue entries from ECB.Dialogue
// or inspect the char tables in ECB.CharTable1 and ECB.CharTable2
```