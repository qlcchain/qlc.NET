using Newtonsoft.Json;
using System.Collections.Generic;

namespace Qlc.Objects
{
    public class PovBlock : PovBlockHeader
    {
        [JsonProperty("transactions")]
        public List<TransactionHash> Transactions { get; set; }
    }
}
