using Microsoft.Extensions.Configuration;

namespace Vestigen.Extensions.Configuration.EncryptedJson
{
    /// <summary>
    /// Represents a JSON file as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class EncryptedJsonConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Builds the <see cref="EncryptedJsonConfigurationProvider"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="EncryptedJsonConfigurationProvider"/></returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new EncryptedJsonConfigurationProvider(this, Crytographer);
        }
        
        public IConfigurationCryptographer Crytographer { get; set; }
    }
}