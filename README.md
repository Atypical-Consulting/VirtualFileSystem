# Virtual File System  [![Sparkline](https://stars.medv.io/Atypical-Consulting/VirtualFileSystem.svg)](https://stars.medv.io/Atypical-Consulting/VirtualFileSystem)
A virtual file system implementation in modern C# with comprehensive demo applications.

---

[![Atypical-Consulting - VirtualFileSystem](https://img.shields.io/static/v1?label=Atypical-Consulting&message=VirtualFileSystem&color=blue&logo=github)](https://github.com/Atypical-Consulting/VirtualFileSystem "Go to GitHub repo")
[![License: BSD-3-Clause](https://img.shields.io/badge/License-BSD--3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![stars - VirtualFileSystem](https://img.shields.io/github/stars/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)
[![forks - VirtualFileSystem](https://img.shields.io/github/forks/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)

[![GitHub tag](https://img.shields.io/github/tag/Atypical-Consulting/VirtualFileSystem?include_prereleases=&sort=semver&color=blue)](https://github.com/Atypical-Consulting/VirtualFileSystem/releases/)
[![issues - VirtualFileSystem](https://img.shields.io/github/issues/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/pulls)
[![GitHub contributors](https://img.shields.io/github/contributors/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/graphs/contributors)
[![GitHub last commit](https://img.shields.io/github/last-commit/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/commits/master)
[![codecov](https://codecov.io/gh/Atypical-Consulting/VirtualFileSystem/branch/main/graph/badge.svg?token=041C4QKW6O)](https://codecov.io/gh/Atypical-Consulting/VirtualFileSystem)

[![NuGet](https://img.shields.io/nuget/v/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)
[![NuGet](https://img.shields.io/nuget/dt/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)

---

## 📝 Table of Contents

<!-- TOC -->
  * [📝 Table of Contents](#-table-of-contents)
  * [📖 Introduction](#-introduction)
    * [🧐 What is a virtual file system and why should I use it?](#-what-is-a-virtual-file-system-and-why-should-i-use-it)
  * [📌 Features](#-features)
  * [🎮 Demo Applications](#-demo-applications)
    * [🌐 Blazor Server Demo](#-blazor-server-demo)
    * [🖥️ Console Demo](#️-console-demo)
  * [📄 Documentation](#-documentation)
  * [📥 Installation](#-installation)
    * [📋 Prerequisites](#-prerequisites)
    * [🚀 We use the latest C# features](#-we-use-the-latest-c-features)
    * [📦 NuGet](#-nuget)
    * [📁 From source](#-from-source)
  * [📚 Use cases](#-use-cases)
    * [Creating a virtual file system, add some files and print the content as an ASCII tree](#creating-a-virtual-file-system-add-some-files-and-print-the-content-as-an-ascii-tree)
  * [🤝 Contributing](#-contributing)
  * [📜 License](#-license)
  * [📬 Contact](#-contact)
  * [🙌 Acknowledgements](#-acknowledgements)
  * [🎉 Change log](#-change-log)
  * [✨ Contributors](#-contributors)
<!-- TOC -->

## 📖 Introduction

When writing applications in .NET, you often need to write or read the contents of a file. .NET provides `System.IO`
namespace dedicated to this purpose. But how do we deal with the filesystem when testing our code?

**Virtual File System** is an attempt to solve this problem. This library provides a comprehensive virtual file system implementation with full CRUD operations, event-driven architecture, and undo/redo functionality.

> 🎮 **New!** Check out our [interactive Blazor demo application](#-blazor-server-demo) that showcases all VFS features in a professional web interface!

### 🧐 What is a virtual file system and why should I use it?

A virtual file system is a data structure that represents a file system in memory. It is used to simulate a file system
on a computer. It is useful for testing purposes, for example, when you want to test a file system without actually
creating files on the hard drive.

## 📌 Features

- [x] Create a virtual file system
- [x] Create a virtual file or directory
- [x] Print the contents of a virtual file system as a tree
- [x] Delete a virtual file or directory
- [x] Move a virtual file or directory
- [x] Rename a virtual file or directory
- [x] Read and write content to a virtual file
- [x] Check if a virtual file or directory exists (`TryGetFile`, `TryGetDirectory`)
- [x] Get the size of a virtual file or directory (via `Content.Length` and enumeration)
- [x] Get the creation, access, and modification times of a virtual file or directory
- [x] Support for events (file created, file deleted, etc.)
- [x] Support for undo/redo operations with change history
- [x] Advanced search capabilities (by name, content, regex patterns)
- [x] File system analytics and insights
- [ ] Copy a virtual file or directory (planned)
- [ ] Support for custom metadata on files and directories (planned)
- [ ] Support for file and directory permissions (planned)
- [ ] Support for symbolic links (planned)
- ...

## 🎮 Demo Applications

The Virtual File System library includes comprehensive demo applications that showcase its capabilities in real-world scenarios.

### 🌐 Blazor Server Demo

A professional, full-featured web application built with **Blazor Server** and **MudBlazor** that provides an interactive demonstration of all VFS features.

#### 🚀 Getting Started with the Demo

```bash
# Navigate to the demo application
cd src/Atypical.VirtualFileSystem.DemoBlazorApp

# Run the demo application
dotnet run

# Open your browser to https://localhost:5040
```

#### ✨ Demo Features

The Blazor demo application includes:

- **📊 Dashboard** - Welcome page with file system overview and quick actions
- **📁 File Operations** - Create, modify, delete files and directories with real-time feedback
- **🔍 Advanced Search** - Multi-criteria search (name, content, regex patterns, file extensions)
- **✏️ File Editor** - Full-featured text editor with find/replace, save/reload functionality
- **📈 Analytics** - Comprehensive file system analysis with metrics and insights
- **🕐 History Management** - Visual undo/redo operations with operation tracking
- **📋 Event Monitoring** - Real-time event stream with categorized statistics
- **💡 Responsive Design** - Mobile-friendly interface with professional UI/UX
- **🎨 Modern UI** - Built with MudBlazor components and Material Design principles

#### 🏗️ Architecture Highlights

- **Event-driven architecture** with real-time updates
- **State management** across components with proper synchronization
- **Professional UX** with loading states, error handling, and user feedback
- **Accessibility support** with ARIA labels and keyboard navigation
- **Responsive design** that works seamlessly on desktop and mobile devices

### 🖥️ Console Demo

A command-line interface demonstration showcasing basic VFS operations:

```bash
# Navigate to the CLI demo
cd src/Atypical.VirtualFileSystem.DemoCli

# Run the CLI demo
dotnet run
```

The CLI demo demonstrates file system operations, tree visualization, and event handling in a console environment.

## 📄 Documentation

**Virtual File System** provides a [COMPLETE DOCUMENTATION](https://github.com/Atypical-Consulting/VirtualFileSystem/blob/main/docs/README.md) of the library.

All summaries are written in English. If you want to help us translate the documentation, please open an issue to
discuss it.

> **Note:** The documentation is generated using [Doraku/DefaultDocumentation]() tool. It is generated automatically when the project is built.

## 📥 Installation

### 📋 Prerequisites

- .NET 6.0 or higher (supported versions: 6.x to 9.x)
- For the Blazor demo: .NET 9.0 or higher
- A C# IDE (Visual Studio, Rider, etc.)
- A C# compiler (dotnet CLI, etc.)

### 🚀 We use the latest C# features

This library targets .NET 8.0 and uses the latest C# features. It is written in C# 12.0 and uses the new `init`
properties, `record` types, `switch` expressions, `using` declarations and more.

The Blazor demo application showcases modern .NET 9 features and demonstrates real-world usage patterns.

I invite you to read the [C# 12.0 documentation](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12) to
learn more about these features.

### 📦 NuGet

VirtualFileSystem is available on [NuGet](https://www.nuget.org/packages/Atypical.VirtualFileSystem).

You can install it using the .NET CLI:

```bash
dotnet add package Atypical.VirtualFileSystem
```

or by adding a package reference to your project file:

```xml
<PackageReference Include="Atypical.VirtualFileSystem" Version="0.3.0" />
```

### 📁 From source

You can also clone the repository and build the project yourself.

```bash
git clone
cd VirtualFileSystem
dotnet build
```

## 📚 Use cases

### Creating a virtual file system, add some files and print the content as an ASCII tree

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
string tree = vfs.GetTree();
```

## 🤝 Contributing

Contributions are welcome! Please read the [CONTRIBUTION GUIDELINES](https://github.com/Atypical-Consulting/VirtualFileSystem/blob/main/CONTRIBUTING.md) first.

## 📜 License

This project is licensed under the terms of the BSD-3-Clause license.
If you use this library in your project, please consider adding a link to this repository in your project's README.

This project is maintained by [Atypical Consulting](https://www.atypical.consulting/). If you need help with this
project, please contact us from this repository by opening an issue.

## 📬 Contact

You can contact us by opening an issue on this repository.

## 🙌 Acknowledgements

* [All Contributors](../../contributors)
* [Atypical Consulting](https://www.atypical.consulting/)

## 🎉 Change log

Please see [RELEASES](https://github.com/Atypical-Consulting/VirtualFileSystem/releases) for more information what has changed recently.

## ✨ Contributors

[![Contributors](https://contrib.rocks/image?repo=Atypical-Consulting/VirtualFileSystem)](http://contrib.rocks)
