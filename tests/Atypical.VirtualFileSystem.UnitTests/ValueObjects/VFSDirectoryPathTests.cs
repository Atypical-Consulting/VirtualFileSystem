// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.ValueObjects;

public class VFSDirectoryPathTests
{
    public class Constructor
    {
        // Business rules:
        // - The path must not be null or empty.
        // - The path contains only valid characters (a-z, A-Z, 0-9, /, ., _).
        // - The path must not contain any relative path segments (..).
        // - The path must not contain any consecutive slashes (//).

        [Fact]
        public void Constructor_throw_VFSException_when_path_is_null()
        {
            // Arrange
            const string path = null!;

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path!);
            };

            // Assert
            action.Should()
                .Throw<VFSException>()
                .WithMessage("An empty path is invalid.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_is_empty()
        {
            // Arrange
            const string path = "";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VFSException>()
                .WithMessage("An empty path is invalid.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_contains_relative_path_segments()
        {
            // Arrange
            const string path = @"invalid\..\path";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VFSException>()
                .WithMessage("The path 'vfs://invalid/../path' contains a relative path segment.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_contains_consecutive_slashes()
        {
            // Arrange
            const string path = @"invalid//path";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VFSException>()
                .WithMessage("The path 'vfs://invalid//path' is invalid.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_is_not_a_directory_path()
        {
            // Arrange
            const string path = @"invalid/path.txt";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VFSException>()
                .WithMessage("The directory path 'invalid/path.txt' contains a file extension.");
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid()
        {
            // Arrange
            const string path = @"valid/path";
            const string expectedPath = @"vfs://valid/path";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_contains_uppercase_characters()
        {
            // Arrange
            const string path = @"valid/PATH";
            const string expectedPath = @"vfs://valid/PATH";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_contains_numbers()
        {
            // Arrange
            const string path = @"valid/123";
            const string expectedPath = @"vfs://valid/123";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_when_path_has_leading_slash()
        {
            // Arrange
            const string path = @"/valid/path";
            const string expectedPath = @"vfs://valid/path";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_for_root_directory()
        {
            // Arrange
            const string path = @"/";
            const string expectedPath = @"vfs://";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeTrue();
            directoryPath.Parent.Should().BeNull();
        }

        [Fact]
        public void Constructor_create_instance_for_simple_directory()
        {
            // Arrange
            const string path = @"/valid";
            const string expectedPath = @"vfs://valid";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeFalse();
            directoryPath.Parent.Should().NotBeNull();
            directoryPath.Parent!.Value.Should().Be(@"vfs://");
        }

        [Fact]
        public void Constructor_create_instance_for_nested_directory()
        {
            // Arrange
            const string path = @"/valid/path";
            const string expectedPath = @"vfs://valid/path";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeFalse();
            directoryPath.Parent.Should().NotBeNull();
            directoryPath.Parent!.Value.Should().Be(@"vfs://valid");
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_return_path()
        {
            // Arrange
            const string path = @"test";
            const string expectedPath = @"vfs://test";
            var directoryPath = new VFSDirectoryPath(path);

            // Act
            var result = directoryPath.ToString();

            // Assert
            result.Should().Be(expectedPath);
        }

        [Fact]
        public void ToString_return_path_with_vfs_prefix()
        {
            // Arrange
            const string path = @"valid/path";
            var directoryPath = new VFSDirectoryPath(path);

            // Act
            var result = directoryPath.ToString();

            // Assert
            result.Should().Be($"vfs://{path}");
        }
    }

    public class ImplicitOperator
    {
        [Fact]
        public void ImplicitOperator_ToString_returns_value()
        {
            // Arrange
            var directoryPath = new VFSDirectoryPath("valid/path");
            const string expectedPath = "vfs://valid/path";

            // Act
            string result = directoryPath;

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
            var directoryPath1 = new VFSDirectoryPath("valid/path");
            var directoryPath2 = new VFSDirectoryPath("valid/path");

            // Act
            var result = directoryPath1.Equals(directoryPath2);

            // Assert
            result.Should().BeTrue();
        }
    }
}