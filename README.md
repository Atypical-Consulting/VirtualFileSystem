# Virtual File System

A virtual file system implementation in modern C#.

[![Atypical-Consulting - VirtualFileSystem](https://img.shields.io/static/v1?label=Atypical-Consulting&message=VirtualFileSystem&color=blue&logo=github)](https://github.com/Atypical-Consulting/VirtualFileSystem "Go to GitHub repo")
[![License: BSD-3-Clause](https://img.shields.io/badge/License-BSD--3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![stars - VirtualFileSystem](https://img.shields.io/github/stars/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)
[![forks - VirtualFileSystem](https://img.shields.io/github/forks/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)

[![GitHub tag](https://img.shields.io/github/tag/Atypical-Consulting/VirtualFileSystem?include_prereleases=&sort=semver&color=blue)](https://github.com/Atypical-Consulting/VirtualFileSystem/releases/)
[![issues - VirtualFileSystem](https://img.shields.io/github/issues/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/pulls)
[![GitHub contributors](https://img.shields.io/github/contributors/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/graphs/contributors)
[![GitHub last commit](https://img.shields.io/github/last-commit/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/commits/master)

[![NuGet](https://img.shields.io/nuget/v/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)
[![NuGet](https://img.shields.io/nuget/dt/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)

## Table of contents

<!-- TOC -->
* [Virtual File System](#virtual-file-system)
  * [Table of contents](#table-of-contents)
  * [Introduction](#introduction)
    * [What is a virtual file system and why should I use it?](#what-is-a-virtual-file-system-and-why-should-i-use-it)
  * [Features](#features)
    * [We use the lastest C# features](#we-use-the-lastest-c-features)
  * [Installation](#installation)
    * [NuGet](#nuget)
    * [Source](#source)
  * [Usage](#usage)
    * [Creating a virtual file system, add some files and print the content of the root directory as an ASCII tree](#creating-a-virtual-file-system-add-some-files-and-print-the-content-of-the-root-directory-as-an-ascii-tree)
  * [Documentation](#documentation)
  * [Contributing](#contributing)
  * [License](#license)
  * [Contact](#contact)
  * [Acknowledgements](#acknowledgements)
  * [Changelog](#changelog)
  * [Contributors](#contributors)
<!-- TOC -->

## Introduction

When writing applications in .NET, you often need to write or read the contents of a file. .NET provides `System.IO`
namespace dedicated to this purpose. But how do we deal with the filesystem when testing our code?

**Virtual File System** is an attempt to solve this problem. Currently, this library is at an early stage of
development. If you need additional functionality, I invite you to open an issue to discuss it.

### What is a virtual file system and why should I use it?

A virtual file system is a data structure that represents a file system in memory. It is used to simulate a file system
on a computer. It is useful for testing purposes, for example, when you want to test a file system without actually
creating files on the hard drive.

## Features

- [x] Create a virtual file system
- [x] Create a virtual file or directory
- [ ] ...

### We use the lastest C# features

This library targets .NET 7.0 and uses the latest C# features. It is written in C# 11.0 and uses the new `init`
properties, `record` types, `switch` expressions, `using` declarations, and more.

I invite you to read the [C# 11.0 documentation](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-11) to
learn more about these features.

## Installation

### NuGet

VirtualFileSystem is available on [NuGet](https://www.nuget.org/packages/VirtualFileSystem/).

You can install it using the .NET Core CLI:

```bash
dotnet add package Atypical.VirtualFileSystem
```

or by adding a package reference to your project file:

```xml
<PackageReference Include="Atypical.VirtualFileSystem" Version="0.1.1" />
```

### Source

You can also clone the repository and build the project yourself.

```bash
git clone
cd VirtualFileSystem
dotnet build
```

## Usage

### Creating a virtual file system, add some files and print the content of the root directory as an ASCII tree

```csharp
// sample output (the order of the files is alphabetical)
string expected = """
    vfs://
    ├── superheroes
    │   ├── batman.txt
    │   ├── superman.txt
    │   └── wonderwoman.txt
    ├── villains
    │   ├── joker.txt
    │   ├── lexluthor.txt
    │   └── penguin.txt
    └── world
        ├── gotham.txt
        ├── metropolis.txt
        └── themyscira.txt
    """;

// create a virtual file system
IVirtualFileSystem vfs = new VFS()
    // add some files (directories are created automatically)
    .CreateFile("superheroes/batman.txt")
    .CreateFile("superheroes/superman.txt")
    .CreateFile("superheroes/wonderwoman.txt")
    .CreateFile("villains/joker.txt")
    .CreateFile("villains/lexluthor.txt")
    .CreateFile("villains/penguin.txt")
    .CreateFile("world/gotham.txt")
    .CreateFile("world/metropolis.txt")
    .CreateFile("world/themyscira.txt");

// get the string representation of the virtual file system
string tree = vfs.ToString();
```

## Documentation

The documentation is still a work in progress.

One goal of **Virtual File System** is to provide a complete documentation of the library on **GitHub Pages**. For now,
you can read the XML documentation generated on build.

All summaries are written in English. If you want to help us translate the documentation, please open an issue to
discuss it.

## Contributing

Contributions are welcome! Please read the [contribution guidelines](CONTRIBUTING.md) first.

## License

This project is licensed under the terms of the BSD-3-Clause license.
If you use this library in your project, please consider adding a link to this repository in your project's README.

This project is maintained by [Atypical Consulting](https://www.atypical.consulting/). If you need help with this
project, please contact us from this repository by opening an issue.

## Contact

You can contact us by opening an issue on this repository.

## Acknowledgements

* [All Contributors](../../contributors)
* [Atypical Consulting](https://www.atypical.consulting/)

## Changelog

Please see [CHANGELOG](CHANGELOG.md) for more information what has changed recently.

## Contributors

[![Contributors](https://contrib.rocks/image?repo=Atypical-Consulting/VirtualFileSystem)](http://contrib.rocks)
