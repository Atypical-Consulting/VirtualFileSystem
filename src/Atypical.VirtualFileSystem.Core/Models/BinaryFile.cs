// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

namespace Atypical.VirtualFileSystem.Core;

/// <summary>
/// Represents a binary file node in the virtual file system.
/// Extends the standard file node to support binary content in addition to text.
/// </summary>
public sealed record BinaryFileNode : FileNode, IBinaryFileNode
{
    private byte[] _binaryContent;

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryFileNode"/> class.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="content">The text content of the file.</param>
    public BinaryFileNode(VFSFilePath filePath, string? content = null) 
        : base(filePath, content)
    {
        _binaryContent = Array.Empty<byte>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BinaryFileNode"/> class with binary content.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <param name="binaryContent">The binary content of the file.</param>
    public BinaryFileNode(VFSFilePath filePath, byte[]? binaryContent) 
        : base(filePath, string.Empty)
    {
        _binaryContent = binaryContent ?? Array.Empty<byte>();
    }

    /// <summary>
    /// Gets or sets the binary content of the file.
    /// </summary>
    public byte[] BinaryContent
    {
        get => _binaryContent;
        set
        {
            _binaryContent = value;
            // Update text content to reflect binary data presence
            Content = _binaryContent.Length > 0 ? $"[Binary Data: {_binaryContent.Length} bytes]" : string.Empty;
        }
    }

    /// <summary>
    /// Gets the size of the binary content in bytes.
    /// </summary>
    public long SizeInBytes => _binaryContent.Length;

    /// <summary>
    /// Gets a value indicating whether this file contains binary data.
    /// </summary>
    public bool IsBinary => _binaryContent.Length > 0;

    /// <summary>
    /// Sets the content from a text string and clears binary content.
    /// </summary>
    /// <param name="textContent">The text content to set.</param>
    public void SetTextContent(string? textContent)
    {
        Content = textContent ?? string.Empty;
        _binaryContent = Array.Empty<byte>();
    }

    /// <summary>
    /// Sets the content from binary data and updates the text representation.
    /// </summary>
    /// <param name="binaryContent">The binary content to set.</param>
    public void SetBinaryContent(byte[] binaryContent)
    {
        BinaryContent = binaryContent;
    }

    /// <summary>
    /// Sets the content from a base64 encoded string.
    /// </summary>
    /// <param name="base64Content">The base64 encoded content.</param>
    /// <exception cref="FormatException">Thrown when the base64 string is invalid.</exception>
    public void SetContentFromBase64(string base64Content)
    {
        try
        {
            var binaryData = Convert.FromBase64String(base64Content);
            SetBinaryContent(binaryData);
        }
        catch (FormatException)
        {
            throw new FormatException($"Invalid base64 string provided for file '{Path.Value}'.");
        }
    }

    /// <summary>
    /// Gets the binary content as a base64 encoded string.
    /// </summary>
    /// <returns>The base64 encoded representation of the binary content.</returns>
    public string ToBase64String()
    {
        return Convert.ToBase64String(_binaryContent);
    }

    /// <summary>
    /// Creates a copy of the current binary file node.
    /// </summary>
    /// <param name="newPath">The path for the copied file.</param>
    /// <returns>A new binary file node with the same content.</returns>
    public BinaryFileNode Copy(VFSFilePath newPath)
    {
        var copy = new BinaryFileNode(newPath);
        if (IsBinary)
        {
            copy.SetBinaryContent((byte[])_binaryContent.Clone());
        }
        else
        {
            copy.SetTextContent(Content);
        }
        return copy;
    }

    /// <summary>
    /// Returns a string representation of the binary file node.
    /// </summary>
    /// <returns>A string describing the file and its content type.</returns>
    public override string ToString()
    {
        if (IsBinary)
            return $"BinaryFile: {Path.Value} ({SizeInBytes} bytes)";
        else
            return $"TextFile: {Path.Value} ({Content.Length} chars)";
    }
}

/// <summary>
/// Interface for binary file nodes that support both text and binary content.
/// </summary>
public interface IBinaryFileNode : IFileNode
{
    /// <summary>
    /// Gets or sets the binary content of the file.
    /// </summary>
    byte[] BinaryContent { get; set; }

    /// <summary>
    /// Gets the size of the binary content in bytes.
    /// </summary>
    long SizeInBytes { get; }

    /// <summary>
    /// Gets a value indicating whether this file contains binary data.
    /// </summary>
    bool IsBinary { get; }

    /// <summary>
    /// Sets the content from a text string and clears binary content.
    /// </summary>
    /// <param name="textContent">The text content to set.</param>
    void SetTextContent(string textContent);

    /// <summary>
    /// Sets the content from binary data.
    /// </summary>
    /// <param name="binaryContent">The binary content to set.</param>
    void SetBinaryContent(byte[] binaryContent);

    /// <summary>
    /// Sets the content from a base64 encoded string.
    /// </summary>
    /// <param name="base64Content">The base64 encoded content.</param>
    void SetContentFromBase64(string base64Content);

    /// <summary>
    /// Gets the binary content as a base64 encoded string.
    /// </summary>
    /// <returns>The base64 encoded representation of the binary content.</returns>
    string ToBase64String();
}