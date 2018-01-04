using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfStatisticsRaft
    {
        [JsonProperty("applied_index")]
        public int AppliedIndex { get; set; }

        [JsonProperty("commit_index")]
        public int CommitIndex { get; set; }

        [JsonProperty("fsm_pending")]
        public int FsmPending { get; set; }

        [JsonProperty("last_contact")]
        public int LastContact { get; set; }

        [JsonProperty("last_log_index")]
        public int LastLogIndex { get; set; }

        [JsonProperty("last_log_term")]
        public int LastLogTerm { get; set; }

        [JsonProperty("last_snapshot_index")]
        public int LastSnapshotIndex { get; set; }

        [JsonProperty("last_snapshot_term")]
        public int LastSnapshotTerm { get; set; }

        [JsonProperty("latest_configuration")]
        public string LatestConfiguration { get; set; }

        [JsonProperty("latest_configuration_index")]
        public int LatestConfigurationIndex { get; set; }

        [JsonProperty("protocol_version_min")]
        public int ProtocolVersionMin { get; set; }

        [JsonProperty("protocol_version_max")]
        public int ProtocolVersionMax { get; set; }

        [JsonProperty("protocol_version")]
        public int ProtocolVersionCur { get; set; }

        [JsonProperty("snapshot_version_min")]
        public int SnapshotVersionMin { get; set; }
    
        [JsonProperty("snapshot_version_max")]
        public int SnapshotVersionMax { get; set; }

        public string State { get; set; }

        public int Term { get; set; }

        [JsonProperty("num_peers")]
        public int Peers { get; set; }
    }
}