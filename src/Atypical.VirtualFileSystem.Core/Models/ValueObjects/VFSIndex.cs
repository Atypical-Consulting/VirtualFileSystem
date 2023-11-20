// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

using System.Collections.Immutable;

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents the index of the virtual file system.
/// </summary>
/// <remarks>
/// The vfs index is a dictionary of vfs paths and vfs nodes.
/// The vfs index is used to store the nodes of the virtual file system.
/// The vfs index is sorted by the vfs paths.
/// The vfs index is case insensitive.
/// This class cannot be inherited.
/// </remarks>
public sealed class VFSIndex
{
    private readonly SortedDictionary<string, IVirtualFileSystemNode> _index
        = new(StringComparer.OrdinalIgnoreCase);
    
    /// <summary>
    /// Gets the raw index of the virtual file system.
    /// </summary>
    public ImmutableSortedDictionary<string, IVirtualFileSystemNode> RawIndex
        => _index.ToImmutableSortedDictionary();

    /// <summary>
    /// Gets the keys of the raw index.
    /// </summary>
    public IEnumerable<string> Keys
        => _index.Keys;

    /// <summary>
    /// Gets the values of the raw index.
    /// </summary>
    public SortedDictionary<string, IVirtualFileSystemNode>.ValueCollection Values
        => _index.Values;

    /// <summary>
    /// Gets the total count of nodes in the index.
    /// </summary>
    public int Count
        => _index.Count;

    /// <summary>
    /// Gets a value indicating whether the index is empty.
    /// </summary>
    public bool IsEmpty
        => Count == 0;

    /// <summary>
    /// Gets the directories in the index.
    /// </summary>
    public IEnumerable<IDirectoryNode> Directories
        => Values.OfType<IDirectoryNode>();

    /// <summary>
    /// Gets the count of directories in the index.
    /// </summary>
    public int DirectoriesCount
        => Directories.Count();

    /// <summary>
    /// Gets the files in the index.
    /// </summary>
    public IEnumerable<IFileNode> Files 
        => Values.OfType<IFileNode>();

    /// <summary>
    /// Gets the count of files in the index.
    /// </summary>
    public int FilesCount
        => Files.Count();

    /// <summary>
    /// Gets or sets the node at the specified file path.
    /// </summary>
    public IVirtualFileSystemNode this[VFSFilePath filePath]
    {
        get => _index[filePath.Value];
        set => _index[filePath.Value] = value;
    }

    /// <summary>
    /// Gets or sets the node at the specified directory path.
    /// </summary>
    public IVirtualFileSystemNode this[VFSDirectoryPath directoryPath]
    {
        get => _index[directoryPath.Value];
        set => _index[directoryPath.Value] = value;
    }

    /// <summary>
    /// Gets or sets the node at the specified path.
    /// </summary>
    public IVirtualFileSystemNode this[string path]
    {
        get => _index[path];
        set => _index[path] = value;
    }

    /// <summary>
    /// Removes the node with the specified key.
    /// </summary>
    public void Remove(string key)
        => _index.Remove(key);

    /// <summary>
    /// Tries to get the value associated with the specified key.
    /// </summary>
    public bool TryGetValue(string key, out IVirtualFileSystemNode value)
        => _index.TryGetValue(key, out value);

    /// <summary>
    /// Determines whether the index contains the specified key.
    /// </summary>
    public bool ContainsKey(string key)
        => _index.ContainsKey(key);

    /// <summary>
    /// Tries to add the specified node to the index.
    /// </summary>
    public bool TryAdd(string pathValue, IVirtualFileSystemNode node)
        => _index.TryAdd(pathValue, node);

    /// <summary>
    /// Gets the file node at the specified file path.
    /// </summary>
    public IFileNode GetFile(VFSFilePath filePath)
        => (IFileNode)this[filePath];

    /// <summary>
    /// Gets the directory node at the specified directory path.
    /// </summary>
    public IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath)
        => (IDirectoryNode)this[directoryPath];

    /// <summary>
    /// Gets the paths starting with the specified directory path.
    /// </summary>
    public ImmutableArray<string> GetPathsStartingWith(VFSDirectoryPath directoryPath)
        => Keys
            .Where(p => p.StartsWith(directoryPath.Value))
            .OrderByDescending(p => p.Length)
            .ToImmutableArray();

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    public override string ToString()
        => $"VFS: {FilesCount} files, {DirectoriesCount} directories";
}