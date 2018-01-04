namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientAclEndpoint : IConsulClientAclEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientAclEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }
    }
}