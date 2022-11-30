// Copyright (c) 2022, Atypical Consulting SRL
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree. 

namespace VirtualFileSystem.UnitTests.ValueObjects;

public class VFSFilePathTests
{
    public class Constructor
    {
        // Business rules:
        // - The path must not be null or empty.
        // - The path contains only valid characters (a-z, A-Z, 0-9, /, ., _).
        // - The path must not contain any relative path segments (..).
        // - The path must not contain any consecutive slashes (//).
        // - The path must not end with a slash (/).

        [Fact]
        public void Constructor_throw_ArgumentNullException_when_path_is_null()
        {
            // Arrange
            const string path = null!;

            // Act
            var action = () =>
            {
                var _ = new VFSFilePath(path!);
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Constructor_throw_ArgumentException_when_path_is_empty()
        {
            // Arrange
            const string path = "";

            // Act
            var action = () =>
            {
                var _ = new VFSFilePath(path);
            };

            // Assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Constructor_throw_ArgumentException_when_path_contains_invalid_characters()
        {
            // Arrange
            const string path = @"invalid\path";

            // Act
            var action = () =>
            {
                var _ = new VFSFilePath(path);
            };

            // Assert
            action.Should().Throw<ArgumentException>();
        }
    }

    public class MethodToString
    {
        [Fact]
        public void ToString_returns_value()
        {
            // Arrange
            var filePath = new VFSFilePath("valid/path");
            const string expectedPath = "vfs://valid/path";

            // Act
            var result = filePath.ToString();

            // Assert
            result.Should().Be(expectedPath);
        }
    }

    public class MethodGetHashCode
    {
        [Fact]
        public void GetHashCode_returns_same_value_for_same_path()
        {
            // Arrange
            var filePath1 = new VFSFilePath("valid/path");
            var filePath2 = new VFSFilePath("valid/path");

            // Act
            var hashCode1 = filePath1.GetHashCode();
            var hashCode2 = filePath2.GetHashCode();

            // Assert
            hashCode1.Should().Be(hashCode2);
        }
    }

    public class ImplicitOperator
    {
        [Fact]
        public void ImplicitOperator_ToString_returns_value()
        {
            // Arrange
            var filePath = new VFSFilePath("valid/path/file.txt");
            const string expectedPath = "vfs://valid/path/file.txt";

            // Act
            string result = filePath;

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
            var filePath1 = new VFSFilePath("valid/path");
            var filePath2 = new VFSFilePath("valid/path");

            // Act
            var result = filePath1.Equals(filePath2);

            // Assert
            result.Should().BeTrue();
        }
    }
}