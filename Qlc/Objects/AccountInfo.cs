using Newtonsoft.Json;
using System.Collections.Generic;

namespace Qlc.Objects
{
    public class AccountInfo
    {
        /// <summary>
        /// The account address
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }
        /// <summary>
        /// Balance of main token of the account (default is QLC)
        /// </summary>
        [JsonProperty("coinBalance")]
        public string CoinBalance { get; set; }
        /// <summary>
        /// Vote
        /// </summary>
        [JsonProperty("vote")]
        public string Vote { get; set; }
        /// <summary>
        /// Network
        /// </summary>
        [JsonProperty("network")]
        public string Network { get; set; }
        /// <summary>
        /// Storage
        /// </summary>
        [JsonProperty("storage")]
        public string Storage { get; set; }
        /// <summary>
        /// Oracle
        /// </summary>
        [JsonProperty("oracle")]
        public string Oracle { get; set; }
        /// <summary>
        /// Representative address of the account
        /// </summary>
        [JsonProperty("representative")]
        public string Representative { get; set; }
        /// <summary>
        /// The account's tokens
        /// </summary>
        [JsonProperty("tokens")]
        public List<AccountToken> Tokens { get; set; }
    }
}
