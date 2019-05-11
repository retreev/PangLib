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

| Library                | Version                                                         | Description                                              |
| ---------------------- | --------------------------------------------------------------- | -------------------------------------------------------- |
| **PangLib.IFF**        | ![Nuget](https://img.shields.io/nuget/v/PangLib.IFF.svg)        | Library to handle and parse data from `.iff` files       |
| **PangLib.DAT**        | ![Nuget](https://img.shields.io/nuget/v/PangLib.DAT.svg)        | Library to handle and parse data from `.dat` files       |
| **PangLib.PAK**        | ![Nuget](https://img.shields.io/nuget/v/PangLib.PAK.svg)        | Library to handle and parse data from `.pak` files       |
| **PangLib.PET**        | ![Nuget](https://img.shields.io/nuget/v/PangLib.PET.svg)        | Library to handle and parse data from `.*pet` files      |
| **PangLib.PSP.NOP**    | ![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.NOP.svg)    | Library to handle and parse data from PSP `.nop` files   |
| **PangLib.PSP.PAK**    | ![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.PAK.svg)    | Library to handle and parse data from PSP `.pak` files   |
| **PangLib.PSP.QST**    | ![Nuget](https://img.shields.io/nuget/v/PangLib.PSP.QST.svg)    | Library to handle and parse data from PSP `.qst` files   |
| **PangLib.UCC**        | ![Nuget](https://img.shields.io/nuget/v/PangLib.UCC.svg)        | Library to handle and parse data from SelfDesign files   |
| **PangLib.UpdateList** | ![Nuget](https://img.shields.io/nuget/v/PangLib.UpdateList.svg) | Library to handle and parse data from `updatelist` files |
| **PangLib.Wii.ECB**    | ![Nuget](https://img.shields.io/nuget/v/PangLib.Wii.ECB.svg)    | Library to handle and parse data from Wii `.ECB` files   |
| **PangLib.Utilities**  | ![Nuget](https://img.shields.io/nuget/v/PangLib.Utilities.svg)  | Common utilities used in other `PangLib` libraries       |

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
