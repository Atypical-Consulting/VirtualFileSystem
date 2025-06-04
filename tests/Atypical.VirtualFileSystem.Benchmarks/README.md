# Virtual File System - Performance Benchmarks

This project contains comprehensive performance benchmarks for the Virtual File System library using **BenchmarkDotNet**.

## 🎯 Benchmark Categories

### 📁 File Operations (`FileOperationsBenchmark`)
- **Create files** - Measures file creation performance
- **Create and read files** - Tests file creation + retrieval
- **Create and update files** - Tests file creation + content modification
- **Create and delete files** - Tests complete CRUD lifecycle
- **TryGetFile operations** - Tests file lookup performance for existing/non-existing files

### 📂 Directory Operations (`DirectoryOperationsBenchmark`)
- **Create nested directories** - Tests deep directory structure creation
- **Create and delete directories** - Tests directory lifecycle
- **Move directories** - Tests directory relocation with content
- **Rename directories** - Tests directory renaming
- **List directory contents** - Tests directory enumeration performance
- **TryGetDirectory operations** - Tests directory lookup performance

### 🔍 Search & Navigation (`SearchBenchmark`)
- **FindFiles by predicate** - Tests custom search criteria
- **FindFiles by regex** - Tests pattern-based file searching
- **FindFiles by content** - Tests content-based file searching
- **FindDirectories by predicate** - Tests custom directory search
- **FindDirectories by regex** - Tests pattern-based directory searching
- **Navigate file system tree** - Tests tree traversal performance
- **Index-based queries** - Tests direct index access performance

### 📈 Scale Testing (`ScaleBenchmark`)
- **Create large file system** - Tests performance with thousands of files
- **Random access in large file system** - Tests lookup performance at scale
- **Delete operations at scale** - Tests bulk deletion performance
- **GetTree on large file system** - Tests tree generation at scale

### ↩️ Undo/Redo Operations (`UndoRedoBenchmark`)
- **Perform and undo operations** - Tests undo functionality performance
- **Perform, undo, and redo operations** - Tests complete undo/redo cycle
- **Complex mixed operations** - Tests undo/redo with varied operation types
- **Stack access operations** - Tests change history access performance

## 🚀 Running Benchmarks

### Run All Benchmarks
```bash
cd tests/Atypical.VirtualFileSystem.Benchmarks
dotnet run -c Release
```

### Run Specific Benchmark Categories
```bash
# File operations only
dotnet run -c Release -- file

# Directory operations only
dotnet run -c Release -- directory

# Search benchmarks only
dotnet run -c Release -- search

# Scale testing only
dotnet run -c Release -- scale

# Undo/Redo operations only
dotnet run -c Release -- undoredo

# All benchmarks
dotnet run -c Release -- all
```

## 📊 Sample Results

Benchmarks are parameterized to test different scales:
- **File Operations**: 10, 100, 1,000 files
- **Directory Operations**: 10, 50, 100 directories
- **Search**: 100, 500, 1,000 total items
- **Scale**: 1,000, 5,000, 10,000 items
- **Undo/Redo**: 10, 50, 100 operations

## 📈 Output Formats

The benchmarks generate results in multiple formats:
- **Console Output**: Summary statistics during execution
- **Markdown Report**: GitHub-flavored markdown (`BenchmarkDotNet.Artifacts/results/*.md`)
- **HTML Report**: Interactive HTML reports (`BenchmarkDotNet.Artifacts/results/*.html`)

## 🔧 Benchmark Configuration

The benchmarks are configured with:
- **Runtime**: .NET 9.0
- **Memory Diagnostics**: Enabled (tracks allocations)
- **Statistics**: Mean, Standard Deviation, 95th Percentile
- **Baseline Comparison**: Ratio analysis for performance trends

## 💡 Performance Tips

Based on benchmark results, consider these optimization strategies:

1. **Batch Operations**: Group multiple file/directory operations when possible
2. **Index Usage**: Leverage the built-in index for frequent lookups
3. **Memory Management**: Monitor allocation patterns in large-scale scenarios
4. **Search Optimization**: Use appropriate search methods (index vs. traversal)
5. **Change History**: Consider disabling undo/redo for performance-critical scenarios

## 🎮 Integration with Demo Apps

These benchmarks complement the demo applications:
- **Blazor Demo**: Provides interactive performance insights
- **CLI Demo**: Shows practical usage patterns
- **Benchmarks**: Quantifies performance characteristics

Together, they provide a complete picture of VFS capabilities and performance.