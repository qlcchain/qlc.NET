using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlc.Objects
{
    public class Token
    {
        [JsonProperty("tokenId")]
        public string TokenId { get; set; }
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        [JsonProperty("tokenSymbol")]
        public string TokenSymbol { get; set; }
        [JsonProperty("totalSupply")]
        public long TotalSupply { get; set; }
        [JsonProperty("decimals")]
        public int Decimals { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("pledgeAmount")]
        public long PledgeAmount { get; set; }
        [JsonProperty("withdrawTime")]
        public long WithdrawTime { get; set; }
    }
}
