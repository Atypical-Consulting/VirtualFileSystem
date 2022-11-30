// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace Atypical.VirtualFileSystem.Core.Abstractions;

/// <summary>
///     Represents a file system entry (file or directory) in the virtual file system.
/// </summary>
public abstract record VFSPath
{
    /// <summary>
    ///     Regex pattern for matching a valid file system path.
    /// </summary>
    private const string VFSPathRegexPattern =
        @$"^{ROOT_PATH}(?<path>([a-zA-Z0-9_\-\.]+{DIRECTORY_SEPARATOR})*[a-zA-Z0-9_\-\.]+)$";

    /// <summary>
    ///     Regex for matching a valid file system path.
    /// </summary>
    public static readonly Regex VFSPathRegex = new(VFSPathRegexPattern, RegexOptions.Compiled);

    /// <summary>
    ///     Creates a new instance of <see cref="VFSPath" />.
    /// </summary>
    /// <param name="path">The path to the file system entry.</param>
    /// <exception cref="ArgumentNullException">Thrown when the path is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the path is invalid.</exception>
    public VFSPath(string path)
    {
        ArgumentNullException.ThrowIfNull(path);

        var vfsPath = CleanVFSPathInput(path);

        if (vfsPath == ROOT_PATH)
        {
            Value = vfsPath;
            Parent = null;
            return;
        }

        if (!VFSPathRegex.IsMatch(vfsPath))
            throw new ArgumentException($"The path '{path}' is invalid.", nameof(path));

        if (vfsPath.Contains($".{DIRECTORY_SEPARATOR}") || vfsPath.Contains($"{DIRECTORY_SEPARATOR}."))
            throw new ArgumentException($"The path '{path}' contains relative path segments.", nameof(path));

        Value = vfsPath;

        // set parent path
        var lastIndexOfParentPath = vfsPath.LastIndexOf(DIRECTORY_SEPARATOR, StringComparison.Ordinal);
        var parentPath = vfsPath[..lastIndexOfParentPath] + DIRECTORY_SEPARATOR;
        Parent = new VFSDirectoryPath(parentPath);
    }

    /// <summary>
    ///     Gets the path of the file system entry with the VFS prefix.
    /// </summary>
    public string Value { get; }

    /// <summary>
    ///     Gets the path of the parent directory.
    /// </summary>
    public VFSDirectoryPath? Parent { get; }

    /// <summary>
    ///     Indicates whether the path has a parent directory.
    /// </summary>
    public bool HasParent
        => Parent != null;

    /// <summary>
    ///     Gets a value indicating whether the directory is the root directory.
    /// </summary>
    /// <returns>
    ///     <see langword="true" /> if the directory is the root directory; otherwise, <see langword="false" />.
    /// </returns>
    public bool IsRoot
        => Value == ROOT_PATH;

    /// <summary>
    ///     Gets the depth of the file system entry.
    ///     The root directory has a depth of 0.
    ///     The depth of a file is the depth of its parent directory plus one.
    ///     The depth of a directory is the depth of its parent directory plus one.
    /// </summary>
    public int Depth {
        get {
            if (IsRoot)
                return 0;

            var depth = 0;
            var path = this;
            while (path!.Value != ROOT_PATH)
            {
                path = path.Parent;
                depth++;
            }

            return depth;
        }
    }

    /// <summary>
    ///     Gets the name of the file system entry.
    ///     The name of the root directory is <see cref="ROOT_PATH" />.
    ///     The name of a file is the name of the file with its extension.
    /// </summary>
    public string Name {
        get {
            if (IsRoot)
                return ROOT_PATH;

            var lastIndexOfName = Value.LastIndexOf(DIRECTORY_SEPARATOR, StringComparison.Ordinal);
            return Value[(lastIndexOfName + 1)..];
        }
    }

    /// <summary>
    ///     Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>A value that indicates whether the current object is equal to the <paramref name="other" /> parameter.</returns>
    public virtual bool Equals(VFSPath? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Value == other.Value;
    }

    /// <summary>
    ///     Cleans the input path.
    /// </summary>
    /// <param name="path">The path to clean.</param>
    /// <returns>The cleaned path.</returns>
    private string CleanVFSPathInput(string path)
    {
        // clean up the path
        var cleanPath = path.Trim();

        // if is root path, return it
        if (cleanPath is ROOT_PATH or "")
            return cleanPath;

        // clean up the path - remove leading and trailing slashes
        cleanPath = cleanPath.TrimStart('/');
        cleanPath = cleanPath.TrimEnd('/');

        // if path does not start with the root path, add it
        if (!cleanPath.StartsWith(ROOT_PATH))
            cleanPath = $"{ROOT_PATH}{cleanPath}";

        return cleanPath;
    }

    /// <summary>
    ///     Gets the absolute path of the parent directory with depth <paramref name="depthFromRoot" />.
    ///     The root directory has a depth of 0.
    ///     The depth of a file is the depth of its parent directory plus one.
    ///     The depth of a directory is the depth of its parent directory plus one.
    /// </summary>
    /// <param name="depthFromRoot">The depth of the parent directory from the root directory.</param>
    /// <returns>The absolute path of the parent directory with depth <paramref name="depthFromRoot" />.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the depth is negative.</exception>
    public VFSPath GetAbsoluteParentPath(int depthFromRoot)
    {
        if (depthFromRoot < 0)
            throw new ArgumentOutOfRangeException(nameof(depthFromRoot),
                "The depth from root must be greater than or equal to 0.");

        if (IsRoot)
            return this;

        var path = this;
        while (path!.Depth > depthFromRoot) path = path.Parent;

        return path;
    }

    /// <summary>
    ///     Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode() => Value.GetHashCode();
}