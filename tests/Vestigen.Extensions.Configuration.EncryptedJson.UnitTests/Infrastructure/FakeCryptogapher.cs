using System;
using System.Text;
using Vestigen.Extensions.Configuration.EncryptedJson;

namespace vestigen.Extensions.Configuration.EncryptedJson.UnitTests.Infrastructure
{
    /// <summary>
    /// An implementation that uses Base64 encoding rather than encryption for ease of testing
    /// </summary>
    public class FakeCryptogapher : IConfigurationCryptographer
    {
        public string Encrypt(string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public string Decrypt(string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }
    }
}