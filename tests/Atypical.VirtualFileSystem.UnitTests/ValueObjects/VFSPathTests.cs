using Atypical.VirtualFileSystem.Core.Abstractions;

namespace VirtualFileSystem.UnitTests.ValueObjects;

public static class VFSPathTests
{
    public class Equality
    {
        [Fact]
        public void Equals_returns_true_when_paths_are_equal()
        {
            // Arrange
            VFSPath path1 = new VFSDirectoryPath("/path/to/file");
            VFSPath path2 = new VFSDirectoryPath("/path/to/file");
            
            // Act
            bool result = path1.Equals(path2);
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void Equals_returns_true_when_paths_are_the_same()
        {
            // Arrange
            VFSPath path1 = new VFSDirectoryPath("/path/to/file");
            VFSPath path2 = path1;
            
            // Act
            bool result = path1.Equals(path2);
            
            // Assert
            Assert.True(result);
        }
        
        [Fact]
        public void Equals_returns_false_when_paths_are_not_equal()
        {
            // Arrange
            VFSPath path1 = new VFSDirectoryPath("/path/to/file");
            VFSPath path2 = new VFSDirectoryPath("/path/to/directory");
            
            // Act
            bool result = path1.Equals(path2);
            
            // Assert
            Assert.False(result);
        }
    }
}