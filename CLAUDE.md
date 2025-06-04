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

# Build specific project
dotnet build src/Atypical.VirtualFileSystem.Core/
```

### Requirements
- .NET SDK 9.0.0 (required by global.json)
- Multi-targets .NET 8.0 and .NET 9.0
- C# 12.0 with latest language features

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
- Use FluentAssertions for readable assertions
- xUnit as test framework with Coverlet for coverage

### Test Organization
- `/SystemOperations/Commands/` - CRUD operations
- `/SystemOperations/Queries/` - Read operations
- `/Models/` - Value objects and nodes  
- `/UndoRedo/` - Change history functionality

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