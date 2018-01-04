using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfStatisticsAgent
    {
        [JsonProperty("check_monitors")]
        public int CheckMonitors { get; set; }

        [JsonProperty("check_ttls")]
        public int CheckTtls { get; set; }

        public int Checks { get; set; }

        public int Services { get; set; }
    }
}