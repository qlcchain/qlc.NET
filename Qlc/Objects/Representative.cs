using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class Representative
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("vote")]
        public string Vote { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("storage")]
        public string Storage { get; set; }
        [JsonProperty("oracle")]
        public string Oracle { get; set; }
        [JsonProperty("total")]
        public string Total { get; set; }
    }
}
