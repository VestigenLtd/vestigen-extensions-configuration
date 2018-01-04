using Vestigen.Extensions.Configuration.Consul.Client.Endpoints;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public interface IConsulEndpoints
    {
        IConsulClientAclEndpoint Acl { get; }
        IConsulClientAgentEndpoint Agent { get; }
        IConsulClientCatalogEndpoint Secrets { get; }
        IConsulClientCoordinatesEndpoint Coordinates { get; }
        IConsulClientEventsEndpoint Events { get; }
        IConsulClientHealthEndpoint Health { get; }
        IConsulClientKeyValuesEndpoint KeyValues { get; }
        IConsulClientOperatorEndpoint Operator { get; }
        IConsulClientSessionsEndpoint Sessions { get; }
        IConsulClientSnapshotsEndpoint Snapshots { get; }
        IConsulClientStatusEndpoint Status { get; }
        IConsulClientTransactionsEndpoint Transactions { get; }
    }
}