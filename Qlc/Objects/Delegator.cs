using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class Delegator
    {
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
    }
}
