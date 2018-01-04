using System;
using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Vault.Client;

namespace Vestigen.Extensions.Configuration.Vault
{
    public static class HashicorpVaultConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="serverAddress">The Hashicorp Vault uri.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddHashicorpVault(
            this IConfigurationBuilder configurationBuilder,
            string serverAddress)
        {
            if (serverAddress == null)
            {
                throw new ArgumentNullException(nameof(serverAddress));
            }

            var authenticator = new VaultAuthenticator("");
            var serializer = new VaultSerializer();

            configurationBuilder.Add(new HashicorpVaultConfigurationSource
            {
                Client = new VaultClient(authenticator, serializer),
                Address = serverAddress
            });

            return configurationBuilder;
        }
    }
}
