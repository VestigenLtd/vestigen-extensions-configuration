using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfConfig
    {
        [JsonProperty("Datacenter")]
        public string DatacenterName { get; set; }

        public string NodeName { get; set; }

        public string Revision { get; set; }

        public string Version { get; set; }

        [JsonProperty("Server")]
        public bool IsServer { get; set; }
    }
}