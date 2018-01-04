using System;
using System.Net;

namespace Vestigen.Extensions.Configuration.Vault.Client
{
    public class VaultClientRequestException : Exception
    {
        public VaultClientRequestException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public VaultClientRequestException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
        public string ResponseBody { get; set; }
    }
}