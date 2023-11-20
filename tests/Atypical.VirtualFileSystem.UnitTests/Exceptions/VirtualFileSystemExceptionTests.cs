namespace VirtualFileSystem.UnitTests.Exceptions;

public static class VirtualFileSystemExceptionTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_Creates_VFSException_With_Message()
        {
            // Arrange
            const string message = "Test message.";

            // Act
            var exception = new VirtualFileSystemException(message);

            // Assert
            exception.Message.Should().Be(message);
        }

        [Fact]
        public void Constructor_Creates_VFSException_With_Message_And_InnerException()
        {
            // Arrange
            const string message = "Test message.";
            var innerException = new InvalidOperationException("Inner exception message.");

            // Act
            var exception = new VirtualFileSystemException(message, innerException);

            // Assert
            exception.Message.Should().Be(message);
            exception.InnerException.Should().Be(innerException);
        }

        [Fact]
        public void Constructor_Creates_VFSException_With_InnerException()
        {
            // Arrange
            var innerException = new InvalidOperationException("Inner exception message.");

            // Act
            var exception = new VirtualFileSystemException(null!, innerException);

            // Assert
            exception.InnerException.Should().Be(innerException);
        }

        [Fact]
        public void Constructor_Creates_VFSException_Without_Arguments()
        {
            // Act
            var exception = new VirtualFileSystemException();

            // Assert
            exception.Message.Should().NotBeNull();
            exception.InnerException.Should().BeNull();
        }
    }
}