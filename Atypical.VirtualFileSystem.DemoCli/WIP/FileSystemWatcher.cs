// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using Atypical.VirtualFileSystem.Core;
using Atypical.VirtualFileSystem.Core.Contracts;

namespace Atypical.VirtualFileSystem.DemoCli.WIP;

public class FileSystemWatcher : IFileSystemWatcher
{
    private readonly IVirtualFileSystem _fileSystem;
    private readonly Dictionary<VFSPath, DateTimeOffset> _lastModified;
    private readonly Timer _timer;
    private bool _isWatching;

    public event Action<VFSPath>? OnChanged;

    public FileSystemWatcher(IVirtualFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
        _lastModified = new Dictionary<VFSPath, DateTimeOffset>();
        _timer = new Timer(CheckForChanges, null, Timeout.Infinite, Timeout.Infinite);
        
        _fileSystem.FileCreated += OnFileCreated;
        // _fileSystem.FileDeleted += OnFileDeleted;
        _fileSystem.DirectoryCreated += OnDirectoryCreated;
        // _fileSystem.DirectoryDeleted += OnDirectoryDeleted;
    }

    public void StartWatching()
    {
        _isWatching = true;
        _timer.Change(0, 1000); // Check for changes every second
    }

    public void StopWatching()
    {
        _isWatching = false;
        _timer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    private void CheckForChanges(object? state)
    {
        if (!_isWatching) return;

        var allNodes = _fileSystem.Directories.Cast<IVirtualFileSystemNode>().Concat(_fileSystem.Files);

        foreach (var node in allNodes)
        {
            if (!_lastModified.TryGetValue(node.Path, out var lastModified) || lastModified < node.LastWriteTime)
            {
                _lastModified[node.Path] = node.LastWriteTime;
                OnChanged?.Invoke(node.Path);
            }
        }
    }

    private void OnFileCreated(VFSFileCreatedArgs args)
    {
        var filePath = args.Path;
        _lastModified[filePath] = _fileSystem.GetFile(filePath).LastWriteTime;
    }

    private void OnDirectoryCreated(VFSDirectoryCreatedArgs args)
    {
        var directoryPath = args.Path;
        _lastModified[directoryPath] = _fileSystem.GetDirectory(directoryPath).LastWriteTime;
    }

    private void OnFileDeleted(VFSFilePath filePath)
    {
        _lastModified.Remove(filePath);
    }

    private void OnDirectoryDeleted(VFSDirectoryPath directoryPath)
    {
        _lastModified.Remove(directoryPath);
    }
}