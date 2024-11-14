// Copyright (c) 2022-2024, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models.ValueObjects;

public static class VFSRootPathTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_create_instance()
        {
            // Arrange
            const string expectedPath = "vfs://";

            // Act
            var directoryPath = new VFSRootPath();

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeTrue();
            directoryPath.Parent.Should().BeNull();
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_returns_value()
        {
            // Arrange
            const string expectedPath = "vfs://";

            // Act
            var directoryPath = new VFSRootPath();

            // Assert
            directoryPath.ToString().Should().Be(expectedPath);
        }
    }

    public class ImplicitOperator
    {
        [Fact]
        public void ImplicitOperator_ToString_returns_value()
        {
            // Arrange
            var rootPath = new VFSRootPath();
            const string expectedPath = "vfs://";

            // Act
            string result = rootPath;

            // Assert
            result.Should().Be(expectedPath);
        }
    }

    public class Equality
    {
        [Fact]
        public void Equals_returns_true_when_paths_are_equal()
        {
            // Arrange
            var rootPath1 = new VFSRootPath();
            var rootPath2 = new VFSRootPath();

            // Act
            var result = rootPath1.Equals(rootPath2);

            // Assert
            result.Should().BeTrue();
        }
    }
}