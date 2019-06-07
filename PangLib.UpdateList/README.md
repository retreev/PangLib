# PangLib.UpdateList

| [![Nuget](https://img.shields.io/nuget/v/PangLib.UpdateList.svg)](https://www.nuget.org/packages/PangLib.UpdateList/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.UpdateList.svg)](https://www.nuget.org/packages/PangLib.UpdateList/) | [Issues](https://github.com/pangyatools/PangLib/labels/PangLib.UpdateList) |
| --------------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------- |

Library to handle Pangya updatelist files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.UpdateList
```

## Usage

```cs
// Load updatelist into instance
UpdateList updateList = new UpdateList("./updatelist");

// Decrypt/Parse updatelist file
updateList.Parse();

// You can now access the parsed updatelist in updateList.Document
```
