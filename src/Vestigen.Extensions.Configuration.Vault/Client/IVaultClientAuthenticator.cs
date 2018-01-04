using System;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public interface IVaultClientAuthenticator : IDisposable
    {
        string Token { get; }

        string Address { get; }
    }
}