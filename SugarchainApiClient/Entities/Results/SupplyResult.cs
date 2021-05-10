using System.Numerics;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public class SupplyResult
    {
        [JsonProperty("halvings")]
        public BigInteger Halving { get; protected set; }
        
        [JsonProperty("height")]
        public BigInteger Height { get; protected set; }
        
        [JsonProperty("supply")]
        public BigInteger Supply { get; protected set; }
    }
}