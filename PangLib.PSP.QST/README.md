# PangLib.PSP.QST

Library to handle Pangya: Fantasy Golf (PSP) dialogue files (`.qst`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.PSP.QST
```

## Usage

The main usage of this package right now is to load and parse QST files

```cs
// Load the PSP PAK file pair into a new instance of PAKFile
QSTFile QST = new QSTFile("./event_1.qst");

// You can now access, export, and work with the dialogue entries from QST.Entries
```