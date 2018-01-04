using System.Net.Http;
using System.Threading.Tasks;
using Vestigen.Extensions.Configuration.Vault.Client.Models;

namespace Vestigen.Extensions.Configuration.Vault.Client.Endpoints
{
    public class VaultClientSystemEndpoint : IVaultClientSystemEndpoint
    {
        private readonly IVaultClient _vaultClient;

        public VaultClientSystemEndpoint(IVaultClient vaultClient)
        {
            _vaultClient = vaultClient;
        }

        public async Task<SystemSealStatus> GetSealStatus()
        {
            var response = await _vaultClient.SendRequest(HttpMethod.Get, "v1/sys/seal-status");

            return _vaultClient.Serializer.Deserialize<SystemSealStatus>(response);
        }

        public async Task<SystemLeader> GetLeader()
        {
            var response = await _vaultClient.SendRequest(HttpMethod.Get, "v1/sys/leader");

            return _vaultClient.Serializer.Deserialize<SystemLeader>(response);
        }

        public async Task<SystemHealth> GetHealth()
        {
            var response = await _vaultClient.SendRequest(HttpMethod.Get, "v1/sys/health");

            return _vaultClient.Serializer.Deserialize<SystemHealth>(response);
        }
    }
}
