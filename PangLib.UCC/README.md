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
using System.IO;
using SkiaSharp;

// Load UCC file into instance
UCCFile UCC = new UCCFile(File.Open("./selfdesign.jpg", FileMode.Open));

// UCC files are zip archives and using this
// method you can turn any file entry inside
// the file into a SKBitmap, which you then can
// use further, or just save to disk
SKBitmap iconImage = UCC.GetBitmapFromFileEntry("icon");
SaveImage(iconImage, "icon.png");

static void SaveImage(SKBitmap bitmap, string filename)
{
    using (var image = SKImage.FromBitmap(bitmap))
    using (var data = image.Encode(SKEncodedImageFormat.Png, 100)) {
        // save the data to a stream
        using (var stream = File.OpenWrite(filename)) {
            data.SaveTo(stream);
        }
    }
}
```
