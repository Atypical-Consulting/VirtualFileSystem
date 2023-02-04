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
{
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
    ///     Gets a directory node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The directory node.</returns>
    IDirectoryNode GetDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Gets a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the file node.</param>
    /// <returns>The file node.</returns>
    IDirectoryNode GetDirectory(string directoryPath);

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
    ///     Try to get a directory node by its path.
    ///     The path must be absolute.
    ///     If the directory node does not exist, this method returns <c>false</c>
    ///     and <paramref name="directory" /> is set to <c>null</c>.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <param name="directory">The directory node.</param>
    /// <returns><c>true</c> if the directory node exists; otherwise, <c>false</c>.</returns>
    bool TryGetDirectory(string directoryPath, out IDirectoryNode? directory);

    /// <summary>
    ///     Creates a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Creates a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateDirectory(string directoryPath);

    /// <summary>
    ///     Deletes a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteDirectory(VFSDirectoryPath directoryPath);

    /// <summary>
    ///     Deletes a directory node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="directoryPath">The path of the directory node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteDirectory(string directoryPath);

    /// <summary>
    ///     Finds all directory nodes.
    /// </summary>
    /// <returns>The directory nodes.</returns>
    IEnumerable<IDirectoryNode> FindDirectories();

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
    ///     Gets a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <returns>The file node.</returns>
    IFileNode GetFile(string filePath);

    /// <summary>
    ///     Try to get a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="file">The file node.</param>
    /// <returns><c>true</c> if the file node exists; otherwise, <c>false</c>.</returns>
    bool TryGetFile(VFSFilePath filePath, out IFileNode? file);

    /// <summary>
    ///     Try to get a file node by its path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="file">The file node.</param>
    /// <returns><c>true</c> if the file node exists; otherwise, <c>false</c>.</returns>
    bool TryGetFile(string filePath, out IFileNode? file);

    /// <summary>
    ///     Creates a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="content">The content of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateFile(VFSFilePath filePath, string? content = null);

    /// <summary>
    ///     Creates a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <param name="content">The content of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem CreateFile(string filePath, string? content = null);

    /// <summary>
    ///     Deletes a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteFile(VFSFilePath filePath);

    /// <summary>
    ///     Deletes a file node at the specified path.
    ///     The path must be absolute.
    /// </summary>
    /// <param name="filePath">The path of the file node.</param>
    /// <returns>The file system.</returns>
    IVirtualFileSystem DeleteFile(string filePath);

    /// <summary>
    ///     Finds all file nodes.
    /// </summary>
    /// <returns>The file nodes.</returns>
    IEnumerable<IFileNode> FindFiles();

    /// <summary>
    ///     Finds all file nodes that match the specified regular expression.
    /// </summary>
    /// <param name="regexPattern">The regular expression pattern.</param>
    /// <returns>The file nodes.</returns>
    IEnumerable<IFileNode> FindFiles(Regex regexPattern);

    // TODO: Add methods for copying, moving, renaming, etc.
    // /// <summary>
    // ///     Reads the content of a file.
    // ///     The file must exist.
    // /// </summary>
    // /// <param name="path">The path to the file.</param>
    // /// <returns>The content of the file.</returns>
    // /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    // /// <exception cref="IOException">Thrown if an error occurs while reading the file.</exception>
    // string ReadContentFromFile(VFSFilePath path);
    //
    // /// <summary>
    // ///     Writes the content of a file.
    // ///     The file must exist.
    // /// </summary>
    // /// <param name="path">The path to the file.</param>
    // /// <param name="content">The content to write to the file.</param>
    // /// <exception cref="FileNotFoundException">Thrown if the file does not exist.</exception>
    // /// <exception cref="IOException">Thrown if an error occurs while writing the file.</exception>
    // void WriteContentToFile(VFSFilePath path, string content);
}