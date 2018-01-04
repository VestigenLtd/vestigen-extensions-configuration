using System;
using System.Collections.Generic;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class AgentMemberTags : Dictionary<string, string>
    {
        public string Build => this["build"];

        public string DatacenterName => this["dc"];

        public string Segment => this["segment"];

        public string Role => this["role"];

        public Guid Id => Guid.Parse(this["id"]);

        public int Port => int.Parse(this["port"]);

        public int RaftVersion => int.Parse(this["raft_vsn"]);

        public int VersionCur => int.Parse(this["vsn"]);

        public int VersionMin => int.Parse(this["vsn_min"]);

        public int VersionMax => int.Parse(this["vsn_max"]);
    }
}