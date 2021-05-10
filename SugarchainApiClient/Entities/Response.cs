using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace SugarchainApiClient.Entities
{
    public class Response<T>
    {
        [JsonProperty("error")]
        [AllowNull]
        public Error Error { get; protected set; } = null;
        
        [JsonProperty("id")]
        public string Id { get; protected set; }
        
        [JsonProperty("result")]
        [AllowNull]
        public T Result { get; protected set; }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}