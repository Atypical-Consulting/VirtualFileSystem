// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Contracts;

/// <summary>
///     Represents a virtual file system.
///     This is the main entry point for all operations on the file system.
///     You can get an instance of this interface by calling <see cref="IVirtualFileSystemFactory.CreateFileSystem" />.
/// </summary>
public interface IVirtualFileSystem
    : IVFSCreate, IVFSDelete, // CRUD operations
        IVFSMove, IVFSRename
{
    /// <summary>
    ///     Gets the change history of the file system.
    /// </summary>
    /// <value>The change history.</value>
    IChangeHistory ChangeHistory { get; }
    
    /// <summary>
    ///     Gets the root directory of the file system.
    ///     This is the entry point for all operations on the file system.
    /// </summary>
    IRootNode Root { get; }

    /// <summary>
    ///     Gets the file index of the file system.
    ///     Basically, this is a dictionary that maps file paths to file nodes.
    ///     This is useful for quickly finding a file node by its path.
    /// </summary>
    VFSIndex Index { get; }

    /// <summary>
    ///     Indicates whether the file system is empty.
    ///     This is the case if the root directory is empty.
    /// </summary>
    bool IsEmpty { get; }

    /// <summary>
    ///     Gets the path of the root directory.
    /// </summary>
    /// <value>The path of the root directory.</value>
    VFSPath RootPath { get; }
    
    /// <summary>
    ///     Finds all directory nodes.
    /// </summary>
    /// <value>The directory nodes.</value>
    IEnumerable<IDirectoryNode> Directories { get; }
    
    /// <summary>
    ///     Finds all file nodes.
    /// </summary>
    /// <value>The file nodes.</value>
    IEnumerable<IFileNode> Files { get; }

    /// <summary>
    ///     Gets a directory node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The directory node.</returns>
    IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Try to get a directory node by its path.
    ///     The path must be absolute.
    ///     If the directory node does not exist, this method returns <c>false</c>
    ///     and <paramref name="directory" /> is set to <c>null</c>.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <param name="directory">The directory node.</param>
    /// <returns><c>true</c> if the directory node exists; otherwise, <c>false</c>.</returns>
    bool TryGetDirectory(VFSDirectoryPath directoryPath, out IDirectoryNode? directory);

    /// <summary>
    ///     Finds all directory nodes that match the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns>The directory nodes.</returns>
    IEnumerable<IDirectoryNode> FindDirectories(
        Func<IDirectoryNode, bool> predicate);

    /// <summary>
    ///     Finds all directory nodes that match the specified regular expression.
    ///     The regular expression must be relative to the root directory.
    /// </summary>
    /// <param name="regexPattern">The regular expression pattern.</param>
    /// <returns>The directory nodes.</returns>
    IEnumerable<IDirectoryNode> FindDirectories(Regex regexPattern);

    /// <summary>
    ///     Gets a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <returns>The file node.</returns>
    IFileNode GetFile(VFSFilePath filePath);

    /// <summary>
    ///     Try to get a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="file">The file node.</param>
    /// <returns><c>true</c> if the file node exists; otherwise, <c>false</c>.</returns>
    bool TryGetFile(VFSFilePath filePath, out IFileNode? file);

    /// <summary>
    ///     Finds all file nodes that match the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate.</param>
    /// <returns>The file nodes.</returns>
    IEnumerable<IFileNode> FindFiles(Func<IFileNode, bool> predicate);

    /// <summary>
    ///     Finds all file nodes that match the specified regular expression.
    /// </summary>
    /// <param name="regexPattern">The regular expression pattern.</param>
    /// <returns>The file nodes.</returns>
    IEnumerable<IFileNode> FindFiles(Regex regexPattern);
    
    // GetTree
    /// <summary>
    ///     Gets the tree of the file system.
    /// </summary>
    /// <returns>The tree of the file system.</returns>
    string GetTree();
}