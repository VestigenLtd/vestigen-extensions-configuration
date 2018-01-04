using Vestigen.Extensions.Configuration.Vault.Client.Endpoints;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public interface IVaultEndpoints
    {
        IVaultClientSystemEndpoint System { get; }
        IVaultClientAuthenticationEndpoint Authentication { get; }
        IVaultClientSecretEndpoint Secrets { get; }
    }
}