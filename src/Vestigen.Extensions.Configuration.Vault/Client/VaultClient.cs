using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public class VaultClient : IVaultClient
    {
        private readonly HttpClient _httpClient;
        

        public VaultClient(IVaultClientAuthenticator authenticator, IVaultSerializer serializer)
        {
            Authenticator = authenticator;
            Serializer = serializer;
            Endpoints = new VaultEndpoints(this);

            _httpClient = new HttpClient { BaseAddress = new Uri(Authenticator.Address) };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));          
        }

        public IVaultClientAuthenticator Authenticator { get; }

        public IVaultSerializer Serializer { get; }

        public IVaultEndpoints Endpoints { get; }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        public async Task<string> SendRequest(HttpMethod method, string address, IDictionary<string, string> headers = null, string body = null, CancellationToken? ct = null)
        {
            try
            {
                using (var r = await SendRequestProcessor(method, address, headers, body, ct))
                {
                    if (r.StatusCode != HttpStatusCode.NotFound && !r.IsSuccessStatusCode)
                    {
                        throw new VaultClientRequestException($"Unexpected response, status code {r.StatusCode}", r.StatusCode)
                        {
                            ResponseBody = await r.Content.ReadAsStringAsync()
                        };
                    }

                    return await r.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw new VaultClientRequestException(ex.Message, default(HttpStatusCode), ex);
            }
        }

        private Task<HttpResponseMessage> SendRequestProcessor(HttpMethod method, string address, IDictionary<string, string> headers, string body, CancellationToken? ct = null)
        {
            var requestMessage = new HttpRequestMessage(method, new Uri(_httpClient.BaseAddress, address));

            if (Authenticator.Token != null)
            {
                _httpClient.DefaultRequestHeaders.Add("X-Vault-Token", Authenticator.Token);
            }

            if (headers != null)
            {
                foreach (var item in headers.Keys)
                {
                    _httpClient.DefaultRequestHeaders.Add(item, headers[item]);
                }
            }

            if (body != null)
            {
                requestMessage.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }        

            return ct.HasValue
                ? _httpClient.SendAsync(requestMessage, ct.Value)
                : _httpClient.SendAsync(requestMessage);
        }
    }
}