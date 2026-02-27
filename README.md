# Virtual File System

> **Test filesystem code without touching the real disk — fast, deterministic, and disposable.**

<!-- Badges: Row 1 — Identity -->
[![Atypical-Consulting - VirtualFileSystem](https://img.shields.io/static/v1?label=Atypical-Consulting&message=VirtualFileSystem&color=blue&logo=github)](https://github.com/Atypical-Consulting/VirtualFileSystem "Go to GitHub repo")
[![License: BSD-3-Clause](https://img.shields.io/badge/License-BSD--3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)
[![.NET](https://img.shields.io/badge/.NET-9.0%20%7C%2010.0-purple?logo=dotnet)](https://dotnet.microsoft.com/)
[![stars - VirtualFileSystem](https://img.shields.io/github/stars/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)
[![forks - VirtualFileSystem](https://img.shields.io/github/forks/Atypical-Consulting/VirtualFileSystem?style=social)](https://github.com/Atypical-Consulting/VirtualFileSystem)

<!-- Badges: Row 2 — Activity -->
[![GitHub tag](https://img.shields.io/github/tag/Atypical-Consulting/VirtualFileSystem?include_prereleases=&sort=semver&color=blue)](https://github.com/Atypical-Consulting/VirtualFileSystem/releases/)
[![issues - VirtualFileSystem](https://img.shields.io/github/issues/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/issues)
[![GitHub pull requests](https://img.shields.io/github/issues-pr/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/pulls)
[![GitHub last commit](https://img.shields.io/github/last-commit/Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/commits/main)

<!-- Badges: Row 3 — Quality -->
[![Build](https://github.com/Atypical-Consulting/VirtualFileSystem/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Atypical-Consulting/VirtualFileSystem/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/Atypical-Consulting/VirtualFileSystem/branch/main/graph/badge.svg?token=041C4QKW6O)](https://codecov.io/gh/Atypical-Consulting/VirtualFileSystem)

<!-- Badges: Row 4 — Distribution -->
[![NuGet](https://img.shields.io/nuget/v/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)
[![NuGet](https://img.shields.io/nuget/dt/Atypical.VirtualFileSystem.svg)](https://www.nuget.org/packages/Atypical.VirtualFileSystem)

---

## Table of Contents

- [The Problem](#the-problem)
- [The Solution](#the-solution)
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Demo Applications](#demo-applications)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Documentation](#documentation)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Acknowledgments](#acknowledgments)

## The Problem

When writing .NET applications, you often need to read or write files. The standard `System.IO` namespace handles this well at runtime, but testing becomes painful. Unit tests that depend on the real filesystem are slow, brittle, leave temp files behind, and break in CI when paths differ across machines. Mocking `System.IO` is verbose and error-prone — you end up testing mock wiring instead of actual logic.

## The Solution

**Virtual File System** provides a complete in-memory filesystem that's fast, deterministic, and disposable. Create files and directories, read and write content, subscribe to change events, and even undo/redo operations — all without touching the real disk.

```csharp
// Create a virtual file system and add some files
IVirtualFileSystem vfs = new VFS()
    .CreateFile("src/Program.cs", "Console.WriteLine(\"Hello!\");")
    .CreateFile("src/Utils.cs")
    .CreateFile("tests/ProgramTests.cs");

// Print the tree
Console.WriteLine(vfs.GetTree());
// vfs://
// ├── src
// │   ├── Program.cs
// │   └── Utils.cs
// └── tests
//     └── ProgramTests.cs
```

## Features

- [x] Create a virtual file system
- [x] Create, read, update, and delete virtual files and directories
- [x] Print the contents of a virtual file system as a tree
- [x] Move and rename virtual files and directories
- [x] Check if a virtual file or directory exists (`TryGetFile`, `TryGetDirectory`)
- [x] Get the size of a virtual file or directory
- [x] Get the creation, access, and modification times
- [x] Event-driven architecture (file created, deleted, moved, etc.)
- [x] Undo/redo operations with change history
- [x] Advanced search capabilities (by name, content, regex patterns)
- [x] File system analytics and insights
- [x] GitHub repository loading extension (via `Atypical.VirtualFileSystem.GitHub`)

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# 13 |
| Runtime | .NET 9.0 / .NET 10.0 |
| UI (Demo) | Blazor Server + Tailwind CSS |
| GitHub Integration | Octokit 14.x |
| DI | Microsoft.Extensions.DependencyInjection |
| CLI (Demo) | Spectre.Console |
| Testing | xUnit |
| Build | dotnet CLI / Nuke |

## Getting Started

### Prerequisites

- .NET 9.0 or higher (.NET 10.0 recommended)
- A C# IDE (Visual Studio, Rider, VS Code)

### Installation

**Option 1 — NuGet** *(recommended)*

```bash
dotnet add package Atypical.VirtualFileSystem
```

Or add a package reference to your project file:

```xml
<PackageReference Include="Atypical.VirtualFileSystem" Version="0.5.0" />
```

**Option 2 — From Source**

```bash
git clone https://github.com/Atypical-Consulting/VirtualFileSystem.git
cd VirtualFileSystem
dotnet build
```

## Usage

### Basic Example

```csharp
// Create a virtual file system and populate it
IVirtualFileSystem vfs = new VFS()
    .CreateFile("superheroes/batman.txt")
    .CreateFile("superheroes/superman.txt")
    .CreateFile("superheroes/wonderwoman.txt")
    .CreateFile("villains/joker.txt")
    .CreateFile("villains/lexluthor.txt")
    .CreateFile("villains/penguin.txt")
    .CreateFile("world/gotham.txt")
    .CreateFile("world/metropolis.txt")
    .CreateFile("world/themyscira.txt");

// Get the string representation of the virtual file system
string tree = vfs.GetTree();
```

Expected output:

```
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
```

## Demo Applications

The library includes comprehensive demo applications that showcase its capabilities.

### Blazor Server Demo

A full-featured web application built with **Blazor Server** and **Tailwind CSS** providing an interactive demonstration of all VFS features.

```bash
cd src/Atypical.VirtualFileSystem.DemoBlazorApp
dotnet run
# Open your browser to https://localhost:5040
```

**Demo features:** Dashboard with file system overview, file operations with real-time feedback, advanced multi-criteria search, full-featured file editor, analytics and insights, undo/redo history management, real-time event monitoring, and responsive design.

### Console Demo

A command-line demonstration showcasing basic VFS operations:

```bash
cd src/Atypical.VirtualFileSystem.DemoCli
dotnet run
```

## Architecture

```
┌─────────────────────────────────────────────────────┐
│                   Consumer Code                      │
│            (Your app / tests / demos)                │
└──────────────────────┬──────────────────────────────┘
                       │
         ┌─────────────▼─────────────┐
         │   IVirtualFileSystem      │
         │   (Core Interface)        │
         └─────────────┬─────────────┘
                       │
         ┌─────────────▼─────────────┐
         │   VFS (Implementation)    │
         │                           │
         │  ┌─────────────────────┐  │
         │  │  VirtualDirectory   │  │
         │  │  VirtualFile        │  │
         │  │  (Node Tree)        │  │
         │  └─────────────────────┘  │
         │                           │
         │  ┌─────────────────────┐  │
         │  │  UndoRedo Manager   │  │
         │  │  (Change History)   │  │
         │  └─────────────────────┘  │
         │                           │
         │  ┌─────────────────────┐  │
         │  │  Event System       │  │
         │  │  (Change Notifications)│
         │  └─────────────────────┘  │
         └─────────────┬─────────────┘
                       │
    ┌──────────────────▼──────────────────┐
    │   Extensions                         │
    │  ┌──────────────────────────────┐   │
    │  │  VirtualFileSystem.GitHub    │   │
    │  │  (Load repos into VFS)       │   │
    │  └──────────────────────────────┘   │
    └─────────────────────────────────────┘
```

### Project Structure

```
VirtualFileSystem/
├── src/
│   ├── Atypical.VirtualFileSystem.Core/       # Core library (IVirtualFileSystem, VFS, models)
│   │   ├── Contracts/                         # Interfaces and abstractions
│   │   ├── Models/                            # VirtualFile, VirtualDirectory, paths
│   │   ├── Services/                          # Search, analytics services
│   │   ├── SystemOperations/                  # File system operations
│   │   ├── UndoRedo/                          # Undo/redo infrastructure
│   │   └── Extensions/                        # Extension methods
│   ├── Atypical.VirtualFileSystem.GitHub/     # GitHub repo loader extension
│   ├── Atypical.VirtualFileSystem.DemoBlazorApp/  # Blazor Server demo
│   └── Atypical.VirtualFileSystem.DemoCli/    # Console demo
├── tests/
│   ├── Atypical.VirtualFileSystem.UnitTests/  # Unit tests
│   ├── Atypical.VirtualFileSystem.GitHub.Tests/ # GitHub extension tests
│   └── Atypical.VirtualFileSystem.Benchmarks/ # Performance benchmarks
├── docs/                                      # Auto-generated API documentation
├── build/                                     # Build scripts
└── .github/workflows/                         # CI/CD pipelines
```

## Documentation

**Virtual File System** provides [complete API documentation](https://github.com/Atypical-Consulting/VirtualFileSystem/blob/main/docs/README.md) generated automatically using [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation).

## Roadmap

- [ ] Copy a virtual file or directory
- [ ] Support for custom metadata on files and directories
- [ ] Support for file and directory permissions
- [ ] Support for symbolic links

> Want to contribute? Pick any roadmap item and open a PR!

## Stats

<!-- Get your hash from https://repobeats.axiom.co -->
<!-- ![Alt](https://repobeats.axiom.co/api/embed/{hash}.svg "Repobeats analytics image") -->

## Contributing

Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) first.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit using [conventional commits](https://www.conventionalcommits.org/) (`git commit -m 'feat: add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

[BSD-3-Clause](LICENSE) &copy; 2022-2025 [Atypical Consulting](https://atypical.garry-ai.cloud)

## Acknowledgments

- [All Contributors](../../contributors)
- [Atypical Consulting](https://www.atypical.consulting/)
- [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation) for API doc generation
- [Spectre.Console](https://spectreconsole.net/) for beautiful CLI output
- [Octokit](https://github.com/octokit/octokit.net) for GitHub integration

---

Built with care by [Atypical Consulting](https://atypical.garry-ai.cloud) — opinionated, production-grade open source.

[![Contributors](https://contrib.rocks/image?repo=Atypical-Consulting/VirtualFileSystem)](https://github.com/Atypical-Consulting/VirtualFileSystem/graphs/contributors)
