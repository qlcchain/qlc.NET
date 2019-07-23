using Newtonsoft.Json;
using Qlc.Converters;
using System;

namespace Qlc.Objects
{
    public class Block
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("balance")]
        public string Balance { get; set; }
        [JsonProperty("vote")]
        public string Vote { get; set; }
        [JsonProperty("network")]
        public string Network { get; set; }
        [JsonProperty("storage")]
        public string Storage { get; set; }
        [JsonProperty("oracle")]
        public string Oracle { get; set; }
        [JsonProperty("previous")]
        public string Previous { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("povHeight")]
        public int PovHeight { get; set; }
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        [JsonProperty("extra")]
        public string Extra { get; set; }
        [JsonProperty("representative")]
        public string Representative { get; set; }
        [JsonProperty("work")]
        public string Work { get; set; }
        [JsonProperty("signature")]
        public string Signature { get; set; }
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
