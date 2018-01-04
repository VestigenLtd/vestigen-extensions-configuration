using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public class ConsulSerializer : IConsulSerializer
    {
        public string Serialize<T>(T content)
        {
            return JsonConvert.SerializeObject(content, ConsulJsonSerializerSettings());
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, ConsulJsonSerializerSettings());
        }

        private static JsonSerializerSettings ConsulJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }
    }
}