using System.Numerics;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public class BalanceResult : Result
    {
        [JsonProperty("balance")]
        public BigInteger Balance { get; protected set; }
        
        [JsonProperty("received")]
        public BigInteger Received { get; protected set; }
        
        public decimal GetFractionalBalance() => (decimal) this.Balance / Result.Divider;
        
        public decimal GetFractionalReceived() => (decimal) this.Received / Result.Divider;
    }
}