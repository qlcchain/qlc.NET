using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class PledgeParameters
    {
        /// <summary>
        /// Beneficial address
        /// </summary>
        [JsonProperty("beneficial")]
        public string Beneficial { get; set; }
        /// <summary>
        /// Pledge address
        /// </summary>
        [JsonProperty("pledgeAddress")]
        public string PledgeAddress { get; set; }
        /// <summary>
        /// Amount of pledge
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
        /// <summary>
        /// Type of pledge
        /// </summary>
        [JsonProperty("pType")]
        public string PledgeType { get; set; }
        /// <summary>
        /// Lock transaction id of nep5
        /// </summary>
        [JsonProperty("nEP5TxId")]
        public string Nep5TxId { get; set; }
    }
}
