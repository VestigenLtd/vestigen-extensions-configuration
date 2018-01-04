namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientTransactionsEndpoint : IConsulClientTransactionsEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientTransactionsEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}