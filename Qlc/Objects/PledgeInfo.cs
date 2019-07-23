using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class PledgeInfo
    {
        [JsonProperty("PType")]
        public string PledgeType { get; set; }
        public long Amount { get; set; }
        public string WithdrawTime { get; set; }
        public string Beneficial { get; set; }
        public string PledgeAddress { get; set; }
        [JsonProperty("NEP5TxId")]
        public string Nep5TxId { get; set; }
    }
}
