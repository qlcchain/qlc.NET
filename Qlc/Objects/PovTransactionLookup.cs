using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class PovTransactionLookup
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }
        [JsonProperty("blockHeight")]
        public uint BlockHeight { get; set; }
        [JsonProperty("txIndex")]
        public int TxIndex { get; set; }
    }
}
