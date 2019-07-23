using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class MintageParameters
    {
        [JsonProperty("selfAddr")]
        public string SelfAddress { get; set; }
        [JsonProperty("prevHash")]
        public string PreviousHash { get; set; }
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        [JsonProperty("tokenSymbol")]
        public string TokenSymbol { get; set; }
        [JsonProperty("totalSupply")]
        public string TotalSupply { get; set; }
        [JsonProperty("decimals")]
        public int Decimals { get; set; }
        [JsonProperty("pledgeAmount")]
        public long PledgeAmount { get; set; }
    }
}
