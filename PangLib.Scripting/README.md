# PangLib.Scripting

| [![Nuget](https://img.shields.io/nuget/v/PangLib.Scripting.svg)](https://www.nuget.org/packages/PangLib.Scripting/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.Scripting.svg)](https://www.nuget.org/packages/PangLib.Scripting/) | [Issues](https://github.com/retreev/PangLib/labels/PangLib.Scripting) |
| ------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------- |

Library to handle and parse Pangya scripting languages.

## Supported scripting languages

* Script sections inside `.*pet` files

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.Scripting
```

## Usage

```cs
using PangLib.Scripting.PET;

PETScript PET = new PETScript('*fx("@example" "DustBig.spr" "Bip01 R Toe0")');
// You can now access parsed commands in PET.Commands
```
