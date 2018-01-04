using System.Threading;
using Microsoft.Extensions.Options;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public class ConsulAuthenticator : IConsulClientAuthenticator
    {
        private readonly IOptions<ConsulAuthenticatorOptions> _options;
        private readonly CancellationTokenSource _cancellation;

        public ConsulAuthenticator(string address, string token = null) 
            : this(new ConsulAuthenticatorOptions { Address = address, Token = token })
        {
        }

        public ConsulAuthenticator(IOptions<ConsulAuthenticatorOptions> options)
        {
            _options = options;
            _cancellation = new CancellationTokenSource();

            if (_options.Value.Token != null)
            {
                // TODO: Start a long running task here that refreshes tokens automatically
                // using the cancellation source to spin it down correctly.
            }
        }

        public string Token => _options.Value.Token;

        public string Address => _options.Value.Address;

        public string TokenHeader => "X-Consul-Token";

        public void Dispose()
        {
            _cancellation.Cancel();
        }
    }
}