using Newtonsoft.Json;
using Qlc.Converters;
using System;

namespace Qlc.Objects
{
    public class AccountToken
    {
        /// <summary>
        /// Token hash
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// The latest block hash for the token chain
        /// </summary>
        [JsonProperty("header")]
        public string Header { get; set; }
        /// <summary>
        /// Representative address
        /// </summary>
        [JsonProperty("representative")]
        public string Representative { get; set; }
        /// <summary>
        /// The open block hash for the token chain
        /// </summary>
        [JsonProperty("open")]
        public string Open { get; set; }
        /// <summary>
        /// Balance for the token
        /// </summary>
        [JsonProperty("balance")]
        public string Balance { get; set; }
        /// <summary>
        /// Account that token belong to
        /// </summary>
        [JsonProperty("account")]
        public string Account { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonProperty("modified")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime Modified { get; set; }
        /// <summary>
        /// Total block number for the token chain
        /// </summary>
        [JsonProperty("blockCount")]
        public int BlockCount { get; set; }
        /// <summary>
        /// Token name
        /// </summary>
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        /// <summary>
        /// Pending amount
        /// </summary>
        [JsonProperty("pending")]
        public string Pending { get; set; }

    }
}
