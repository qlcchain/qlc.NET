using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class PovTransaction
    {
        [JsonProperty("transaction")]
        public Block Block { get; set; }
        [JsonProperty("txHash")]
        public string TxHash { get; set; }
        [JsonProperty("txLookup")]
        public PovTransactionLookup TxLookup { get; set; }
    }
}
