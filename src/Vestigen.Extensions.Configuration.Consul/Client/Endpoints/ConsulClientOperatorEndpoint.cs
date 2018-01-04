namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientOperatorEndpoint : IConsulClientOperatorEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientOperatorEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}