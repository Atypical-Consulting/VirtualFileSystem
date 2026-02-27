// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models;

public static class FileNodeTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_creates_a_file_with_the_specified_name()
        {
            // Arrange
            VFSFilePath path = new("file.txt");

            // Act
            var fileNode = new FileNode(path);

            // Assert
            fileNode.Path.ShouldBe(path);
            fileNode.Content.ShouldBeEmpty();
            fileNode.IsDirectory.ShouldBeFalse();
            fileNode.IsFile.ShouldBeTrue();
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_returns_the_path_of_the_file()
        {
            // Arrange
            VFSFilePath path = new("file.txt");
            var fileNode = new FileNode(path);

            // Act
            var result = fileNode.ToString();

            // Assert
            result.ShouldBe(path.ToString());
        }
    }
}
