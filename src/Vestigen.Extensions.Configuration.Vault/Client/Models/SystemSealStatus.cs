using System;
using Newtonsoft.Json;

namespace Vestigen.Extensions.Configuration.Vault.Client.Models
{
    /// <summary>
    /// Information about the Vault's current seal status
    /// </summary>
    /// <remarks>This call can be made unauthenticated</remarks>
    public class SystemSealStatus
    {
        [JsonProperty("sealed")]
        public bool IsSealed { get; set; }

        [JsonProperty("n")]
        public int KeyShares { get; set; }

        [JsonProperty("t")]
        public int KeyThreshold { get; set; }

        [JsonProperty("progress")]
        public int UnsealProgress { get; set; }

        [JsonProperty("nonce")]
        public string UnsealNonce { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// The server is in a sealed state if this value returns as Null
        /// </summary>
        [JsonProperty("cluster_name")]
        public string ClusterName { get; set; }

        /// <summary>
        /// The server is in a sealed state if this value returns as Null
        /// </summary>
        [JsonProperty("cluster_id")]
        public Guid ClusterId { get; set; }
    }
}