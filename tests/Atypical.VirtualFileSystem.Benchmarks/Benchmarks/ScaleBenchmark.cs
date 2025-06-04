using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Atypical.VirtualFileSystem.Benchmarks;

[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[BenchmarkCategory("Scale")]
public class ScaleBenchmark
{
    private IVirtualFileSystem _vfs = null!;
    
    [Params(1000, 5000, 10000)]
    public int FileSystemSize { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _vfs = new VFS();
    }

    [Benchmark(Description = "Create large file system")]
    public void CreateLargeFileSystem()
    {
        int filesPerDir = 10;
        int dirCount = FileSystemSize / filesPerDir;
        
        for (int i = 0; i < dirCount; i++)
        {
            var dirPath = $"/data/category{i % 10}/subcategory{i % 100}/dir{i}";
            _vfs.CreateDirectory(dirPath);
            
            for (int j = 0; j < filesPerDir; j++)
            {
                _vfs.CreateFile($"{dirPath}/file{j}.txt", $"File content {i}-{j}");
            }
        }
    }

    [Benchmark(Description = "Random access in large file system")]
    public void RandomAccessLargeFileSystem()
    {
        // First create the file system
        CreateLargeFileSystem();
        
        // Then perform random access
        var random = new Random(42);
        int accessCount = 100;
        
        for (int i = 0; i < accessCount; i++)
        {
            int dirIndex = random.Next(FileSystemSize / 10);
            int fileIndex = random.Next(10);
            var path = $"/data/category{dirIndex % 10}/subcategory{dirIndex % 100}/dir{dirIndex}/file{fileIndex}.txt";
            
            if (_vfs.TryGetFile(path, out var file))
            {
                _ = file.Content;
            }
        }
    }

    [Benchmark(Description = "Delete half of large file system")]
    public void DeleteHalfOfLargeFileSystem()
    {
        // First create the file system
        CreateLargeFileSystem();
        
        // Delete every other directory
        int filesPerDir = 10;
        int dirCount = FileSystemSize / filesPerDir;
        
        for (int i = 0; i < dirCount; i += 2)
        {
            var dirPath = $"/data/category{i % 10}/subcategory{i % 100}/dir{i}";
            if (_vfs.TryGetDirectory(dirPath, out var dir) && dir != null)
            {
                _vfs.DeleteDirectory(dirPath);
            }
        }
    }

    [Benchmark(Description = "GetTree on large file system")]
    public string GetTreeLargeFileSystem()
    {
        // Create a moderately sized file system for tree generation
        int filesPerDir = 5;
        int dirCount = Math.Min(FileSystemSize / filesPerDir, 100); // Cap for tree generation
        
        for (int i = 0; i < dirCount; i++)
        {
            var dirPath = $"/tree/branch{i % 5}/leaf{i}";
            _vfs.CreateDirectory(dirPath);
            
            for (int j = 0; j < filesPerDir; j++)
            {
                _vfs.CreateFile($"{dirPath}/doc{j}.txt", "content");
            }
        }
        
        return _vfs.GetTree();
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _vfs = new VFS();
    }
}