// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.SystemOperations;

public static class VirtualFileSystemFactoryTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_create_a_virtual_file_system_factory()
        {
            // Act
            var virtualFileSystemFactory = new VirtualFileSystemFactory();

            // Assert
            virtualFileSystemFactory.ShouldNotBeNull();
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
            virtualFileSystem.ShouldNotBeNull();
            virtualFileSystem.Root.ShouldNotBeNull();
            virtualFileSystem.Root.Path.Value.ShouldBe("vfs://");
        }
    }
}