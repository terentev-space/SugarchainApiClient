using System.Numerics;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public class FeeResult
    {
        [JsonProperty("blocks")]
        public BigInteger Blocks { get; protected set; }
        
        [JsonProperty("feerate")]
        public BigInteger FeeRate { get; protected set; }
    }
}