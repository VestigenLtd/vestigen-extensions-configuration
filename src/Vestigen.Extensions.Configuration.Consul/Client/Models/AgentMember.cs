using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentMember
    {
        public string Name { get; set; }

        [JsonProperty("addr")]
        public string Address { get; set; }

        public int Port { get; set; }

        public AgentMemberTags Tags { get; set; }

        public int Status { get; set; }

        public int ProtocolMin { get; set; }

        public int ProtocolMax { get; set; }

        public int ProtocolCur { get; set; }

        public int DelegateMin { get; set; }

        public int DelegateMax { get; set; }

        public int DelegateCur { get; set; }
    }
}