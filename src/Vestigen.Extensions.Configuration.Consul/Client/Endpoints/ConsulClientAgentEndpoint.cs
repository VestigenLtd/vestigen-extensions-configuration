using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Vestigen.Extensions.Configuration.Consul.Client.Models;

namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public class ConsulClientAgentEndpoint : IConsulClientAgentEndpoint
    {
        private readonly IConsulClient _consulClient;

        public ConsulClientAgentEndpoint(IConsulClient consulClient)
        {
            _consulClient = consulClient;
        }

        public async Task<List<AgentMember>> GetMembers()
        {
            var response = await _consulClient.SendRequest(HttpMethod.Get, "v1/agent/members");

            return _consulClient.Serializer.Deserialize<List<AgentMember>>(response);
        }

        public async Task<AgentSelf> GetSelf()
        {
            var response = await _consulClient.SendRequest(HttpMethod.Get, "v1/agent/self");

            return _consulClient.Serializer.Deserialize<AgentSelf>(response);
        }
    }
}