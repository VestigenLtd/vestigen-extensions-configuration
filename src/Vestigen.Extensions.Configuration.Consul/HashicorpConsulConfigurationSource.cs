using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Consul.Client;

namespace Vestigen.Extensions.Configuration.Consul
{
    /// <summary>
    /// Represents Hashicorp Consul as an <see cref="IConfigurationSource"/>.
    /// </summary>
    internal class HashicorpConsulConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Gets or sets the <see cref="ConsulClient"/> to use for retrieving values.
        /// </summary>
        public ConsulClient Client { get; set; }

        /// <summary>
        /// Gets or sets the consul uri.
        /// </summary>
        public string Address { get; set; }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new HashicorpConsulConfigurationProvider(Client, Address);
        }
    }
}