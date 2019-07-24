using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class PovTransactionHash
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
