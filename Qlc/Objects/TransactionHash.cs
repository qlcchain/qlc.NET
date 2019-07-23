using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class TransactionHash
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
