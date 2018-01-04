namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientEventsEndpoint : IConsulClientEventsEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientEventsEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}