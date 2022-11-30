// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models;

public class VirtualFileSystemFactoryTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_create_a_virtual_file_system_factory()
        {
            // Arrange
            var expectedRoot = new DirectoryNode(new VFSDirectoryPath("vfs://"));

            // Act
            var virtualFileSystemFactory = new VirtualFileSystemFactory();

            // Assert
            virtualFileSystemFactory.Should().NotBeNull();
        }
    }
    
    public class MethodCreateFileSystem
    {
        [Fact]
        public void CreateFileSystem_create_a_virtual_file_system()
        {
            // Arrange
            var virtualFileSystemFactory = new VirtualFileSystemFactory();

            // Act
            var virtualFileSystem = virtualFileSystemFactory.CreateFileSystem();

            // Assert
            virtualFileSystem.Should().NotBeNull();
            virtualFileSystem.Root.Should().NotBeNull();
            virtualFileSystem.Root.Path.Value.Should().Be("vfs://");
        }
    }
}