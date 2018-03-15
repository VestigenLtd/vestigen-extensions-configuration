namespace Vestigen.Extensions.Configuration.EncryptedJson
{
    public interface IConfigurationCryptographer
    {
        string Decrypt(string value);
        string Encrypt(string value);
    }
}