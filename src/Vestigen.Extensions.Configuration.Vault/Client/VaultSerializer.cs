using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public class VaultSerializer : IVaultSerializer
    {
        public string Serialize<T>(T content)
        {
            return JsonConvert.SerializeObject(content, VaultJsonSerializerSettings());
        }

        public T Deserialize<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content, VaultJsonSerializerSettings());
        }

        private static JsonSerializerSettings VaultJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            };
        }
    }
}