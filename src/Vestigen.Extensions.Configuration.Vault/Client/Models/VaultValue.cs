using System.Collections.Generic;

namespace Vestigen.Extensions.Configuration.Vault.Client.Models
{
    public class VaultValue
    {
        public string Path { get; set; }

        public List<VaultValueItem> Values { get; set; }
    }
}
