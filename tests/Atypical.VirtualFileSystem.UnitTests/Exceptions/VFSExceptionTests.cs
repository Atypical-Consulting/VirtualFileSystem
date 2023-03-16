namespace VirtualFileSystem.UnitTests.Exceptions;

public class VFSExceptionTests
{
    public class Constructor
    {
        [Fact]
        public void Constructor_Creates_VFSException_With_Message()
        {
            // Arrange
            const string message = "Test message.";

            // Act
            var exception = new VFSException(message);

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
            var exception = new VFSException(message, innerException);

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
            var exception = new VFSException(null!, innerException);

            // Assert
            exception.InnerException.Should().Be(innerException);
        }

        [Fact]
        public void Constructor_Creates_VFSException_Without_Arguments()
        {
            // Act
            var exception = new VFSException();

            // Assert
            exception.Message.Should().NotBeNull();
            exception.InnerException.Should().BeNull();
        }
    }
}