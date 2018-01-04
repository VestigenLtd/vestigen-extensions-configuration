using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public interface IVaultClient : IDisposable
    {
        IVaultClientAuthenticator Authenticator { get; }

        IVaultSerializer Serializer { get; }

        IVaultEndpoints Endpoints { get; }

        Task<string> SendRequest(HttpMethod method, string address, IDictionary<string, string> headers = null, string body = null, CancellationToken? ct = null);
    }
}