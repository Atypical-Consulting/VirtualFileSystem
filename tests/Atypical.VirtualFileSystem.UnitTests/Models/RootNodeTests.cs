// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models;

public static class RootNodeTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_create_a_root_node()
        {
            // Arrange
            const string expectedPath = "vfs://";

            // Act
            var rootNode = new RootNode();

            // Assert
            rootNode.ShouldNotBeNull();
            rootNode.Directories.ShouldBeEmpty();
            rootNode.Files.ShouldBeEmpty();
            rootNode.Path.Value.ShouldBe(expectedPath);
            rootNode.Path.Parent.ShouldBeNull();
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_return_path()
        {
            var rootNode = new RootNode();

            rootNode.ToString().ShouldBe("vfs://");
        }
    }
}