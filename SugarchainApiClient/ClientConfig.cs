using System.Collections.Generic;
using SugarchainApiClient.Interfaces;

namespace SugarchainApiClient
{
    public class ClientConfig : IClientConfig
    {
        public readonly List<string> Hosts = new List<string>()
        {
            "https://api.sugarchain.org",
        };

        public IEnumerable<string> GetHosts() => this.Hosts;
    }
}