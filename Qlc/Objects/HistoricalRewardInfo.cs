using Newtonsoft.Json;
using System.Collections.Generic;

namespace Qlc.Objects
{
    public class HistoricalRewardInfo
    {
        /// <summary>
        /// All reward balance by miner
        /// </summary>
        [JsonProperty("allRewardAmount")]
        public string AllRewardAmount { get; set; }
        /// <summary>
        /// All reward block by miner
        /// </summary>
        [JsonProperty("allRewardBlocks")]
        public ulong AllRewardBlocks { get; set; }
        /// <summary>
        /// First reward block height
        /// </summary>
        [JsonProperty("firstRewardHeight")]
        public ulong FirstRewardHeight { get; set; }
        /// <summary>
        /// Last reward block height
        /// </summary>
        [JsonProperty("lastRewardHeight")]
        public ulong LastRewardHeight { get; set; }
        /// <summary>
        /// Reward info list
        /// </summary>
        [JsonProperty("rewardInfos")]
        public List<MinerRewardInfo> MinerRewards { get; set; }
    }
}
