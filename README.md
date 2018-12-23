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
$ dotnet add reference "[path to PangLib repository]/PangLib.IFF/PangLib.IFF.csproj"
```

You should get a message about the reference being added successfully, now you can use the library inside your application!

More information on how you can use each library can be found in their folders and source code comments across all classes and files.

## Available Libraries

| Library                | Description                                                                        |
| ---------------------- | ---------------------------------------------------------------------------------- |
| **PangLib.IFF**        | Library to handle and parse data from `.iff` files                                 |
| **PangLib.DAT**        | Library to handle and parse data from `.dat` files                                 |
| **PangLib.PAK**        | Library to handle and parse data from `.pak` files                                 |
| **PangLib.PET**        | Library to handle and parse data from `.*pet` files                                |
| **PangLib.UpdateList** | Library to handle and parse data from `updatelist` files                           |
| **PangLib.Utilities**  | Utilities used in other `PangLib` libraries, handling cryptography and compression |

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
