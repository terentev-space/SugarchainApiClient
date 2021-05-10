using System.Numerics;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public class UnspentResult
    {
        [JsonProperty("height")]
        public BigInteger Height { get; protected set; }
        
        [JsonProperty("index")]
        public BigInteger Index { get; protected set; }

        [JsonProperty("script")]
        public string Script { get; protected set; }
        
        [JsonProperty("txid")]
        public string TxId { get; protected set; }
        
        [JsonProperty("value")]
        public BigInteger Value { get; protected set; }
        
        public decimal GetFractionalValue() => (decimal) this.Value / Result.Divider;
    }
}