using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientStatusEndpoint : IConsulClientStatusEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientStatusEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task<string> GetLeader()
        {
            var response = await _consulClient.SendRequest(HttpMethod.Get, "v1/status/leader");

            return response;
        }

        public async Task<List<string>> GetPeers()
        {
            var response = await _consulClient.SendRequest(HttpMethod.Get, "v1/status/peers");

            return _consulClient.Serializer.Deserialize<List<string>>(response);
        }
    }
}
