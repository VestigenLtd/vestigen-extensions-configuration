using System;
using System.Net;

namespace Vestigen.Extensions.Configuration.Consul.Client
{
    public class ConsulClientRequestException : Exception
    {
        public ConsulClientRequestException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ConsulClientRequestException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
        public string ResponseBody { get; set; }
    }
}