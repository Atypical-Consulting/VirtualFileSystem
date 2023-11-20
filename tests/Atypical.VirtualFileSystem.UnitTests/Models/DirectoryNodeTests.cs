// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models;

public static class DirectoryNodeTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_create_a_directory_node()
        {
            // Arrange
            var directoryPath = new VFSDirectoryPath("test");
            const string expectedPath = @"vfs://test";
            const string expectedParentPath = @"vfs://";

            // Act
            var directoryNode = new DirectoryNode(directoryPath);

            // Assert
            directoryNode.Should().NotBeNull();
            directoryNode.Directories.Should().BeEmpty();
            directoryNode.Files.Should().BeEmpty();
            directoryNode.Path.Value.Should().Be(expectedPath);
            directoryNode.Path.Parent.Should().NotBeNull();
            directoryNode.Path.Parent!.Value.Should().Be(expectedParentPath);
        }

        [Fact]
        public void Constructor_create_a_directory_node_with_parent()
        {
            var directoryPath = new VFSDirectoryPath("parent/child");
            var directory = new DirectoryNode(directoryPath);

            directory.Path.Value.Should().Be("vfs://parent/child");
            directory.Path.Parent.Should().NotBeNull();
            directory.Path.Parent!.Value.Should().Be("vfs://parent");
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_return_path()
        {
            var directoryPath = new VFSDirectoryPath("test");
            var directoryNode = new DirectoryNode(directoryPath);

            directoryNode.ToString().Should().Be("vfs://test");
        }

        [Fact]
        public void ToString_return_path_with_parent()
        {
            var directoryPath = new VFSDirectoryPath("parent/child");
            var directory = new DirectoryNode(directoryPath);

            directory.ToString().Should().Be("vfs://parent/child");
        }
    }
}