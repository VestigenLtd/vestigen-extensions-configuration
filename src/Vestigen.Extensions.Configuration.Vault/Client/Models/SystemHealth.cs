using System;
using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Vault.Client.Models
{
    public class SystemHealth
    {
        [JsonProperty("cluster_id")]
        public Guid ClusterId { get; set; }

        [JsonProperty("cluster_name")]
        public string ClusterName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("server_time_utc")]
        public int ServerTimestampUtc { get; set; }

        [JsonProperty("standby")]
        public bool IsStandby { get; set; }

        [JsonProperty("sealed")]
        public bool IsSealed { get; set; }

        [JsonProperty("initialized")]
        public bool IsInitialized { get; set; }
    }
}