using Vestigen.Extensions.Configuration.Consul.Client.Endpoints;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public class ConsulEndpoints : IConsulEndpoints
    {
        private readonly IConsulClient _client;

        internal ConsulEndpoints(IConsulClient client)
        {
            _client = client;
        }

        public IConsulClientAclEndpoint Acl => new ConsulClientAclEndpoint(_client);

        public IConsulClientAgentEndpoint Agent => new ConsulClientAgentEndpoint(_client);

        public IConsulClientCatalogEndpoint Secrets => new ConsulClientCatalogEndpoint(_client);

        public IConsulClientCoordinatesEndpoint Coordinates => new ConsulClientCoordinatesEndpoint(_client);

        public IConsulClientEventsEndpoint Events => new ConsulClientEventsEndpoint(_client);

        public IConsulClientHealthEndpoint Health => new ConsulClientHealthEndpoint(_client);

        public IConsulClientKeyValuesEndpoint KeyValues => new ConsulClientKeyValuesEndpoint(_client);

        public IConsulClientOperatorEndpoint Operator => new ConsulClientOperatorEndpoint(_client);

        public IConsulClientSessionsEndpoint Sessions => new ConsulClientSessionsEndpoint(_client);

        public IConsulClientSnapshotsEndpoint Snapshots => new ConsulClientSnapshotsEndpoint(_client);

        public IConsulClientStatusEndpoint Status => new ConsulClientStatusEndpoint(_client);

        public IConsulClientTransactionsEndpoint Transactions => new ConsulClientTransactionsEndpoint(_client);
    }
}