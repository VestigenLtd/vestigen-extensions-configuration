using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public interface IConsulClient : IDisposable
    {
        IConsulClientAuthenticator Authenticator { get; }

        IConsulSerializer Serializer { get; }

        IConsulEndpoints Endpoints { get; }

        Task<string> SendRequest(HttpMethod method, string address, IDictionary<string, string> headers = null, string body = null, CancellationToken? ct = null);
    }
}