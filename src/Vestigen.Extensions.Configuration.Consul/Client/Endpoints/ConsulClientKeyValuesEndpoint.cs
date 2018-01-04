namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientKeyValuesEndpoint : IConsulClientKeyValuesEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientKeyValuesEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}