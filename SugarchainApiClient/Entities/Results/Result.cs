using Newtonsoft.Json;

namespace SugarchainApiClient.Entities.Results
{
    public abstract class Result
    {
        public const decimal Divider = 100000000m;
        
        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}