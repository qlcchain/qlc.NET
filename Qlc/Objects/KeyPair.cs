using Newtonsoft.Json;

namespace Qlc.Objects
{
    public class KeyPair
    {
        [JsonProperty("privKey")]
        public string PrivateKey { get; set; }
        [JsonProperty("pubKey")]
        public string PublicKey { get; set; }
    }
}
