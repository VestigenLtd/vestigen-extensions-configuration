using System.Collections.Generic;
using System.Threading.Tasks;
using Vestigen.Extensions.Configuration.Consul.Client.Models;

namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public interface IConsulClientAgentEndpoint
    {
        Task<List<AgentMember>> GetMembers();
        Task<AgentSelf> GetSelf();
    }
}