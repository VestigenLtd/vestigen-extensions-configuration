namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientSessionsEndpoint : IConsulClientSessionsEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientSessionsEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}