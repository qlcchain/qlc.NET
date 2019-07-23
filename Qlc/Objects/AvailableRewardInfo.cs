using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class AvailableRewardInfo
    {
        /// <summary>
        /// Available reward block end height for miner
        /// </summary>
        [JsonProperty("availEndHeight")]
        public ulong AvailableEndHeight { get; set; }
        /// <summary>
        /// Available reward block count for miner
        /// </summary>
        [JsonProperty("availRewardBlocks")]
        public ulong AvailableRewardBlock { get; set; }
        /// <summary>
        /// Available reward block start height for miner
        /// </summary>
        [JsonProperty("availStartHeight")]
        public ulong AvailableStartHeight { get; set; }
        /// <summary>
        /// Last reward beneficial address
        /// </summary>
        [JsonProperty("lastBeneficial")]
        public string LastBeneficial { get; set; }
        /// <summary>
        /// Last reward block end height
        /// </summary>
        [JsonProperty("lastEndHeight")]
        public ulong LastEndHeight { get; set; }
        /// <summary>
        /// Available reward block count for miner
        /// </summary>
        [JsonProperty("lastRewardBlocks")]
        public ulong LastRewardBlocks { get; set; }
        /// <summary>
        /// Available reward block start height for miner
        /// </summary>
        [JsonProperty("lastStartHeight")]
        public ulong LastStartHeight { get; set; }
        /// <summary>
        /// Latest block height on node
        /// </summary>
        [JsonProperty("latestBlockHeight")]
        public ulong LatestBlockHeight { get; set; }
        /// <summary>
        /// Need call reward contract for miner
        /// </summary>
        [JsonProperty("needCallReward")]
        public bool NeedCallReward { get; set; }
        /// <summary>
        /// Max reward block height on node
        /// </summary>
        [JsonProperty("nodeRewardHeight")]
        public ulong NodeRewardHeight { get; set; }
    }
}
