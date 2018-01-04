using System;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public interface IConsulClientAuthenticator : IDisposable
    {
        string Token { get; }

        string Address { get; }
    }
}