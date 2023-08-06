# PangLib.SBIN

| [![Nuget](https://img.shields.io/nuget/v/PangLib.SBIN.svg)](https://www.nuget.org/packages/PangLib.SBIN/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.SBIN.svg)](https://www.nuget.org/packages/PangLib.SBIN/) | [Issues](https://github.com/retreev/PangLib/labels/PangLib.SBIN) |
|-----------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------|

Library to handle and parse Pangya shadow maps (`.sbin`).

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.SBIN
```

## Usage

Currently, there isn't much use for the library, but it will be able to parse different sections of the file and save them into instance attributes for you to eventually work with.

```cs
// Load SBIN file into instance
SBINFile SBIN = new SBINFile(File.Open("./sand_01.sbin", FileMode.Open));

// You can now access the different structure types in their corresponding member variables
```
