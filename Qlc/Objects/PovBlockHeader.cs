using Newtonsoft.Json;
using Qlc.Converters;
using System;

namespace Qlc.Objects
{
    public class PovBlockHeader
    {
        /// <summary>
        /// Coin base
        /// </summary>
        [JsonProperty("coinbase")]
        public string Coinbase { get; set; }
        /// <summary>
        /// block hash
        /// </summary>
        [JsonProperty("hash")]
        public string Hash { get; set; }
        /// <summary>
        ///  block height
        /// </summary>
        [JsonProperty("height")]
        public ulong Height { get; set; }
        /// <summary>
        /// previous block hash
        /// </summary>
        [JsonProperty("previous")]
        public string Previous { get; set; }
        /// <summary>
        /// merkle root of all transactions
        /// </summary>
        [JsonProperty("merkleRoot")]
        public string MerkleRoot { get; set; }
        /// <summary>
        /// nonce number used for vote signature
        /// </summary>
        [JsonProperty("nonce")]
        public ulong Nonce { get; set; }
        /// <summary>
        /// signature of vote related fields
        /// </summary>
        [JsonProperty("voteSignature")]
        public string VoteSignature { get; set; }
        /// <summary>
        /// difficulty target
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }
        /// <summary>
        /// timestamp, now is unix time
        /// </summary>
        [JsonConverter(typeof(DateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// transaction number
        /// </summary>
        [JsonProperty("txNum")]
        public uint TransactionNumber { get; set; }
        /// <summary>
        /// state hash
        /// </summary>
        [JsonProperty("stateHash")]
        public string StateHash { get; set; }
        /// <summary>
        /// signature of whole block header
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; } 
    }
}
