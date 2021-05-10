using Newtonsoft.Json;

namespace SugarchainApiClient.Entities
{
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; protected set; }
        
        [JsonProperty("message")]
        public string Message { get; protected set; }
        
        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}