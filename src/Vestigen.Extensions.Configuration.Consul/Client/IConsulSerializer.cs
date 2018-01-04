namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public interface IConsulSerializer
    {
        string Serialize<T>(T content);

        T Deserialize<T>(string content);
    }
}