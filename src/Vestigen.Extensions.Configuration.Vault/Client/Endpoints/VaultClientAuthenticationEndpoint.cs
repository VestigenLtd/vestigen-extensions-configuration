namespace Vestigen.Extensions.Configuration.Vault.Client.Endpoints
{
    public class VaultClientAuthenticationEndpoint : IVaultClientAuthenticationEndpoint
    {
        private IVaultClient _vaultClient;

        public VaultClientAuthenticationEndpoint(IVaultClient vaultClient)
        {
            _vaultClient = vaultClient;
        }
    }
}