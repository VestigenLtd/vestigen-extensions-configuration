using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vestigen.Extensions.Configuration.Consul.Client.Endpoints
{
    public interface IConsulClientStatusEndpoint
    {
        Task<string> GetLeader();
        Task<List<string>> GetPeers();
    }
}