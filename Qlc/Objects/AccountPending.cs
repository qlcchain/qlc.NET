using Newtonsoft.Json;
using Qlc.Converters;
using System;

namespace Qlc.Objects
{
    public class AccountPending
    {
        /// <summary>
        /// Token name
        /// </summary>
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        /// <summary>
        /// Token type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        /// <summary>
        /// Sender account of transaction
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
        /// <summary>
        /// Amount of transaction
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
        /// <summary>
        /// Hash of send block
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }
        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
