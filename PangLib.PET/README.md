# PangLib.PET

Library to handle and parse Pangya model (`.*pet`) files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.PET
```

## Usage

Currently, there isn't much use for the library, but it will be able to parse different sections of the file and save them into instance attributes for you to eventually work with.

```cs
// Load PET file into instance
PETFile PET = new PETFile("./item1_01.pet");

// You can now access the different structure types in their corresponding member variables
```

## Known Issues

- Not all PET structures are parsed yet
