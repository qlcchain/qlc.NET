using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class Account : KeyPair
    {
        [JsonProperty("seed")]
        public string Seed { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
