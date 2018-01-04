using System.Collections.Generic;
using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class CoordinateDatacenter
    {
        [JsonProperty("datacenter")]
        public string DatacenterName { get; set; }

        public string AreaId { get; set; }

        public List<CoordinateDatacenterNode> Coordinates { get; set; }
    }
}