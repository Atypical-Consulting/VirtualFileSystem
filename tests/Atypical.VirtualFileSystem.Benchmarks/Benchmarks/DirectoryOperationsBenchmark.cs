using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Atypical.VirtualFileSystem.Benchmarks;

[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[BenchmarkCategory("DirectoryOperations")]
public class DirectoryOperationsBenchmark
{
    private IVirtualFileSystem _vfs = null!;
    
    [Params(10, 50, 100)]
    public int DirectoryCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _vfs = new VFS();
    }

    [Benchmark(Description = "Create nested directories")]
    public void CreateNestedDirectories()
    {
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.CreateDirectory($"/level1/level2/level3/dir{i}");
        }
    }

    [Benchmark(Description = "Create and delete directories")]
    public void CreateAndDeleteDirectories()
    {
        for (int i = 0; i < DirectoryCount; i++)
        {
            var path = $"/test/dir{i}";
            _vfs.CreateDirectory(path);
            _vfs.DeleteDirectory(path);
        }
    }

    [Benchmark(Description = "Move directories")]
    public void MoveDirectories()
    {
        // Setup directories
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.CreateDirectory($"/source/dir{i}");
            _vfs.CreateFile($"/source/dir{i}/file.txt", "content");
        }
        _vfs.CreateDirectory("/destination");

        // Benchmark moving
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.MoveDirectory($"/source/dir{i}", $"/destination/dir{i}");
        }
    }

    [Benchmark(Description = "Rename directories")]
    public void RenameDirectories()
    {
        // Setup directories
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.CreateDirectory($"/test/dir{i}");
        }

        // Benchmark renaming
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.RenameDirectory($"/test/dir{i}", $"renamed_dir{i}");
        }
    }

    [Benchmark(Description = "List directory contents")]
    public void ListDirectoryContents()
    {
        // Setup complex directory structure
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.CreateDirectory($"/root/dir{i}");
            for (int j = 0; j < 10; j++)
            {
                _vfs.CreateFile($"/root/dir{i}/file{j}.txt", "content");
            }
        }

        // Benchmark listing
        var root = _vfs.GetDirectory("/root");
        foreach (var dir in root.Directories)
        {
            _ = dir.Files.Count();
            _ = dir.Directories.Count();
        }
    }

    [Benchmark(Description = "TryGetDirectory - existing")]
    public void TryGetExistingDirectories()
    {
        // Setup directories
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.CreateDirectory($"/test/dir{i}");
        }

        // Benchmark TryGetDirectory
        for (int i = 0; i < DirectoryCount; i++)
        {
            _vfs.TryGetDirectory($"/test/dir{i}", out var dir);
        }
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _vfs = new VFS();
    }
}