using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Atypical.VirtualFileSystem.Benchmarks;

[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[BenchmarkCategory("FileOperations")]
public class FileOperationsBenchmark
{
    private IVirtualFileSystem _vfs = null!;
    private const string TestContent = "This is a test file content for benchmarking purposes.";
    private const string UpdatedContent = "This is the updated content for benchmarking file update operations.";
    
    [Params(10, 100, 1000)]
    public int FileCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _vfs = new VFS();
    }

    [Benchmark(Description = "Create files")]
    public void CreateFiles()
    {
        for (int i = 0; i < FileCount; i++)
        {
            _vfs.CreateFile($"/test/file{i}.txt", TestContent);
        }
    }

    [Benchmark(Description = "Create and read files")]
    public void CreateAndReadFiles()
    {
        for (int i = 0; i < FileCount; i++)
        {
            var path = $"/test/file{i}.txt";
            _vfs.CreateFile(path, TestContent);
            var file = _vfs.GetFile(path);
            _ = file.Content;
        }
    }

    [Benchmark(Description = "Create and update files")]
    public void CreateAndUpdateFiles()
    {
        for (int i = 0; i < FileCount; i++)
        {
            var path = $"/test/file{i}.txt";
            _vfs.CreateFile(path, TestContent);
            var file = _vfs.GetFile(path);
            file.Content = UpdatedContent;
        }
    }

    [Benchmark(Description = "Create and delete files")]
    public void CreateAndDeleteFiles()
    {
        for (int i = 0; i < FileCount; i++)
        {
            var path = $"/test/file{i}.txt";
            _vfs.CreateFile(path, TestContent);
            _vfs.DeleteFile(path);
        }
    }

    [Benchmark(Description = "TryGetFile - existing")]
    public void TryGetExistingFiles()
    {
        // Setup files
        for (int i = 0; i < FileCount; i++)
        {
            _vfs.CreateFile($"/test/file{i}.txt", TestContent);
        }

        // Benchmark TryGetFile
        for (int i = 0; i < FileCount; i++)
        {
            _vfs.TryGetFile($"/test/file{i}.txt", out var file);
        }
    }

    [Benchmark(Description = "TryGetFile - non-existing")]
    public void TryGetNonExistingFiles()
    {
        for (int i = 0; i < FileCount; i++)
        {
            _vfs.TryGetFile($"/test/nonexistent{i}.txt", out var file);
        }
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _vfs = new VFS();
    }
}