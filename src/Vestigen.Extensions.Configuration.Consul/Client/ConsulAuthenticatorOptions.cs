using Microsoft.Extensions.Options;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public class ConsulAuthenticatorOptions : IOptions<ConsulAuthenticatorOptions>
    {
        public static ConsulAuthenticatorOptions Default = new ConsulAuthenticatorOptions();

        public string Address { get; set; } = "https://localhost:8500";
        public string Token { get; set; }

        ConsulAuthenticatorOptions IOptions<ConsulAuthenticatorOptions>.Value => this;
    }
}