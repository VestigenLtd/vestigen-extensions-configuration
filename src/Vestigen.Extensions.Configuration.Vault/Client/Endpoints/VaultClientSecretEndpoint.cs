namespace Vestigen.Extensions.Configuration.Vault.Client.Endpoints
{
    public class VaultClientSecretEndpoint : IVaultClientSecretEndpoint
    {
        private IVaultClient _vaultClient;

        public VaultClientSecretEndpoint(IVaultClient vaultClient)
        {
            _vaultClient = vaultClient;
        }
    }
}