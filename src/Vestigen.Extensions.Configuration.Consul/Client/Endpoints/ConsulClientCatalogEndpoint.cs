namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientCatalogEndpoint : IConsulClientCatalogEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientCatalogEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}