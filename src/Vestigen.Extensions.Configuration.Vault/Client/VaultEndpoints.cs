using Vestigen.Extensions.Configuration.Vault.Client.Endpoints;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public class VaultEndpoints : IVaultEndpoints
    {
        private readonly IVaultClient _client;

        public VaultEndpoints(IVaultClient client)
        {
            _client = client;
        }

        public IVaultClientSystemEndpoint System => new VaultClientSystemEndpoint(_client);
        public IVaultClientAuthenticationEndpoint Authentication => new VaultClientAuthenticationEndpoint(_client);
        public IVaultClientSecretEndpoint Secrets => new VaultClientSecretEndpoint(_client);
    }
}