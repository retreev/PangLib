# PangLib.PSP.PAK

| [![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.PAK.svg)](https://www.nuget.org/packages/PangLib.PSP.PAK/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.PSP.PAK.svg)](https://www.nuget.org/packages/PangLib.PSP.PAK/) | [Issues](https://github.com/pangyatools/PangLib/labels/PangLib.PSP.PAK) |
| --------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- |

Library to handle Pangya: Fantasy Golf (PSP) archive files (`.pak`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.PSP.PAK
```

## Usage

The main usage of this package right now is to load and extract PAK files

```cs
// Load the PSP PAK file pair into a new instance of PAKFile
PAKFile PAK = new PAKFile("./psppackfilelist.pak", "./pspdata.pak");

// Extracts the PAK file into the ".\data\" subdirectory
PAK.ExtractFiles(".\\data\\");
```