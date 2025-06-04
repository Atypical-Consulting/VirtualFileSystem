using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Atypical.VirtualFileSystem.Benchmarks;

[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser]
[BenchmarkCategory("UndoRedo")]
public class UndoRedoBenchmark
{
    private IVirtualFileSystem _vfs = null!;
    
    [Params(10, 50, 100)]
    public int OperationCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _vfs = new VFS();
    }

    [Benchmark(Description = "Perform and undo file operations")]
    public void PerformAndUndoFileOperations()
    {
        // Perform operations
        for (int i = 0; i < OperationCount; i++)
        {
            _vfs.CreateFile($"/test/file{i}.txt", $"Content {i}");
        }
        
        // Undo all operations
        for (int i = 0; i < OperationCount; i++)
        {
            _vfs.ChangeHistory.Undo();
        }
    }

    [Benchmark(Description = "Perform, undo, and redo operations")]
    public void PerformUndoRedoOperations()
    {
        // Perform operations
        for (int i = 0; i < OperationCount; i++)
        {
            if (i % 3 == 0)
                _vfs.CreateDirectory($"/test/dir{i}");
            else
                _vfs.CreateFile($"/test/file{i}.txt", $"Content {i}");
        }
        
        // Undo half
        for (int i = 0; i < OperationCount / 2; i++)
        {
            _vfs.ChangeHistory.Undo();
        }
        
        // Redo half
        for (int i = 0; i < OperationCount / 2; i++)
        {
            _vfs.ChangeHistory.Redo();
        }
    }

    [Benchmark(Description = "Complex undo/redo with mixed operations")]
    public void ComplexUndoRedoMixedOperations()
    {
        // Create initial structure
        _vfs.CreateDirectory("/documents");
        _vfs.CreateDirectory("/images");
        _vfs.CreateDirectory("/temp");
        
        // Perform various operations
        for (int i = 0; i < OperationCount; i++)
        {
            switch (i % 5)
            {
                case 0:
                    _vfs.CreateFile($"/documents/doc{i}.txt", $"Document {i}");
                    break;
                case 1:
                    _vfs.CreateFile($"/images/img{i}.png", $"Image data {i}");
                    break;
                case 2:
                    if (_vfs.TryGetFile($"/documents/doc{i-5}.txt", out _))
                        _vfs.MoveFile($"/documents/doc{i-5}.txt", $"/temp/doc{i-5}.txt");
                    break;
                case 3:
                    if (_vfs.TryGetFile($"/temp/doc{i-8}.txt", out _))
                        _vfs.RenameFile($"/temp/doc{i-8}.txt", $"renamed_doc{i-8}.txt");
                    break;
                case 4:
                    if (_vfs.TryGetFile($"/images/img{i-4}.png", out _))
                        _vfs.DeleteFile($"/images/img{i-4}.png");
                    break;
            }
        }
        
        // Undo operations
        int undoCount = OperationCount / 3;
        for (int i = 0; i < undoCount; i++)
        {
            if (_vfs.ChangeHistory.UndoStack.Any())
                _vfs.ChangeHistory.Undo();
        }
        
        // Redo some operations
        int redoCount = undoCount / 2;
        for (int i = 0; i < redoCount; i++)
        {
            if (_vfs.ChangeHistory.RedoStack.Any())
                _vfs.ChangeHistory.Redo();
        }
    }

    [Benchmark(Description = "Undo/redo stack access")]
    public void UndoRedoStackAccess()
    {
        // Fill the undo stack
        for (int i = 0; i < OperationCount; i++)
        {
            _vfs.CreateFile($"/test/file{i}.txt", "content");
        }
        
        // Access stack properties
        for (int i = 0; i < 100; i++)
        {
            _ = _vfs.ChangeHistory.UndoStack.Count;
            _ = _vfs.ChangeHistory.RedoStack.Count;
            _ = _vfs.ChangeHistory.UndoStack.FirstOrDefault();
        }
    }

    [IterationCleanup]
    public void Cleanup()
    {
        _vfs = new VFS();
    }
}