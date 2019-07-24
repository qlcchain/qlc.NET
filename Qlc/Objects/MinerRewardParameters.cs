using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class MinerRewardParameters
    {
        [JsonProperty("coinbase")]
        public string Coinbase { get; set; }
        [JsonProperty("beneficial")]
        public string Beneficial { get; set; }
        [JsonProperty("startHeight")]
        public ulong StartHeight { get; set; }
        [JsonProperty("endHeight")]
        public ulong EndHeight { get; set; }
        [JsonProperty("rewardBlocks")]
        public ulong RewardBlocks { get; set; }
    }
}
