using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class RewardDetails
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("txHeader")]
        public string TxHeader { get; set; }
        [JsonProperty("rxHeader")]
        public string RxHeader { get; set; }
        [JsonProperty("amount")]
        public ulong Amount { get; set; }
    }

}
