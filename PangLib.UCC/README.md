# PangLib.UCC

| [![Nuget](https://img.shields.io/nuget/v/PangLib.UCC.svg)](https://www.nuget.org/packages/PangLib.UCC/) | [![Nuget](https://img.shields.io/nuget/dt/PangLib.UCC.svg)](https://www.nuget.org/packages/PangLib.UCC/) | [Issues](https://github.com/pangyatools/PangLib/labels/PangLib.UCC) |
| ------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------- |

Library to handle Pangya self-design files.

## Installation

You can download this package on NuGet using the .NET CLI

```
dotnet add package PangLib.UCC
```

## Usage

```cs
// Load UCC file into instance
UCCFile UCC = new UCCFile("./selfdesign.jpg");

// UCC files are zip archives and using this
// method you can turn any file entry inside
// the file into a Bitmap, which you then can
// use further, or just save to disk
Bitmap frontImage = UCC.GetBitmapFromFileEntry("front");
frontImage.Save("./front.png", ImageFormat.Png);
```

## Known Issues

- You can't save custom images to UCC files
- You can't save UCC files back to disk
- You can't create an empty UCC file instance to fill with own images
