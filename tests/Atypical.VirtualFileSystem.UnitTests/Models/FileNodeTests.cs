// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models;

public class FileNodeTests
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
            fileNode.Path.Should().Be(path);
            fileNode.Content.Should().BeEmpty();
            fileNode.IsDirectory.Should().BeFalse();
            fileNode.IsFile.Should().BeTrue();
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
            string result = fileNode.ToString();

            // Assert
            result.Should().Be(path.ToString());
        }
    }
}