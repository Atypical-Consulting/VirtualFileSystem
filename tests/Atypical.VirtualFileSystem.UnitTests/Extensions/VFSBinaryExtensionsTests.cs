// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

using Atypical.VirtualFileSystem.Core.Extensions;
using VirtualFileSystem.UnitTests.SystemOperations;

namespace Atypical.VirtualFileSystem.UnitTests.Extensions;

public class VFSBinaryExtensionsTests : VirtualFileSystemTestsBase
{
    [Fact]
    public void CreateBinaryFile_ShouldCreateFileWithBinaryContent()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F }; // "Hello" in bytes

        // Act
        var result = vfs.CreateBinaryFile(filePath, binaryContent);

        // Assert
        result.ShouldBeSameAs(vfs);
        vfs.FileExists(filePath).ShouldBeTrue();
        var file = vfs.GetFile(filePath);
        file.Content.ShouldStartWith("[BINARY:");
        file.Content.ShouldEndWith("]");
    }

    [Fact]
    public void CreateBinaryFile_WithEmptyContent_ShouldCreateFile()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/empty.bin";
        var binaryContent = Array.Empty<byte>();

        // Act
        var result = vfs.CreateBinaryFile(filePath, binaryContent);

        // Assert
        result.ShouldBeSameAs(vfs);
        vfs.FileExists(filePath).ShouldBeTrue();
    }

    [Fact]
    public void CreateBinaryFileWithDirectories_ShouldCreateDirectoriesAndFile()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/docs/binary/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02, 0x03 };

        // Act
        var result = vfs.CreateBinaryFileWithDirectories(filePath, binaryContent);

        // Assert
        result.ShouldBeSameAs(vfs);
        vfs.DirectoryExists("/docs").ShouldBeTrue();
        vfs.DirectoryExists("/docs/binary").ShouldBeTrue();
        vfs.FileExists(filePath).ShouldBeTrue();
    }

    [Fact]
    public void CreateBinaryFileWithDirectories_WithRootFile_ShouldCreateFile()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/root.bin";
        var binaryContent = new byte[] { 0xFF, 0xFE };

        // Act
        var result = vfs.CreateBinaryFileWithDirectories(filePath, binaryContent);

        // Assert
        result.ShouldBeSameAs(vfs);
        vfs.FileExists(filePath).ShouldBeTrue();
    }

    [Fact]
    public void CreateBinaryFileFromBase64_WithValidBase64_ShouldCreateFile()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
        var base64Content = Convert.ToBase64String(binaryContent);

        // Act
        var result = vfs.CreateBinaryFileFromBase64(filePath, base64Content);

        // Assert
        result.ShouldBeSameAs(vfs);
        vfs.FileExists(filePath).ShouldBeTrue();
    }

    [Fact]
    public void CreateBinaryFileFromBase64_WithInvalidBase64_ShouldThrowFormatException()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var invalidBase64 = "Invalid-Base64!";

        // Act & Assert
        var action = () => vfs.CreateBinaryFileFromBase64(filePath, invalidBase64);
        var ex = Should.Throw<FormatException>(action);
        ex.Message.ShouldBe($"Invalid base64 string provided for file '{filePath}'.");
    }

    [Fact]
    public void TryCreateBinaryFile_WithValidInput_ShouldReturnTrueAndCreateFile()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02, 0x03, 0x04 };

        // Act
        var result = vfs.TryCreateBinaryFile(filePath, binaryContent);

        // Assert
        result.ShouldBeTrue();
        vfs.FileExists(filePath).ShouldBeTrue();
    }

    [Fact]
    public void TryCreateBinaryFile_WithDuplicatePath_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02 };
        vfs.CreateFile(filePath, "existing file");

        // Act
        var result = vfs.TryCreateBinaryFile(filePath, binaryContent);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void TryReadBinaryFile_WithBinaryMarker_ShouldReturnTrueAndContent()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var originalContent = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
        vfs.CreateBinaryFile(filePath, originalContent);

        // Act
        var result = vfs.TryReadBinaryFile(filePath, out var readContent);

        // Assert
        result.ShouldBeTrue();
        readContent.ShouldNotBeNull();
        readContent.ShouldBe(originalContent);
    }

    [Fact]
    public void TryReadBinaryFile_WithNonExistentFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.bin";

        // Act
        var result = vfs.TryReadBinaryFile(filePath, out var content);

        // Assert
        result.ShouldBeFalse();
        content.ShouldBeNull();
    }

    [Fact]
    public void TryReadBinaryFile_WithTextFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/text.txt";
        vfs.CreateFile(filePath, "This is regular text content");

        // Act
        var result = vfs.TryReadBinaryFile(filePath, out var content);

        // Assert
        result.ShouldBeFalse();
        content.ShouldBeNull();
    }

    [Fact]
    public void TryWriteBinaryFile_WithExistingFile_ShouldReturnTrueAndUpdateContent()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var originalContent = new byte[] { 0x01, 0x02 };
        var newContent = new byte[] { 0x03, 0x04, 0x05 };
        vfs.CreateBinaryFile(filePath, originalContent);

        // Act
        var result = vfs.TryWriteBinaryFile(filePath, newContent);

        // Assert
        result.ShouldBeTrue();
        vfs.TryReadBinaryFile(filePath, out var readContent);
        readContent.ShouldBe(newContent);
    }

    [Fact]
    public void TryWriteBinaryFile_WithNonExistentFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.bin";
        var content = new byte[] { 0x01, 0x02 };

        // Act
        var result = vfs.TryWriteBinaryFile(filePath, content);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsBinaryFile_WithBinaryFile_ShouldReturnTrue()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02, 0x03 };
        vfs.CreateBinaryFile(filePath, binaryContent);

        // Act
        var result = vfs.IsBinaryFile(filePath);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void IsBinaryFile_WithTextFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        vfs.CreateFile(filePath, "Text content");

        // Act
        var result = vfs.IsBinaryFile(filePath);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void IsBinaryFile_WithNonExistentFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.bin";

        // Act
        var result = vfs.IsBinaryFile(filePath);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GetFileSize_WithBinaryFile_ShouldReturnCorrectSize()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05 };
        vfs.CreateBinaryFile(filePath, binaryContent);

        // Act
        var size = vfs.GetFileSize(filePath);

        // Assert
        size.ShouldBeGreaterThan(0); // Size will be the base64 representation
    }

    [Fact]
    public void GetFileSize_WithTextFile_ShouldReturnCorrectSize()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        var content = "Hello World";
        vfs.CreateFile(filePath, content);

        // Act
        var size = vfs.GetFileSize(filePath);

        // Assert
        size.ShouldBe(11); // "Hello World" is 11 bytes in UTF-8
    }

    [Fact]
    public void GetFileSize_WithNonExistentFile_ShouldReturnMinusOne()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.txt";

        // Act
        var size = vfs.GetFileSize(filePath);

        // Assert
        size.ShouldBe(-1);
    }

    [Fact]
    public void ConvertToBinary_WithTextFile_ShouldReturnTrue()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        var textContent = "Hello World";
        vfs.CreateFile(filePath, textContent);

        // Act
        var result = vfs.ConvertToBinary(filePath);

        // Assert
        result.ShouldBeTrue();
        vfs.IsBinaryFile(filePath).ShouldBeTrue();
    }

    [Fact]
    public void ConvertToBinary_WithCustomEncoding_ShouldReturnTrue()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        var textContent = "Hello World";
        vfs.CreateFile(filePath, textContent);

        // Act
        var result = vfs.ConvertToBinary(filePath, System.Text.Encoding.ASCII);

        // Assert
        result.ShouldBeTrue();
        vfs.IsBinaryFile(filePath).ShouldBeTrue();
    }

    [Fact]
    public void ConvertToBinary_WithNonExistentFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.txt";

        // Act
        var result = vfs.ConvertToBinary(filePath);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void ConvertToText_WithBinaryFile_ShouldReturnTrue()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var originalText = "Hello World";
        var binaryContent = System.Text.Encoding.UTF8.GetBytes(originalText);
        vfs.CreateBinaryFile(filePath, binaryContent);

        // Act
        var result = vfs.ConvertToText(filePath);

        // Assert
        result.ShouldBeTrue();
        var file = vfs.GetFile(filePath);
        file.Content.ShouldContain(originalText);
    }

    [Fact]
    public void ConvertToText_WithCustomEncoding_ShouldReturnTrue()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var originalText = "Hello World";
        var encoding = System.Text.Encoding.ASCII;
        var binaryContent = encoding.GetBytes(originalText);
        vfs.CreateBinaryFile(filePath, binaryContent);

        // Act
        var result = vfs.ConvertToText(filePath, encoding);

        // Assert
        result.ShouldBeTrue();
    }

    [Fact]
    public void ConvertToText_WithNonBinaryFile_ShouldReturnFalse()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        vfs.CreateFile(filePath, "Regular text");

        // Act
        var result = vfs.ConvertToText(filePath);

        // Assert
        result.ShouldBeFalse();
    }

    [Fact]
    public void GetFileInfo_WithExistingFile_ShouldReturnFileInfo()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.txt";
        var content = "Hello World";
        vfs.CreateFile(filePath, content);

        // Act
        var fileInfo = vfs.GetFileInfo(filePath);

        // Assert
        fileInfo.ShouldNotBeNull();
        fileInfo!.Path.ShouldBe(filePath);
        fileInfo.IsBinary.ShouldBeFalse();
        fileInfo.SizeInBytes.ShouldBe(11);
        fileInfo.FileType.ShouldBe("Text");
        (DateTime.Now - fileInfo.CreationTime).ShouldBeLessThan(TimeSpan.FromHours(3));
        (DateTime.Now - fileInfo.LastWriteTime).ShouldBeLessThan(TimeSpan.FromHours(3));
    }

    [Fact]
    public void GetFileInfo_WithBinaryFile_ShouldReturnBinaryFileInfo()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/test.bin";
        var binaryContent = new byte[] { 0x01, 0x02, 0x03 };
        vfs.CreateBinaryFile(filePath, binaryContent);

        // Act
        var fileInfo = vfs.GetFileInfo(filePath);

        // Assert
        fileInfo.ShouldNotBeNull();
        fileInfo!.Path.ShouldBe(filePath);
        fileInfo.IsBinary.ShouldBeTrue();
        fileInfo.FileType.ShouldBe("Binary");
    }

    [Fact]
    public void GetFileInfo_WithNonExistentFile_ShouldReturnNull()
    {
        // Arrange
        var vfs = CreateVFS();
        var filePath = "/nonexistent.txt";

        // Act
        var fileInfo = vfs.GetFileInfo(filePath);

        // Assert
        fileInfo.ShouldBeNull();
    }

    [Theory]
    [InlineData(512, "512 B")]
    [InlineData(1024, "1.0 KB")]
    [InlineData(1536, "1.5 KB")]
    [InlineData(1048576, "1.0 MB")]
    [InlineData(1073741824, "1.0 GB")]
    public void FileInfo_SizeString_ShouldFormatCorrectly(long sizeInBytes, string expected)
    {
        // Arrange
        var fileInfo = new Atypical.VirtualFileSystem.Core.Extensions.FileInfo(
            "/test.txt", 
            false, 
            sizeInBytes, 
            DateTime.Now, 
            DateTime.Now);

        // Act
        var sizeString = fileInfo.SizeString;

        // Assert
        sizeString.ShouldBe(expected);
    }

    [Fact]
    public void FileInfo_FileType_ShouldReturnCorrectType()
    {
        // Arrange
        var textFileInfo = new Atypical.VirtualFileSystem.Core.Extensions.FileInfo(
            "/test.txt", false, 100, DateTime.Now, DateTime.Now);
        var binaryFileInfo = new Atypical.VirtualFileSystem.Core.Extensions.FileInfo(
            "/test.bin", true, 100, DateTime.Now, DateTime.Now);

        // Act & Assert
        textFileInfo.FileType.ShouldBe("Text");
        binaryFileInfo.FileType.ShouldBe("Binary");
    }
}