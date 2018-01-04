using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Vault.Client.Models
{
    /// <summary>
    /// Information about the Vault's current leader
    /// </summary>
    /// <remarks>This call can be made unauthenticated</remarks>
    public class SystemLeader
    {
        [JsonProperty("ha_enabled")]
        public bool IsHighlyAvailable { get; set; }

        [JsonProperty("is_self")]
        public bool IsLeader { get; set; }

        [JsonProperty("leader_address")]
        public string LeaderAddress { get; set; }

        [JsonProperty("leader_cluster_address")]
        public string LeaderClusterAddress { get; set; }
    }
}