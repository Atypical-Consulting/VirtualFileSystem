// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents the index of the virtual file system.
///     - a vfs index is a dictionary of vfs paths and vfs nodes
///     - the vfs index is used to store the nodes of the virtual file system
///     This class cannot be inherited.
/// </summary>
public sealed class VFSIndex
{
    private readonly SortedDictionary<string, IVirtualFileSystemNode> _index
        = new(StringComparer.OrdinalIgnoreCase);
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="VFSIndex" /> class.
    ///     - the vfs index is a dictionary of vfs paths and vfs nodes
    ///     - the vfs index is used to store the nodes of the virtual file system
    ///     - the vfs index is sorted by the vfs paths
    ///     - the vfs index is case insensitive
    /// </summary>
    public VFSIndex()
    {
    }
    
    public int Count
        => _index.Count;
    
    public SortedDictionary<string, IVirtualFileSystemNode> SortedDictionary
        => _index;

    public SortedDictionary<string, IVirtualFileSystemNode>.KeyCollection Keys
        => _index.Keys;
    
    public SortedDictionary<string, IVirtualFileSystemNode>.ValueCollection Values
        => _index.Values;
    
    public IVirtualFileSystemNode this[VFSFilePath filePath]
    {
        get => _index[filePath.Value];
        set => _index[filePath.Value] = value;
    }
    
    public IVirtualFileSystemNode this[VFSDirectoryPath directoryPath]
    {
        get => _index[directoryPath.Value];
        set => _index[directoryPath.Value] = value;
    }
    
    public IVirtualFileSystemNode this[string path]
    {
        get => _index[path];
        set => _index[path] = value;
    }
    
    public void Remove(string key)
        => _index.Remove(key);
    
    public bool TryGetValue(string key, out IVirtualFileSystemNode value)
        => _index.TryGetValue(key, out value);

    public bool ContainsKey(string key)
        => _index.ContainsKey(key);

    public bool TryAdd(string pathValue, IVirtualFileSystemNode node)
        => _index.TryAdd(pathValue, node);
}