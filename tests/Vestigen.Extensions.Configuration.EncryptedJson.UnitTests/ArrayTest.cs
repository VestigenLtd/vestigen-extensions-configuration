using System.Linq;
using Microsoft.Extensions.Configuration;
using vestigen.Extensions.Configuration.EncryptedJson.UnitTests.Infrastructure;
using Vestigen.Extensions.Configuration.EncryptedJson;
using Xunit;

namespace vestigen.Extensions.Configuration.EncryptedJson.UnitTests
{
    public class ArrayTest
    {
        [Fact]
        public void ArraysAreConvertedToKeyValuePairs()
        {
            // Arrange
            const string json = @"{
                'ip': [
                    'MS4yLjMuNA==',
                    'Ny44LjkuMTA=',
                    'MTEuMTIuMTMuMTQ='
                ]
            }";
            var cryptographer = new FakeCryptogapher();
            var provider = new EncryptedJsonConfigurationProvider(new EncryptedJsonConfigurationSource(), cryptographer);

            // Act
            provider.Load(TestStreamHelpers.StringToStream(json));

            // Assert
            Assert.Equal("1.2.3.4", provider.Get("ip:0"));
            Assert.Equal("7.8.9.10", provider.Get("ip:1"));
            Assert.Equal("11.12.13.14", provider.Get("ip:2"));
        }

        [Fact]
        public void ArrayOfObjects()
        {
            // Arrange
            // first array value is raw boolean, second array value is encoded boolean (true)
            const string json = @"{
                'ip': [
                    {
                        'address': 'MS4yLjMuNA==',
                        'hidden': false
                    },
                    {
                        'address': 'NS42LjcuOA==',
                        'hidden': 'VHJ1ZQ=='
                    }
                ]
            }";
            var cryptographer = new FakeCryptogapher();
            var provider = new EncryptedJsonConfigurationProvider(new EncryptedJsonConfigurationSource(), cryptographer);

            // Act
            provider.Load(TestStreamHelpers.StringToStream(json));

