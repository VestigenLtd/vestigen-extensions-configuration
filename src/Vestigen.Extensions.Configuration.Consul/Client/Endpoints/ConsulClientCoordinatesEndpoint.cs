using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Vestigen.Extensions.Configuration.Consul.Client.Models;

namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientCoordinatesEndpoint : IConsulClientCoordinatesEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientCoordinatesEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task<List<CoordinateDatacenter>> GetDatacenters()
        {
            var response = await _consulClient.SendRequest(HttpMethod.Get, "v1/coordinate/datacenters");

            return _consulClient.Serializer.Deserialize<List<CoordinateDatacenter>>(response);
        }

        public async Task<List<CoordinateDatacenterNode>> GetNodes(string datacenter = null)
        {
            var response = string.IsNullOrWhiteSpace(datacenter)
                ? await _consulClient.SendRequest(HttpMethod.Get, "v1/coordinate/nodes")
                : await _consulClient.SendRequest(HttpMethod.Get, $"v1/coordinate/nodes?dc={datacenter}");

            return _consulClient.Serializer.Deserialize<List<CoordinateDatacenterNode>>(response);
        }
    }
}