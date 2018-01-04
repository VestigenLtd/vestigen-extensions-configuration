using System;
using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Consul.Client;

namespace Vestigen.Extensions.Configuration.Consul
{
    public static class HashicorpConsulConfigurationBuilderExtensions
    {
        /// <summary>
        /// Adds an <see cref="IConfigurationProvider"/> that reads configuration values from the Azure KeyVault.
        /// </summary>
        /// <param name="configurationBuilder">The <see cref="IConfigurationBuilder"/> to add to.</param>
        /// <param name="serverAddress">The Hashicorp Consul uri.</param>
        /// <returns>The <see cref="IConfigurationBuilder"/>.</returns>
        public static IConfigurationBuilder AddHashicorpConsul(
            this IConfigurationBuilder configurationBuilder,
            string serverAddress)
        {
            if (serverAddress == null)
            {
                throw new ArgumentNullException(nameof(serverAddress));
            }

            var authenticator = new ConsulAuthenticator("");
            var serializer = new ConsulSerializer();

            configurationBuilder.Add(new HashicorpConsulConfigurationSource()
            {
                Client = new ConsulClient(authenticator, serializer),
                Address = serverAddress
            });

            return configurationBuilder;
        }
    }
}
