using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class AccountBalance
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("pending")]
        public string Pending { get; set; }
        [JsonProperty("vote")]
        public string Vote { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("storage")]
        public string Storage { get; set; }
        [JsonProperty("oracle")]
        public string Oracle { get; set; }
    }
}
