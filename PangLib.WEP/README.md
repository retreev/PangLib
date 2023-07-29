# PangLib.WEP

| [![Nuget](https://img.shields.io/nuget/v/PangLib.WEP.svg)](https://www.nuget.org/packages/PangLib.WEP/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.WEP.svg)](https://www.nuget.org/packages/PangLib.WEP/) | [Issues](https://github.com/retreev/PangLib/labels/PangLib.WEP) |
|---------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------|

Library to handle and parse Pangya WangED project (`.gbin`/`.sgbin`/`.aibin`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.WEP
```

## Usage

Currently, there isn't much use for the library, but it will be able to parse different sections of the file and save them into instance attributes for you to eventually work with.

```cs
// Load WEP file into instance
WEPFile WEP = new WEPFile(File.Open("./sand_01.gbin", FileMode.Open));

// You can now access the different structure types in their corresponding member variables
```

## Known Issues

- While the files are parsed down correctly to the last byte, the structures aren't fully correct yet.
