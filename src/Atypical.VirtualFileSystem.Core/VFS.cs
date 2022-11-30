// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
///     Represents a virtual file system.
///     This class cannot be inherited.
/// </summary>
public record VFS
    : IVirtualFileSystem
{
    public VFS()
    {
        Root = new RootNode();
        Index = new VFSIndex(Root);
    }

    public IRootNode Root { get; }
    public VFSIndex Index { get; }

    public bool IsEmpty
        => Index.Count == 1;

    #region Indexing
    
    private void AddToIndex(IVirtualFileSystemNode node)
    {
        var added = Index.TryAdd(node.Path.Value, node);
        
        if (!added)
            throw new InvalidOperationException($"The node '{node.Path}' already exists in the index.");

        if (node.Path.Parent is not null && !Index.ContainsKey(node.Path.Parent.Value))
            CreateDirectory(node.Path.Parent);
    }

    #endregion
    
    #region Directory

    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(VFSDirectoryPath)" />
    
    public IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath)
        => (IDirectoryNode)Index[directoryPath.Value];
    
    /// <inheritdoc cref="IVirtualFileSystem.GetDirectory(string)" />
    public IDirectoryNode GetDirectory(string directoryPath)
        => GetDirectory(new VFSDirectoryPath(directoryPath));
    
    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(VFSDirectoryPath, out IDirectoryNode)" />
    public bool TryGetDirectory(VFSDirectoryPath directoryPath, out IDirectoryNode? directory)
    {
        try
        {
            directory = GetDirectory(directoryPath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            directory = null;
            return false;
        }
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.TryGetDirectory(string, out IDirectoryNode)" />
    public bool TryGetDirectory(string path, out IDirectoryNode? directory)
        => TryGetDirectory(new VFSDirectoryPath(path), out directory);
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            throw new ArgumentException("Cannot create root directory.", nameof(directoryPath));

        var directory = new DirectoryNode(directoryPath);
        AddToIndex(directory);
        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateDirectory(string)" />
    public IVirtualFileSystem CreateDirectory(string path)
        => CreateDirectory(new VFSDirectoryPath(path));
    
    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(VFSDirectoryPath)" />
    public IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath)
    {
        if (directoryPath.IsRoot)
            throw new ArgumentException("Cannot delete root directory.", nameof(directoryPath));
        
        // try to get the directory
        var found = TryGetDirectory(directoryPath, out _);
        if (!found)
            throw new KeyNotFoundException($"The directory '{directoryPath}' does not exist.");

        // find the path and its children in the index
        var paths = Index.Keys
            .Where(p => p.StartsWith(directoryPath.Value))
            .OrderByDescending(p => p.Length)
            .ToList();
        
        // remove the paths from the index
        foreach (var p in paths)
            Index.Remove(p);
        
        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.DeleteDirectory(string)" />
    public IVirtualFileSystem DeleteDirectory(string directoryPath)
        => DeleteDirectory(new VFSDirectoryPath(directoryPath));
    
    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories()" />
    public IEnumerable<IDirectoryNode> FindDirectories()
        => Index.Values.OfType<IDirectoryNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindDirectories(Regex)" />
    public IEnumerable<IDirectoryNode> FindDirectories(Regex regexPattern)
        => FindDirectories().Where(f => regexPattern.IsMatch(f.Path.Value));

    #endregion
    
    #region File
    
    /// <inheritdoc cref="IVirtualFileSystem.GetFile(VFSFilePath)" />
    public IFileNode GetFile(VFSFilePath filePath)
        => (IFileNode)Index[filePath.Value];
    
    /// <inheritdoc cref="IVirtualFileSystem.GetFile(string)" />
    public IFileNode GetFile(string filePath)
        => GetFile(new VFSFilePath(filePath));
    
    /// <inheritdoc cref="IVirtualFileSystem.TryGetFile(VFSFilePath, out IFileNode)" />
    public bool TryGetFile(VFSFilePath filePath, out IFileNode? file)
    {
        try
        {
            file = GetFile(filePath);
            return true;
        }
        catch (KeyNotFoundException)
        {
            file = null;
            return false;
        }
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.TryGetFile(string, out IFileNode)" />
    public bool TryGetFile(string filePath, out IFileNode? file)
        => TryGetFile(new VFSFilePath(filePath), out file);
    
    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(VFSFilePath, string)" />
    public IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null)
    {
        var file = new FileNode(filePath, content);
        AddToIndex(file);
        return this;
    }

    /// <inheritdoc cref="IVirtualFileSystem.CreateFile(string, string)" />
    public IVirtualFileSystem CreateFile(string filePath, string? content = null)
        => CreateFile(new VFSFilePath(filePath), content);
    
    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(VFSFilePath)" />
    public IVirtualFileSystem DeleteFile(VFSFilePath filePath)
    {
        // try to get the file
        var found = TryGetFile(filePath, out _);
        if (!found)
            throw new KeyNotFoundException($"The file '{filePath}' does not exist.");
        
        // remove the file from the index
        Index.Remove(filePath.Value);
        
        return this;
    }
    
    /// <inheritdoc cref="IVirtualFileSystem.DeleteFile(string)" />
    public IVirtualFileSystem DeleteFile(string filePath)
        => DeleteFile(new VFSFilePath(filePath));
    
    /// <inheritdoc cref="IVirtualFileSystem.FindFiles()" />
    public IEnumerable<IFileNode> FindFiles()
        => Index.Values.OfType<IFileNode>();

    /// <inheritdoc cref="IVirtualFileSystem.FindFiles(Regex)" />
    public IEnumerable<IFileNode> FindFiles(Regex regexPattern)
        => FindFiles().Where(f => regexPattern.IsMatch(f.Path.Value));

    #endregion

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Root.Name);

        foreach (IVirtualFileSystemNode node in Index.Values.Skip(1))
        {
            int depth = node.Path.Depth;

            // get all brothers of the node
            var brothers = GetBrothers(node);

            // check if the node is the last node on its level
            bool isLastNodeOfLevel = brothers.Last() == node;

            while (depth > 1)
            {
                string parent = node.Path.GetAbsoluteParent(1).Value;
                bool isLastNodeOfLevelParent = GetBrothers(GetDirectory(parent)).Last() == GetDirectory(parent);

                sb.Append(isLastNodeOfLevelParent ? STR_INDENT_CLEAR : STR_INDENT_FILL);
                depth--;
            }

            sb.Append(isLastNodeOfLevel ? STR_INDENT_ENTRY_LAST : STR_INDENT_ENTRY_MIDDLE);
            sb.AppendLine(node.Path.Name);
        }

        return sb.ToString().Trim();
    }

    /// <summary>
    ///     Get all brothers of the node
    ///     (all nodes on the same level including the node itself)
    /// </summary>
    /// <param name="node">The node</param>
    /// <returns></returns>
    private List<IVirtualFileSystemNode> GetBrothers(IVirtualFileSystemNode node)
    {
        var brothers = Index.Values
            .Where(n => n.Path.Parent == node.Path.Parent)
            .ToList();
        
        return brothers;
    }
}
