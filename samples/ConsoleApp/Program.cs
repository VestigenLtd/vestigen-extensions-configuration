using System;
using Microsoft.Extensions.Configuration;
using Vestigen.Extensions.Configuration.Consul;
using Vestigen.Extensions.Configuration.Vault;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("configuration.json");
            builder.AddJsonFile("environment.json");
            builder.AddCommandLine(new[]
            {
                "ConsulServer",
                "ConsulToken",
                "VaultServer",
                "VaultToken"
            });

            // TODO: Show how to incorporate different authenticators with each service
            builder.AddHashicorpConsul("127.0.0.1");
            builder.AddHashicorpVault("127.0.0.1");

            var config = builder.Build();
        }
    }
}