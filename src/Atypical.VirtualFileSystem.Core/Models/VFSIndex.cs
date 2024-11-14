// Copyright (c) 2022-2024, Atypical Consulting SRL
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
    private readonly SortedDictionary<VFSPath, IVirtualFileSystemNode> _index
        = new(new VFSPathComparer());
    
    /// <summary>
    /// Gets the raw index of the virtual file system.
    /// </summary>
    public ImmutableSortedDictionary<VFSPath, IVirtualFileSystemNode> RawIndex
        => _index.ToImmutableSortedDictionary();

    /// <summary>
    /// Gets the keys of the raw index.
    /// </summary>
    public IEnumerable<VFSPath> Keys
        => _index.Keys;

    /// <summary>
    /// Gets the values of the raw index.
    /// </summary>
    public SortedDictionary<VFSPath, IVirtualFileSystemNode>.ValueCollection Values
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
        get => _index[filePath];
        set => _index[filePath] = value;
    }

    /// <summary>
    /// Gets or sets the node at the specified directory path.
    /// </summary>
    public IVirtualFileSystemNode this[VFSDirectoryPath directoryPath]
    {
        get => _index[directoryPath];
        set => _index[directoryPath] = value;
    }

    /// <summary>
    /// Removes the node with the specified key.
    /// </summary>
    public void Remove(VFSPath key)
        => _index.Remove(key);

    /// <summary>
    /// Tries to get the directory node at the specified directory path.
    /// </summary>
    /// <param name="directoryPath">The directory path.</param>
    /// <param name="directoryNode">The directory node.</param>
    /// <returns><c>true</c> if the directory node exists; otherwise, <c>false</c>.</returns>
    public bool TryGetDirectory(VFSDirectoryPath directoryPath, [MaybeNullWhen(false)] out IDirectoryNode directoryNode)
    {
        if (_index.TryGetValue(directoryPath, out var node))
        {
            directoryNode = (IDirectoryNode)node;
            return true;
        }

        directoryNode = null;
        return false;
    }
    
    /// <summary>
    /// Tries to get the file node at the specified file path.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="fileNode">The file node.</param>
    /// <returns><c>true</c> if the file node exists; otherwise, <c>false</c>.</returns>
    public bool TryGetFile(VFSFilePath filePath, [MaybeNullWhen(false)] out IFileNode fileNode)
    {
        if (_index.TryGetValue(filePath, out var node))
        {
            fileNode = (IFileNode)node;
            return true;
        }

        fileNode = null;
        return false;
    }

    /// <summary>
    /// Determines whether the index contains the specified key.
    /// </summary>
    public bool ContainsKey(VFSPath key)
        => _index.ContainsKey(key);

    /// <summary>
    /// Tries to add the specified node to the index.
    /// </summary>
    public bool TryAdd(VFSPath pathValue, IVirtualFileSystemNode node)
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
    public ImmutableArray<VFSPath> GetPathsStartingWith(VFSDirectoryPath directoryPath)
        => Keys
            .Where(p => p.StartsWith(directoryPath.Value))
            .OrderByDescending(p => p.Value.Length)
            .ToImmutableArray();

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    public override string ToString()
        => $"VFS: {FilesCount} files, {DirectoriesCount} directories";
}