<img align="left" src=".github/Images/pang.png" width="64" />

# PangLib [![CodeFactor](https://www.codefactor.io/repository/github/pangyatools/panglib/badge)](https://www.codefactor.io/repository/github/pangyatools/panglib)

Series of tools to interact with Pangya game files

## About

This set of libraries allows developers to build tools interacting with files of the MMO Golf game Pangya by Ntreev Software.

## Usage

The libraries are built using .NET Core and .NET Standard 2.0. So you need to download and setup the [.NET Core SDK](https://www.microsoft.com/net/download) on your system.

Once that is done you can simply clone this repository somewhere, create your project using the .NET CLI and then point a reference to one of the libraries.

Example, wanting to use the `PangLib.IFF` library:

```
$ mkdir MyCoolProject && cd MyCoolProject
$ dotnet new console
$ dotnet add package [panglib-package-name]
```

You should get a message about the reference being added successfully, now you can use the library inside your application!

More information on how you can use each library can be found in their folders and source code comments across all classes and files.

## Available Libraries

| Library                                       | Version                                                                                                               | Description                                              |
| --------------------------------------------- | --------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------- |
| [**PangLib.IFF**](PangLib.IFF/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.IFF.svg)](https://www.nuget.org/packages/PangLib.IFF/)               | Library to handle and parse data from `.iff` files       |
| [**PangLib.DAT**](PangLib.DAT/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.DAT.svg)](https://www.nuget.org/packages/PangLib.DAT/)               | Library to handle and parse data from `.dat` files       |
| [**PangLib.PAK**](PangLib.PAK/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.PAK.svg)](https://www.nuget.org/packages/PangLib.PAK/)               | Library to handle and parse data from `.pak` files       |
| [**PangLib.PET**](PangLib.PET/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.PET.svg)](https://www.nuget.org/packages/PangLib.PET/)               | Library to handle and parse data from `.*pet` files      |
| [**PangLib.PSP.NOP**](PangLib.PSP.NOP/)       | [![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.NOP.svg)](https://www.nuget.org/packages/PangLib.PSP.NOP/)       | Library to handle and parse data from PSP `.nop` files   |
| [**PangLib.PSP.PAK**](PangLib.PSP.PAK/)       | [![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.PAK.svg)](https://www.nuget.org/packages/PangLib.PSP.PAK/)       | Library to handle and parse data from PSP `.pak` files   |
| [**PangLib.PSP.QST**](PangLib.PSP.QST/)       | [![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.QST.svg)](https://www.nuget.org/packages/PangLib.PSP.QST/)       | Library to handle and parse data from PSP `.qst` files   |
| [**PangLib.UCC**](PangLib.UCC/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.UCC.svg)](https://www.nuget.org/packages/PangLib.UCC/)               | Library to handle and parse data from SelfDesign files   |
| [**PangLib.UpdateList**](PangLib.UpdateList/) | [![Nuget](https://img.shields.io/nuget/v/PangLib.UpdateList.svg)](https://www.nuget.org/packages/PangLib.UpdateList/) | Library to handle and parse data from `updatelist` files |
| [**PangLib.Wii.ECB**](PangLib.Wii.ECB/)       | [![Nuget](https://img.shields.io/nuget/v/PangLib.Wii.ECB.svg)](https://www.nuget.org/packages/PangLib.Wii.ECB/)       | Library to handle and parse data from Wii `.ECB` files   |
| [**PangLib.Utilities**](PangLib.Utilities/)   | [![Nuget](https://img.shields.io/nuget/v/PangLib.Utilities.svg)](https://www.nuget.org/packages/PangLib.Utilities/)   | Common utilities used in other `PangLib` libraries       |

## Documentation

Documentation on the parsed file formats can be found at [docs.pangya.golf](https://docs.pangya.golf)

## Contributing

Want to contribute? **Awesome!**

You can contribute in many ways, like:

- Opening an issue if a problem with a library occurs.
- Opening an issue for a feature request, when a library is missing something you need.
- Opening an issue for a library request, if you need handling for another format.

Of course you can already contribute code if you are a developer, adding features, additional libraries and more, I'm
pretty open to anything, as long as it is related to Pangya and the addition is reasonable!

## License

This project is licensed under the AGPL-3.0
