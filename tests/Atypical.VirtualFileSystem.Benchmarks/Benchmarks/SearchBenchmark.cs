using System.Text.RegularExpressions;
using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Atypical.VirtualFileSystem.Benchmarks;

[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[BenchmarkCategory("Search")]
public class SearchBenchmark
{
    private IVirtualFileSystem _vfs = null!;
    private Regex _filePattern = null!;
    private Regex _dirPattern = null!;
    
    [Params(100, 500, 1000)]
    public int TotalItems { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _vfs = new VFS();
        _filePattern = new Regex(@".*\.txt$", RegexOptions.Compiled);
        _dirPattern = new Regex(@".*/test\d+$", RegexOptions.Compiled);
        
        // Create a complex file system structure
        var random = new Random(42);
        for (int i = 0; i < TotalItems / 10; i++)
        {
            var dirPath = $"/root/category{i % 5}/test{i}";
            _vfs.CreateDirectory(dirPath);
            
            for (int j = 0; j < 10; j++)
            {
                var extension = random.Next(3) switch
                {
                    0 => "txt",
                    1 => "md",
                    _ => "dat"
                };
                _vfs.CreateFile($"{dirPath}/file{j}.{extension}", $"Content {i}-{j}");
            }
        }
    }

    [Benchmark(Description = "FindFiles by predicate")]
    public int FindFilesByPredicate()
    {
        return _vfs.FindFiles(f => f.Path.Value.EndsWith(".txt")).Count();
    }

    [Benchmark(Description = "FindFiles by regex")]
    public int FindFilesByRegex()
    {
        return _vfs.FindFiles(_filePattern).Count();
    }

    [Benchmark(Description = "FindFiles by content")]
    public int FindFilesByContent()
    {
        return _vfs.FindFiles(f => f.Content.Contains("Content 5")).Count();
    }

    [Benchmark(Description = "FindDirectories by predicate")]
    public int FindDirectoriesByPredicate()
    {
        return _vfs.FindDirectories(d => d.Path.Value.Contains("test")).Count();
    }

    [Benchmark(Description = "FindDirectories by regex")]
    public int FindDirectoriesByRegex()
    {
        return _vfs.FindDirectories(_dirPattern).Count();
    }

    [Benchmark(Description = "Navigate file system tree")]
    public int NavigateFileSystemTree()
    {
        int count = 0;
        void TraverseDirectory(IDirectoryNode dir)
        {
            count += dir.Files.Count();
            foreach (var subDir in dir.Directories)
            {
                TraverseDirectory(subDir);
            }
        }
        
        TraverseDirectory(_vfs.Root);
        return count;
    }

    [Benchmark(Description = "Get all files via Index")]
    public int GetAllFilesViaIndex()
    {
        return _vfs.Files.Count();
    }

    [Benchmark(Description = "Get all directories via Index")]
    public int GetAllDirectoriesViaIndex()
    {
        return _vfs.Directories.Count();
    }
}