            // Assert
            Assert.Equal("1.2.3.4", provider.Get("ip:0:address"));
            Assert.Equal("False", provider.Get("ip:0:hidden"));
            Assert.Equal("5.6.7.8", provider.Get("ip:1:address"));
            Assert.Equal("True", provider.Get("ip:1:hidden"));
        }

        [Fact]
        public void NestedArrays()
        {
            // Arrange
            const string json = @"{
                'ip': [
                    [ 
                        'MS4yLjMuNA==',
                        'NS42LjcuOA=='
                    ],
                    [ 
                        'OS4xMC4xMS4xMg==',
                        'MTMuMTQuMTUuMTY='
                    ],
                ]
            }";
            var cryptographer = new FakeCryptogapher();
            var provider = new EncryptedJsonConfigurationProvider(new EncryptedJsonConfigurationSource(), cryptographer);

            // Act
            provider.Load(TestStreamHelpers.StringToStream(json));

            // Assert
            Assert.Equal("1.2.3.4", provider.Get("ip:0:0"));
            Assert.Equal("5.6.7.8", provider.Get("ip:0:1"));
            Assert.Equal("9.10.11.12", provider.Get("ip:1:0"));
            Assert.Equal("13.14.15.16", provider.Get("ip:1:1"));
        }

        [Fact]
        public void ImplicitArrayItemReplacement()
        {
            // Arrange
            const string json1 = @"{
                'ip': [
                    'MS4yLjMuNA==',
                    'Ny44LjkuMTA=',
                    'MTEuMTIuMTMuMTQ='
                ]
            }";
            const string json2 = @"{
                'ip': [
                    'MTUuMTYuMTcuMTg='
                ]
            }";
            var cryptographer = new FakeCryptogapher();

            var jsonConfigSource1 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json1), Crytographer = cryptographer };
            var jsonConfigSource2 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json2), Crytographer = cryptographer };

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1);
            configurationBuilder.Add(jsonConfigSource2);

            // Act
            var config = configurationBuilder.Build();

            // Assert
            Assert.Equal(3, config.GetSection("ip").GetChildren().Count());
            Assert.Equal("15.16.17.18", config["ip:0"]);
            Assert.Equal("7.8.9.10", config["ip:1"]);
            Assert.Equal("11.12.13.14", config["ip:2"]);
        }

        [Fact]
        public void ExplicitArrayReplacement()
        {
            // Arrange
            const string json1 = @"{
                'ip': [
                    'MS4yLjMuNA==',
                    'Ny44LjkuMTA=',
                    'MTEuMTIuMTMuMTQ='
                ]
            }";
            const string json2 = @"{
                'ip': {
                    '1': 'MTUuMTYuMTcuMTg='
                }
            }";
            var cryptographer = new FakeCryptogapher();

            var jsonConfigSource1 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json1), Crytographer = cryptographer };
            var jsonConfigSource2 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json2), Crytographer = cryptographer };

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1);
            configurationBuilder.Add(jsonConfigSource2);

            // Act
            var config = configurationBuilder.Build();

            // Assert
            Assert.Equal(3, config.GetSection("ip").GetChildren().Count());
            Assert.Equal("1.2.3.4", config["ip:0"]);
            Assert.Equal("15.16.17.18", config["ip:1"]);
            Assert.Equal("11.12.13.14", config["ip:2"]);
        }

        [Fact]
        public void ArrayMerge()
        {
            const string json1 = @"{
                'ip': [
                    'MS4yLjMuNA==',
                    'Ny44LjkuMTA=',
                    'MTEuMTIuMTMuMTQ='
                ]
            }";

            const string json2 = @"{
                'ip': {
                    '3': 'MTUuMTYuMTcuMTg='
                }
            }";
            var cryptographer = new FakeCryptogapher();

            var jsonConfigSource1 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json1), Crytographer = cryptographer };
            var jsonConfigSource2 = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json2), Crytographer = cryptographer };

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource1);
            configurationBuilder.Add(jsonConfigSource2);
            var config = configurationBuilder.Build();

            Assert.Equal(4, config.GetSection("ip").GetChildren().Count());
            Assert.Equal("1.2.3.4", config["ip:0"]);
            Assert.Equal("7.8.9.10", config["ip:1"]);
            Assert.Equal("11.12.13.14", config["ip:2"]);
            Assert.Equal("15.16.17.18", config["ip:3"]);
        }

        [Fact]
        public void ArraysAreKeptInFileOrder()
        {
            const string json = @"{
                'setting': [
                    'Yg==',
                    'YQ==',
                    'Mg=='
                ]
            }";
            var cryptographer = new FakeCryptogapher();

            var jsonConfigSource = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json), Crytographer = cryptographer };

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource);
            var config = configurationBuilder.Build();

            var configurationSection = config.GetSection("setting");
            var indexConfigurationSections = configurationSection.GetChildren().ToArray();

            Assert.Equal(3, indexConfigurationSections.Count());
            Assert.Equal("b", indexConfigurationSections[0].Value);
            Assert.Equal("a", indexConfigurationSections[1].Value);
            Assert.Equal("2", indexConfigurationSections[2].Value);
        }

        [Fact]
        public void PropertiesAreSortedByNumberOnlyFirst()
        {
            const string json = @"{
                'setting': {
                    'hello': 'YQ==',
                    'bob': 'Yg==',
                    '42': 'Yw==',
                    '4':'ZA==',
                    '10': 'ZQ==',
                    '1text': 'Zg==',
                }
            }";
            var cryptographer = new FakeCryptogapher();

            var jsonConfigSource = new EncryptedJsonConfigurationSource { FileProvider = TestStreamHelpers.StringToFileProvider(json), Crytographer = cryptographer };

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.Add(jsonConfigSource);
            var config = configurationBuilder.Build();

            var configurationSection = config.GetSection("setting");
            var indexConfigurationSections = configurationSection.GetChildren().ToArray();

            Assert.Equal(6, indexConfigurationSections.Count());
            Assert.Equal("4", indexConfigurationSections[0].Key);
            Assert.Equal("10", indexConfigurationSections[1].Key);
            Assert.Equal("42", indexConfigurationSections[2].Key);
            Assert.Equal("1text", indexConfigurationSections[3].Key);
            Assert.Equal("bob", indexConfigurationSections[4].Key);
            Assert.Equal("hello", indexConfigurationSections[5].Key);
        }
    }
}
