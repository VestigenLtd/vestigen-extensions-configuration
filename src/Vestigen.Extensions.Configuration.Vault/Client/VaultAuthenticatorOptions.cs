using Microsoft.Extensions.Options;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public class VaultAuthenticatorOptions : IOptions<VaultAuthenticatorOptions>
    {
        public static VaultAuthenticatorOptions Default = new VaultAuthenticatorOptions();

        public string Address { get; set; } = "https://localhost:8200";
        public string Token { get; set; }

        VaultAuthenticatorOptions IOptions<VaultAuthenticatorOptions>.Value => this;
    }
}