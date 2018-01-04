using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfStatistics
    {
        public AgentSelfStatisticsAgent Agent { get; set; }

        public AgentSelfStatisticsBuild Build { get; set; }

        public AgentSelfStatisticsConsul Consul { get; set; }

        public AgentSelfStatisticsRaft Raft { get; set; }

        public AgentSelfStatisticsRuntime Runtime { get; set; }

        [JsonProperty("serf_lan")]
        public AgentSelfStatisticsSerf SerfLan { get; set; }

        [JsonProperty("serf_wan")]
        public AgentSelfStatisticsSerf SerfWan { get; set; }
    }
}