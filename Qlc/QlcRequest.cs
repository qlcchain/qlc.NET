using Newtonsoft.Json;
using System.Collections.Generic;

namespace Qlc
{
    public class QlcRequest
    {
        public QlcRequest()
        {
            this.Parameters = new List<object>();
        }

        [JsonProperty("jsonrpc")]
        public string JsonRpc => "2.0";
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("params")]
        public List<object> Parameters { get; set; }
    }
}
