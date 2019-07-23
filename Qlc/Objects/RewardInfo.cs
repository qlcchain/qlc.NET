using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class RewardInfo
    {
        [JsonProperty("beneficial")]
        public string Beneficial { get; set; }
        [JsonProperty("endHeight")]
        public ulong EndHeight { get; set; }
        [JsonProperty("rewardBlocks")]
        public ulong RewardBlocks { get; set; }
        [JsonProperty("startHeight")]
        public ulong StartHeight { get; set; }
    }
}
