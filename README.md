<img align="left" src=".github/Images/pang.png" width="64" />

# PangLib 

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/ee32fb04b92c4910acc16fa93f3d6a89)](https://www.codacy.com/gh/pangyatools/PangLib/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=pangyatools/PangLib&amp;utm_campaign=Badge_Grade) [![Discord](https://discordapp.com/api/guilds/521180240542826496/widget.png?style=shield)](https://discord.gg/HwDTssf)

Series of tools to interact with Pangya (PC) game files

## Usage

The libraries are built using .NET Core and .NET Standard 2.0. So you need to download and setup the [.NET Core SDK](https://www.microsoft.com/net/download) on your system.

All libraries are published on Nuget with their respective full package name, so you can install using the .NET CLI:

```shell
$ dotnet add package [package-name]
```

## Available Libraries

| Library                                       | Version                                                                                                               | Build Status                                                                                                                                                                  | Description                                                 |
|-----------------------------------------------|-----------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------|
| [**PangLib.IFF**](PangLib.IFF/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.IFF.svg)](https://www.nuget.org/packages/PangLib.IFF/)               | [![Build status](https://github.com/retreev/panglib/actions/workflows/iff-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/iff-build.yaml) | Library to handle and parse data from `.iff` files          |
| [**PangLib.DAT**](PangLib.DAT/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.DAT.svg)](https://www.nuget.org/packages/PangLib.DAT/)               | [![Build status](https://github.com/retreev/panglib/actions/workflows/dat-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/dat-build.yaml) | Library to handle and parse data from `.dat` files          |
| [**PangLib.PAK**](PangLib.PAK/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.PAK.svg)](https://www.nuget.org/packages/PangLib.PAK/)               | [![Build status](https://github.com/retreev/panglib/actions/workflows/pak-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/pak-build.yaml) | Library to handle and parse data from `.pak` files          |
| [**PangLib.PET**](PangLib.PET/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.PET.svg)](https://www.nuget.org/packages/PangLib.PET/)               | [![Build status](https://github.com/retreev/panglib/actions/workflows/pet-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/pet-build.yaml)       | Library to handle and parse data from `.*pet` files         |
| [**PangLib.SBIN**](PangLib.SBIN/)             | [![Nuget](https://img.shields.io/nuget/v/PangLib.SBIN.svg)](https://www.nuget.org/packages/PangLib.SBIN/)             | [![Build status](https://github.com/retreev/panglib/actions/workflows/sbin-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/sbin-build.yaml) | Library to handle and parse data from `.sbin` files         |
| [**PangLib.Scripting**](PangLib.Scripting/)   | [![Nuget](https://img.shields.io/nuget/v/PangLib.Scripting.svg)](https://www.nuget.org/packages/PangLib.Scripting/)   | [![Build status](https://github.com/retreev/panglib/actions/workflows/scripting-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/scripting-build.yaml) | Library to handle and parse Pangya scripting languages      |
| [**PangLib.UCC**](PangLib.UCC/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.UCC.svg)](https://www.nuget.org/packages/PangLib.UCC/)               | [![Build status](https://github.com/retreev/panglib/actions/workflows/ucc-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/ucc-build.yaml) | Library to handle and parse data from SelfDesign files      |
| [**PangLib.UpdateList**](PangLib.UpdateList/) | [![Nuget](https://img.shields.io/nuget/v/PangLib.UpdateList.svg)](https://www.nuget.org/packages/PangLib.UpdateList/) | [![Build status](https://github.com/retreev/panglib/actions/workflows/updatelist-build.yaml/badge.svg)](https://github.com/retreev/PangLib/actions/workflows/updatelist-build.yaml) | Library to handle and parse data from `updatelist` files    |
| [**PangLib.WEP**](PangLib.WEP/)               | [![Nuget](https://img.shields.io/nuget/v/PangLib.WEP.svg)](https://www.nuget.org/packages/PangLib.WEP/)               | -                                                                                                                                                                             | Library to handle and parse data from `.(g/sg/ai)bin` files |
| [**PangLib.Utilities**](PangLib.Utilities/)   | [![Nuget](https://img.shields.io/nuget/v/PangLib.Utilities.svg)](https://www.nuget.org/packages/PangLib.Utilities/)   | [![Build status](https://ci.appveyor.com/api/projects/status/1eohtvn6tp6t89ed/branch/master?svg=true)](https://ci.appveyor.com/project/pixeldesu/panglib-aan6t/branch/master) | Common utilities used in other `PangLib` libraries          |

## Building

To build PangLib or any of the libraries inside it, you need, just as for using it, the [.NET Core SDK](https://www.microsoft.com/net/download).

Once the SDK is available on your system to use, you can either run the following commands in the project root to build every library from the solution,
or navigate to a subfolder (e.g. `PangLib.PET/`) and execute them there:

```
$ dotnet restore
$ dotnet build
```

If the commands run successfully, you now have compiled libraries available at `[library-name]/bin/Debug/netstandard2.0/[arch]`

To quickly test changes or use your local copy of a PangLib library in a project, you can run the following command to add 
a reference:

```
$ dotnet add reference [path to .csproj file of desired library]
```

This will now allow you to change the code of the library, and of your program and once you build your program, it will also
build the referenced library again, so you don't have to manually include a built library or publish it to Nuget yourself.

## Contributing

Want to contribute? **Awesome!**

You can contribute in many ways, like:

- Opening an issue if a problem with a library occurs.
- Opening an issue for a feature request, when a library is missing something you need.
- Opening an issue for a library request, if you need handling for another format.

Of course you can already contribute code if you are a developer, adding features, additional libraries and more, I'm
pretty open to anything, as long as it is related to Pangya and the addition is reasonable!

### Discuss on other Websites

Forum posts allowing for engagement and feedback on PangLib:

- [pangya.community](https://pangya.community/t/panglib-a-toolchain-for-pangya-files/22)
- [RageZone](http://forum.ragezone.com/f513/panglib-set-libraries-pangya-game-1162203/)

## Documentation

Documentation on the parsed file formats can be found at [docs.pangya.golf](https://docs.pangya.golf)

## Acknowledgements

PangLib would not be possible with prior research and tooling developed by others, namely:

* [HSReina](https://github.com/HSReina) for several tools and hints, especially around PET models
* [jchv](https://github.com/jchv) for [the Blender import script](https://github.com/retreev/io_scene_mpet)
* [Dave Devils](https://github.com/DaveDevils) for the documentation provided in [PangTools](https://github.com/davedevils/PangTools)
* [Acrisio Filho](https://github.com/Acrisio-Filho) for [the provided GBIN and SBIN readers](https://github.com/Acrisio-Filho/SuperSS-Dev/tree/master/Tools)

## License

This project is licensed under the AGPL-3.0
