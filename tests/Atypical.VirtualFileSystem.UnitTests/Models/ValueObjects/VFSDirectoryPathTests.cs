// Copyright (c) 2022-2023, Atypical Consulting SRL
// All rights reserved... but seriously, we're open to sharing if you ask nicely!
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.Models.ValueObjects;

public static class VFSDirectoryPathTests
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
                .Throw<VirtualFileSystemException>()
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
                .Throw<VirtualFileSystemException>()
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
                .Throw<VirtualFileSystemException>()
                .WithMessage("The path 'vfs://invalid/../path' contains a relative path segment.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_contains_consecutive_slashes()
        {
            // Arrange
            const string path = "invalid//path";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VirtualFileSystemException>()
                .WithMessage("The path 'vfs://invalid//path' is invalid.");
        }

        [Fact]
        public void Constructor_throw_VFSException_when_path_is_not_a_directory_path()
        {
            // Arrange
            const string path = "invalid/path.txt";

            // Act
            var action = () =>
            {
                var _ = new VFSDirectoryPath(path);
            };

            // Assert
            action.Should()
                .Throw<VirtualFileSystemException>()
                .WithMessage("The directory path 'invalid/path.txt' contains a file extension.");
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid()
        {
            // Arrange
            const string path = "valid/path";
            const string expectedPath = "vfs://valid/path";

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
            const string path = "valid/PATH";
            const string expectedPath = "vfs://valid/PATH";

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
            const string path = "valid/123";
            const string expectedPath = "vfs://valid/123";

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
            const string path = "/valid/path";
            const string expectedPath = "vfs://valid/path";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
        }
        
        
        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_ends_with_slash()
        {
            // Arrange
            const string path = "valid/path/";
            const string expectedPath = "vfs://valid/path";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Value.Should().NotBeNull();
            vfsPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_starts_with_slash()
        {
            // Arrange
            const string path = "/valid/path";
            const string expectedPath = "vfs://valid/path";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Value.Should().NotBeNull();
            vfsPath.Value.Should().Be(expectedPath);
        }
        
        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_starts_with_dot()
        {
            // Arrange
            const string path = "/.github";
            const string expectedPath = "vfs://.github";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Value.Should().NotBeNull();
            vfsPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_when_path_is_valid_and_starts_and_ends_with_slash()
        {
            // Arrange
            const string path = "/valid/path/";
            const string expectedPath = "vfs://valid/path";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Value.Should().NotBeNull();
            vfsPath.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void Constructor_create_instance_for_root_directory()
        {
            // Arrange
            const string path = "/";
            const string expectedPath = "vfs://";

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
            const string path = "/valid";
            const string expectedPath = "vfs://valid";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeFalse();
            directoryPath.Parent.Should().NotBeNull();
            directoryPath.Parent!.Value.Should().Be("vfs://");
        }

        [Fact]
        public void Constructor_create_instance_for_nested_directory()
        {
            // Arrange
            const string path = "/valid/path";
            const string expectedPath = "vfs://valid/path";

            // Act
            var directoryPath = new VFSDirectoryPath(path);

            // Assert
            directoryPath.Should().NotBeNull();
            directoryPath.Value.Should().Be(expectedPath);
            directoryPath.IsRoot.Should().BeFalse();
            directoryPath.Parent.Should().NotBeNull();
            directoryPath.Parent!.Value.Should().Be("vfs://valid");
        }
    }

    public class PropertyName
    {
        [Fact]
        public void PropertyName_return_name_of_directory()
        {
            // Arrange
            const string path = "valid/path";
            const string expectedName = "path";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Name.Should().Be(expectedName);
        }
    }

    public class PropertyDepth
    {
        [Fact]
        public void PropertyDepth_return_0_when_path_is_root()
        {
            // Arrange
            const string path = "/";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Depth.Should().Be(0);
        }

        [Fact]
        public void PropertyDepth_return_1_with_one_directory()
        {
            // Arrange
            const string path = "directory";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Depth.Should().Be(1);
        }

        [Fact]
        public void PropertyDepth_return_2_with_two_directories()
        {
            // Arrange
            const string path = "directory/subdirectory";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Depth.Should().Be(2);
        }

        [Fact]
        public void PropertyDepth_return_3_with_three_directories()
        {
            // Arrange
            const string path = "directory/subdirectory/subsubdirectory";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Depth.Should().Be(3);
        }
    }

    public class PropertyHasParent
    {
        [Fact]
        public void PropertyHasParent_return_false_when_path_is_root()
        {
            // Arrange
            const string path = "/";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.HasParent.Should().BeFalse();
        }

        [Fact]
        public void PropertyHasParent_return_true_when_path_has_parent()
        {
            // Arrange
            const string path = "directory/subdirectory";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.HasParent.Should().BeTrue();
        }
    }

    public class PropertyParent
    {
        [Fact]
        public void PropertyParentPath_return_null_when_path_is_root()
        {
            // Arrange
            const string path = "/";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Parent.Should().BeNull();
        }
        
        [Fact]
        public void PropertyParentPath_return_parent_path_when_path_has_parent()
        {
            // Arrange
            const string path = "directory/subdirectory";
            const string expectedParentPath = "vfs://directory";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.Parent.Should().NotBeNull();
            vfsPath.Parent!.Value.Should().Be(expectedParentPath);
        }
    }

    public class MethodGetAbsoluteParentPath
    {
        [Fact]
        public void MethodGetAbsoluteParentPath_return_root_when_path_is_root()
        {
            // Arrange
            const string path = "/";
            const string expectedPath = "vfs://";
            var vfsPath = new VFSDirectoryPath(path);

            // Act
            var parent = vfsPath.GetAbsoluteParentPath(0);

            // Assert
            parent.Should().NotBeNull();
            parent.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void MethodGetAbsoluteParentPath_throw_VFSException_when_depth_is_negative()
        {
            // Arrange
            const string path = "directory/subdirectory";
            var vfsPath = new VFSDirectoryPath(path);

            // Act
            Action action = () => vfsPath.GetAbsoluteParentPath(-1);

            // Assert
            action.Should()
                .Throw<VirtualFileSystemException>()
                .WithMessage($"""
                    The depth from root must be greater than or equal to 0.
                    Actual value: {-1}.
                    """);
        }

        [Fact]
        public void MethodGetAbsoluteParentPath_return_root_when_depth_is_zero()
        {
            // Arrange
            const string path = "directory/subdirectory";
            const string expectedPath = "vfs://";
            var vfsPath = new VFSDirectoryPath(path);

            // Act
            var parent = vfsPath.GetAbsoluteParentPath(0);

            // Assert
            parent.Should().NotBeNull();
            parent.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void MethodGetAbsoluteParentPath_return_parent_when_depth_is_one()
        {
            // Arrange
            const string path = "directory/subdirectory";
            const string expectedPath = "vfs://directory";
            var vfsPath = new VFSDirectoryPath(path);

            // Act
            var parent = vfsPath.GetAbsoluteParentPath(1);

            // Assert
            parent.Should().NotBeNull();
            parent.Value.Should().Be(expectedPath);
        }

        [Fact]
        public void MethodGetAbsoluteParentPath_return_grandparent_when_depth_is_two()
        {
            // Arrange
            const string path = "directory/subdirectory/subsubdirectory";
            const string expectedPath = "vfs://directory/subdirectory";
            var vfsPath = new VFSDirectoryPath(path);

            // Act
            var parent = vfsPath.GetAbsoluteParentPath(2);

            // Assert
            parent.Should().NotBeNull();
            parent.Value.Should().Be(expectedPath);
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_return_path()
        {
            // Arrange
            const string path = "test";
            const string expectedPath = "vfs://test";
            var directoryPath = new VFSDirectoryPath(path);

            // Act
            var result = directoryPath.ToString();

            // Assert
            result.Should().Be(expectedPath);
        }
        
        [Fact]
        public void ToString_returns_path_with_child()
        {
            // Arrange
            const string path = "valid/path";
            const string expectedPath = "vfs://valid/path";

            // Act
            var vfsPath = new VFSDirectoryPath(path);

            // Assert
            vfsPath.ToString().Should().Be(expectedPath);
        }

        [Fact]
        public void ToString_return_path_with_vfs_prefix()
        {
            // Arrange
            const string path = "valid/path";
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

        [Fact]
        public void Equals_returns_true_when_paths_are_the_same()
        {
            // Arrange
            const string path = "valid/path";

            // Act
            var vfsPath1 = new VFSDirectoryPath(path);

            // Assert
            vfsPath1.Equals(vfsPath1).Should().BeTrue();
        }

        [Fact]
        public void Equals_returns_false_when_paths_are_not_equal()
        {
            // Arrange
            const string path1 = "valid/path";
            const string path2 = "valid/path2";

            // Act
            var vfsPath1 = new VFSDirectoryPath(path1);
            var vfsPath2 = new VFSDirectoryPath(path2);

            // Assert
            vfsPath1.Equals(vfsPath2).Should().BeFalse();
        }

        [Fact]
        public void Equals_returns_false_when_paths_are_not_equal_and_one_is_file()
        {
            // Arrange
            const string path1 = "valid/path";
            const string path2 = "valid/path/file.txt";

            // Act
            var vfsPath1 = new VFSDirectoryPath(path1);
            var vfsPath2 = new VFSFilePath(path2);

            // Assert
            vfsPath1.Equals(vfsPath2).Should().BeFalse();
        }
    }
}