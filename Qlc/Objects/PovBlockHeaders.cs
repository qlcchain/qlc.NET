using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlc.Objects
{
    public class PovBlockHeaders
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("headers")]
        public List<PovBlockHeader> Headers { get; set; }
    }
}
