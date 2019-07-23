using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class BlockCount
    {
        /// <summary>
        /// Number of blocks, including smartcontract blocks
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
        /// <summary>
        /// Number of unchecked blocks
        /// </summary>
        [JsonProperty("unchecked")]
        public int Unchecked { get; set; }
    }
}
