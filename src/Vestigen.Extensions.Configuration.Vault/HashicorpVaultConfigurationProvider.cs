using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Vault.Client;

namespace Vestigen.Extensions.Configuration.Vault
{
    /// <summary>
    /// An AzureKeyVault based <see cref="ConfigurationProvider"/>.
    /// </summary>
    internal class HashicorpVaultConfigurationProvider : ConfigurationProvider
    {
        private readonly VaultClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="HashicorpVaultConfigurationProvider"/>.
        /// </summary>
        /// <param name="client">The <see cref="VaultClient"/> to use for retrieving values.</param>
        /// <param name="serverAddress">Hashicorp Consul uri.</param>
        public HashicorpVaultConfigurationProvider(VaultClient client, string serverAddress)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc />
        public override void Load()
        {
            LoadAsync().GetAwaiter().GetResult();
        }

        private async Task LoadAsync()
        {
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            //var secrets = await _client.GetSecretsAsync(_vault);
            //do
            //{
            //    foreach (var secretItem in secrets)
            //    {
            //        if (!_manager.Load(secretItem))
            //        {
            //            continue;
            //        }

            //        var value = await _client.GetSecretAsync(secretItem.Id);
            //        var key = _manager.GetKey(value);
            //        data.Add(key, value.Value);
            //    }

            //    secrets = secrets.NextPageLink != null ?
            //        await _client.GetSecretsNextAsync(secrets.NextPageLink) :
            //        null;
            //} while (secrets != null);

            Data = data;
        }
    }
}