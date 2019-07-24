using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlc.Objects
{
    public class ConnectedPeersInfo
    {
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("infos")]
        public Dictionary<string, string> Infos { get; set; }
    }
}
