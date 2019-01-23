# PangLib.DAT

Library to handle and parse data from Pangya translation (`.dat`) files.

## Installation

You can download this on NuGet using the .NET CLI

```
dotnet add package PangLib.DAT
```

## Usage

You can start an empty DAT file instance to then fill and save to disk

```cs
// create file instance
DATFile DAT = new DATFile();

// set an encoding
DAT.SetEncoding(Encoding.UTF8);

// Add an entry to the DAT file
DAT.Entries.Add("My string");

// Save DAT file to disk
DAT.Save("./personal.dat");
```

Or you can start with an already existing DAT file and load that into an instance

```cs
// Load DAT file into instance
DATFile DAT = DATFile.Load("./korea.dat");

// DATFile is able to guess the encoding from the default file names
// of Pangya DAT files, so you don't need to set it here

// ... manipulate DAT file instance as you like

// Save DAT file to disk
DAT.Save("./personal.dat");
```
