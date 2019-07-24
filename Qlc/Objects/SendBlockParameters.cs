using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlc.Objects
{
    public class SendBlockParameters
    {
        /// <summary>
        /// Send address for the transaction
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }
        /// <summary>
        /// receive address for the transaction
        /// </summary>
        [JsonProperty("to")]
        public string To { get; set; }
        /// <summary>
        /// Token name
        /// </summary>
        [JsonProperty("tokenName")]
        public string TokenName { get; set; }
        /// <summary>
        /// Transaction amount
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }
        /// <summary>
        /// Sms sender - optional
        /// </summary>
        [JsonProperty("sender")]
        public string Sender { get; set; }
        /// <summary>
        /// Sms receiver - optional
        /// </summary>
        [JsonProperty("receiver")]
        public string Receiver { get; set; }
        /// <summary>
        /// Sms message hash - optional
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
