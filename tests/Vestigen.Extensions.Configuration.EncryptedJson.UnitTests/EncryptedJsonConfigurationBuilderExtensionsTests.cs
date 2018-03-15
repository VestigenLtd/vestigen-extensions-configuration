using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using Vestigen.Extensions.Configuration.EncryptedJson;
using Xunit;

namespace vestigen.Extensions.Configuration.EncryptedJson.UnitTests
{
    public class EncryptedJsonConfigurationBuilderExtensionsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void AddJsonFile_ThrowsIfFilePathIsNullOrEmpty(string path)
        {
            // Arrange
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder();

            // Act
            Action capture = () => configurationBuilder.AddEncryptedJsonFile(cryptographer.Object, path);

            // Assert
            var ex = Assert.Throws<ArgumentException>(capture);
            Assert.Equal("path", ex.ParamName);
            Assert.StartsWith("File path must be a non-empty string.", ex.Message);
        }

        [Fact]
        public void AddJsonFile_ThrowsIfFileDoesNotExistAtPath()
        {
            // Arrange
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder();
            var path = "file-does-not-exist.json";

            // Act
            Action capture = () => configurationBuilder.AddEncryptedJsonFile(cryptographer.Object, path).Build();

            // Act and Assert
            var ex = Assert.Throws<FileNotFoundException>(capture);
            Assert.StartsWith($"The configuration file '{path}' was not found and is not optional. The physical path is '", ex.Message);
        }
    }
}