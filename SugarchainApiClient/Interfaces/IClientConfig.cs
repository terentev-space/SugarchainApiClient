using System.Collections.Generic;

namespace SugarchainApiClient.Interfaces
{
    public interface IClientConfig
    {
        public IEnumerable<string> GetHosts();
    }
}