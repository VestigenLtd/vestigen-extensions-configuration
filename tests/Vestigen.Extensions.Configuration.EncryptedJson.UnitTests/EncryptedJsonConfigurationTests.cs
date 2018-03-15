using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;
using Moq;
using vestigen.Extensions.Configuration.EncryptedJson.UnitTests.Infrastructure;
using Vestigen.Extensions.Configuration.EncryptedJson;
using Xunit;

namespace vestigen.Extensions.Configuration.EncryptedJson.UnitTests
{
    public class EncryptedJsonConfigurationTests
    {
        private EncryptedJsonConfigurationProvider LoadProvider(string json)
        {
            var cryptographer = new FakeCryptogapher();
            var p = new EncryptedJsonConfigurationProvider(new EncryptedJsonConfigurationSource { Optional = true }, cryptographer);
            p.Load(TestStreamHelpers.StringToStream(json));
            return p;
        }

        [Fact]
        public void LoadKeyValuePairsFromValidJson()
        {
            var json = @"
{
    'firstname': 'dGVzdA==',
    'test.last.name': 'bGFzdC5uYW1l',
        'residential.address': {
            'street.name': 'U29tZXRoaW5nIHN0cmVldA==',
            'zipcode': 'MTIzNDU='
        }
}";
            var jsonConfigSrc = LoadProvider(json);

            Assert.Equal("test", jsonConfigSrc.Get("firstname"));
            Assert.Equal("last.name", jsonConfigSrc.Get("test.last.name"));
            Assert.Equal("Something street", jsonConfigSrc.Get("residential.address:STREET.name"));
            Assert.Equal("12345", jsonConfigSrc.Get("residential.address:zipcode"));
        }

        [Fact]
        public void LoadMethodCanHandleEmptyValue()
        {
            var json = @"
{
    'name': ''
}";
            var jsonConfigSrc = LoadProvider(json);
            Assert.Equal(string.Empty, jsonConfigSrc.Get("name"));
        }

        [Fact]
        public void LoadWithCulture()
        {
            var previousCulture = CultureInfo.CurrentCulture;

            try
            {
                CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

                var json = @"
{
    'number': 3.14
}";
                var jsonConfigSrc = LoadProvider(json);
                Assert.Equal("3.14", jsonConfigSrc.Get("number"));
            }
            finally
            {
                CultureInfo.CurrentCulture = previousCulture;
            }
        }

        [Fact]
        public void NonObjectRootIsInvalid()
        {
            var json = @"'test'";

            var exception = Assert.Throws<FormatException>(
                () => LoadProvider(json));

            Assert.NotNull(exception.Message);
        }

        [Fact]
        public void SupportAndIgnoreComments()
        {
            var json = @"/* Comments */
                {/* Comments */
                ""name"": /* Comments */ ""dGVzdA=="",
                ""address"": {
                    ""street"": ""U29tZXRoaW5nIHN0cmVldA=="", /* Comments */
                    ""zipcode"": ""MTIzNDU=""
                }
            }";
            var jsonConfigSrc = LoadProvider(json);
            Assert.Equal("test", jsonConfigSrc.Get("name"));
            Assert.Equal("Something street", jsonConfigSrc.Get("address:street"));
            Assert.Equal("12345", jsonConfigSrc.Get("address:zipcode"));
        }

        [Fact]
        public void ThrowExceptionWhenUnexpectedEndFoundBeforeFinishParsing()
        {
            var json = @"{
                'name': 'test',
                'address': {
                    'street': 'Something street',
                    'zipcode': '12345'
                }
            /* Missing a right brace here*/";
            var exception = Assert.Throws<FormatException>(() => LoadProvider(json));
            Assert.NotNull(exception.Message);
        }

        [Fact]
        public void ThrowExceptionWhenMissingCurlyBeforeFinishParsing()
        {
            // Arrange
            var json = @"
            {
              'Data': {
            ";

            // Act
            Action capture = () => LoadProvider(json);

            // Assert
            var exception = Assert.Throws<FormatException>(capture);
            Assert.Contains("Could not parse the JSON file.", exception.Message);
        }

        [Fact]
        public void ThrowExceptionWhenPassingNullAsFilePath()
        {
            // Arrange
            var expectedMsg = new ArgumentException("File path must be a non-empty string.", "path").Message;
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder();

            // Act
            Action capture = () => configurationBuilder.AddEncryptedJsonFile(cryptographer.Object, path: null);

            // Assert
            var exception = Assert.Throws<ArgumentException>(capture);
            Assert.Equal(expectedMsg, exception.Message);
        }

        [Fact]
        public void ThrowExceptionWhenPassingEmptyStringAsFilePath()
        {
            // Arrange
            var expectedMsg = new ArgumentException("File path must be a non-empty string.", "path").Message;
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder();

            // Act
            Action capture = () => configurationBuilder.AddEncryptedJsonFile(cryptographer.Object, string.Empty);

            // Assert
            var exception = Assert.Throws<ArgumentException>(capture);
            Assert.Equal(expectedMsg, exception.Message);
        }

        [Fact]
        public void JsonConfiguration_Throws_On_Missing_Configuration_File()
        {
            // Arrange
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder()
                .AddEncryptedJsonFile(cryptographer.Object, "NotExistingConfig.json", optional: false);

            // Act
            Action capture = () => configurationBuilder.Build();

            // Assert
            var exception = Assert.Throws<FileNotFoundException>(capture);
            Assert.StartsWith($"The configuration file 'NotExistingConfig.json' was not found and is not optional. The physical path is '", exception.Message);
        }

        [Fact]
        public void JsonConfiguration_Does_Not_Throw_On_Optional_Configuration()
        {
            // Arrange
            var cryptographer = new Mock<IConfigurationCryptographer>();
            var configurationBuilder = new ConfigurationBuilder();

            // Act
            configurationBuilder.AddEncryptedJsonFile(cryptographer.Object, "NotExistingConfig.json", optional: true).Build();
        }

        [Fact]
        public void ThrowFormatExceptionWhenFileIsEmpty()
        {
            // Act
            Action capture = () => LoadProvider(@"");

            // Assert
            Assert.Throws<FormatException>(capture);
        }
    }
}