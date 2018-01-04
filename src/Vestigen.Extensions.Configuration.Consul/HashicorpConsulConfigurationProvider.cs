using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Consul.Client;

namespace Vestigen.Extensions.Configuration.Consul
{
    /// <summary>
    /// Represents Hashicorp Consul as an <see cref="ConfigurationProvider"/>.
    /// </summary>
    internal class HashicorpConsulConfigurationProvider : ConfigurationProvider
    {
        private readonly ConsulClient _client;

        /// <summary>
        /// Creates a new instance of <see cref="HashicorpConsulConfigurationProvider"/>.
        /// </summary>
        /// <param name="client">The <see cref="ConsulClient"/> to use for retrieving values.</param>
        /// <param name="serverAddress">Hashicorp Consul uri.</param>
        public HashicorpConsulConfigurationProvider(ConsulClient client, string serverAddress)
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
            //    //foreach (var secretItem in secrets)
            //    //{
            //    //    if (!_manager.Load(secretItem))
            //    //    {
            //    //        continue;
            //    //    }

            //    //    var value = await _client.GetSecretAsync(secretItem.Id);
            //    //    var key = _manager.GetKey(value);
            //    //    data.Add(key, value.Value);
            //    //}

            //    //secrets = secrets.NextPageLink != null ?
            //    //    await _client.GetSecretsNextAsync(secrets.NextPageLink) :
            //    //    null;
            //} while (secrets != null);

            Data = data;
        }
    }
}