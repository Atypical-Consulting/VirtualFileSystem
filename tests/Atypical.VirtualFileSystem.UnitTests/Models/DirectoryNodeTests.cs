// Copyright (c) 2022-2024, Atypical Consulting SRL
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
            const string expectedPath = "vfs://test";
            const string expectedParentPath = "vfs://";

            // Act
            var directoryNode = new DirectoryNode(directoryPath);

            // Assert
            directoryNode.ShouldNotBeNull();
            directoryNode.Directories.ShouldBeEmpty();
            directoryNode.Files.ShouldBeEmpty();
            directoryNode.Path.Value.ShouldBe(expectedPath);
            directoryNode.Path.Parent.ShouldNotBeNull();
            directoryNode.Path.Parent!.Value.ShouldBe(expectedParentPath);
        }

        [Fact]
        public void Constructor_create_a_directory_node_with_parent()
        {
            var directoryPath = new VFSDirectoryPath("parent/child");
            var directory = new DirectoryNode(directoryPath);

            directory.Path.Value.ShouldBe("vfs://parent/child");
            directory.Path.Parent.ShouldNotBeNull();
            directory.Path.Parent!.Value.ShouldBe("vfs://parent");
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_return_path()
        {
            var directoryPath = new VFSDirectoryPath("test");
            var directoryNode = new DirectoryNode(directoryPath);

            directoryNode.ToString().ShouldBe("vfs://test");
        }

        [Fact]
        public void ToString_return_path_with_parent()
        {
            var directoryPath = new VFSDirectoryPath("parent/child");
            var directory = new DirectoryNode(directoryPath);

            directory.ToString().ShouldBe("vfs://parent/child");
        }
    }
}