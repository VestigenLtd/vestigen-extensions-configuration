using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client.Models
{
    public class Coordinate
    {
        public double Adjustment { get; set; }
        public double Error { get; set; }
        public double Height { get; set; }

        [JsonProperty("vec")]
        public double[] Vector { get; set; }
    }
}