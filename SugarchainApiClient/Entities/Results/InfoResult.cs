using System.Numerics;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public class InfoResult
    {
        [JsonProperty("bestblockhash")]
        public string BestBlockHash { get; protected set; }
        
        [JsonProperty("blocks")]
        public BigInteger Blocks { get; protected set; }
        
        [JsonProperty("chain")]
        public string Chain { get; protected set; }
        
        [JsonProperty("chainwork")]
        public string ChainWork { get; protected set; }
        
        [JsonProperty("difficulty")]
        public decimal Difficulty { get; protected set; }
        
        [JsonProperty("headers")]
        public BigInteger Headers { get; protected set; }
        
        [JsonProperty("mediantime")]
        public BigInteger MedianTime { get; protected set; }
        
        [JsonProperty("nethash")]
        public BigInteger NetHash { get; protected set; }
        
        [JsonProperty("reward")]
        public BigInteger Reward { get; protected set; }
        
        [JsonProperty("supply")]
        public BigInteger Supply { get; protected set; }
    }
}