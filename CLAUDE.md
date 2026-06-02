# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Development Commands

### Build and Test
```bash
# Restore dependencies
dotnet restore

# Build project
dotnet build

# Run unit tests with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run demo CLI
dotnet run --project src/Atypical.VirtualFileSystem.DemoCli/

# Run the Blazor demo app
dotnet run --project src/Atypical.VirtualFileSystem.DemoBlazorApp/

# Run benchmarks (BenchmarkDotNet)
dotnet run --project tests/Atypical.VirtualFileSystem.Benchmarks/ -c Release

# Build specific project
dotnet build src/Atypical.VirtualFileSystem.Core/
```

### Requirements
- .NET SDK 10.0.x (pinned by global.json; rollForward latestMinor)
- Class libraries multi-target .NET 9.0 and .NET 10.0 (see Directory.Build.props);
  the Blazor demo app and Benchmarks project target .NET 10.0 only
- C# 13 (`LangVersion` 13) with latest language features

## Architecture Overview

### Core Design Pattern
This is an **index-based virtual file system** using a `SortedDictionary<VFSPath, IVirtualFileSystemNode>` (VFSIndex) as the central storage mechanism. All operations are O(log n) lookups with strongly-typed path classes.

### Interface Segregation
The system separates operations into focused interfaces:
- `IVFSCreate` - File/directory creation
- `IVFSDelete` - Deletion operations  
- `IVFSMove` - Move operations
- `IVFSRename` - Rename operations
- `IVirtualFileSystem` - Combines all operations with fluent API

### Event-Driven Architecture
Every operation triggers events (DirectoryCreated, FileDeleted, etc.) that inherit from `VFSEventArgs`. These events support structured logging and power the undo/redo system.

### Undo/Redo System
The `IChangeHistory` automatically tracks all operations using event args stored in undo/redo stacks. Every VFS operation is reversible.

### Node Hierarchy
```
IRootNode (vfs://)
├── IDirectoryNode (contains Files and Directories collections)
└── IFileNode (contains Content string)
```

### Path System
- `VFSRootPath` - Root directory (vfs://)
- `VFSDirectoryPath` - Directory paths with case-insensitive comparison
- `VFSFilePath` - File paths
- `VFSPath` - Base class with depth calculation and parent navigation

## Testing Conventions

### Test Structure
- Base class: `VirtualFileSystemTestsBase` provides `CreateVFS()` factory
- Naming: `VirtualFileSystem_Method{Operation}_Tests.cs`
- Use Shouldly for readable assertions (e.g. `result.ShouldBe(...)`)
- xUnit as test framework with Coverlet for coverage
- Regression tests for fixed bugs live under `/SystemOperations/Regression/` and `/UndoRedo/`

### Test Organization
- `/SystemOperations/Commands/` - CRUD operations
- `/SystemOperations/Queries/` - Read operations
- `/SystemOperations/Regression/` - Regression tests for specific fixed bugs
- `/Models/` - Value objects and nodes  
- `/UndoRedo/` - Change history functionality

### Benchmarks
- `tests/Atypical.VirtualFileSystem.Benchmarks` is a BenchmarkDotNet suite
  (file/directory/search/scale/undo-redo). Run with `-c Release`.

## Key Implementation Details

### VFSIndex is Central
The `VFSIndex` class wraps `SortedDictionary<VFSPath, IVirtualFileSystemNode>` and provides:
- Case-insensitive path lookups via `VFSPathComparer`
- Separate collections for Files and Directories
- Path prefix matching for directory contents

### Fluent API Pattern
Operations return `IVirtualFileSystem` for chaining:
```csharp
vfs.CreateDirectory("docs")
   .CreateFile("docs/readme.txt", "content")
   .CreateFile("src/main.cs");
```

### Dependency Injection
Register VFS services with `services.AddVirtualFileSystem()` extension method from ServiceCollectionExtensions.

### Documentation Generation
API documentation is auto-generated to `/docs/api/` using DefaultDocumentation during build. The `/docs/links` file maintains cross-references.