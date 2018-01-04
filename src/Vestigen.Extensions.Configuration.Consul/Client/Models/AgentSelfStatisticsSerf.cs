using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentSelfStatisticsSerf
    {
        [JsonProperty("coordinate_resets")]
        public int CoordinateResets { get; set; }

        [JsonProperty("encrypted")]
        public bool IsEncrypted { get; set; }

        [JsonProperty("event_queue")]
        public int EventQueue { get; set; }

        [JsonProperty("event_time")]
        public int EventTime { get; set; }    

        [JsonProperty("query_queue")]
        public int QueryQueue { get; set; }

        [JsonProperty("query_time")]
        public int QueryTime { get; set; }

        public int Failed { get; set; }

        [JsonProperty("health_score")]
        public int HealthScore { get; set; }

        [JsonProperty("intent_queue")]
        public int IntentQueue { get; set; }

        public int Left { get; set; }

        [JsonProperty("member_time")]
        public int MemberTime { get; set; }

        public int Members { get; set; }


    }
}