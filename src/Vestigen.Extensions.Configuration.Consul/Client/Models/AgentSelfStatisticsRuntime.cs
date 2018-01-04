using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfStatisticsRuntime
    {
        [JsonProperty("arch")]
        public string Architecture { get; set; }

        [JsonProperty("os")]
        public string OperatingSystem { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("cpu_count")]
        public int CpuCount { get; set; }

        [JsonProperty("max_procs")]
        public int MaxProcs { get; set; }

        public int GoRoutines { get; set; }
    }
}