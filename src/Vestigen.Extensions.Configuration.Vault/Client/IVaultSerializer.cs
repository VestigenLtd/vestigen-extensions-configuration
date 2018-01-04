namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public interface IVaultSerializer
    {
        string Serialize<T>(T content);

        T Deserialize<T>(string content);
    }
}