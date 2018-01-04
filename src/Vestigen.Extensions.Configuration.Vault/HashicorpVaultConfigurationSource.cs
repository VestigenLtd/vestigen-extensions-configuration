using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Vault.Client;

namespace Vestigen.Extensions.Configuration.Vault
{
    /// <summary>
    /// Represents Hashicorp Vault as an <see cref="IConfigurationSource"/>.
    /// </summary>
    internal class HashicorpVaultConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Gets or sets the <see cref="VaultClient"/> to use for retrieving values.
        /// </summary>
        public VaultClient Client { get; set; }

        /// <summary>
        /// Gets or sets the vault uri.
        /// </summary>
        public string Address { get; set; }

        /// <inheritdoc />
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new HashicorpVaultConfigurationProvider(Client, Address);
        }
    }
}