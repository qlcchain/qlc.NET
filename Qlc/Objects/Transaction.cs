using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class Transaction
    {
        [JsonProperty("transaction")]
        public Block Block { get; set; }
        [JsonProperty("txHash")]
        public string TxHash { get; set; }
        [JsonProperty("txLookup")]
        public TransactionLookup TxLookup { get; set; }
    }
}
