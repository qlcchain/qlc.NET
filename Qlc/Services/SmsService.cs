using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class SmsService : QlcService
    {
        public SmsService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return blocks which the sender or receiver of block is the phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        /// <returns>Blocks associated with the phone number</returns>
        public QlcResponse<List<Block>> GetPhoneBlocks(string phoneNumber) => this.GetPhoneBlocksAsync(phoneNumber).Result;
        /// <summary>
        /// Return blocks which the sender or receiver of block is the phone number
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        /// <returns>Blocks associated with the phone number</returns>
        public async Task<QlcResponse<List<Block>>> GetPhoneBlocksAsync(string phoneNumber)
        {
            var request = new QlcRequest
            {
                Method = "sms_phoneBlocks",
                Id = this.GetNextId(),
                Parameters = { phoneNumber },
            };

            return await this.netClient.GetResponseAsync<List<Block>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return blocks where message field is equal to the message hash
        /// </summary>
        /// <param name="messageHash">Message hash</param>
        /// <returns>Blocks associated with the message hash</returns>
        public QlcResponse<List<Block>> GetMessageBlocks(string messageHash) => this.GetMessageBlocksAsync(messageHash).Result;
        /// <summary>
        /// Return blocks where message field is equal to the message hash
        /// </summary>
        /// <param name="messageHash">Message hash</param>
        /// <returns>Blocks associated with the message hash</returns>
        public async Task<QlcResponse<List<Block>>> GetMessageBlocksAsync(string messageHash)
        {
            var request = new QlcRequest
            {
                Method = "sms_messageBlocks",
                Id = this.GetNextId(),
                Parameters = { messageHash },
            };

            return await this.netClient.GetResponseAsync<List<Block>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return hash for message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>Hash of the message</returns>
        public QlcResponse<string> GetMessageHash(string message) => this.GetMessageHashAsync(message).Result;
        /// <summary>
        /// Return hash for message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>Hash of the message</returns>
        public async Task<QlcResponse<string>> GetMessageHashAsync(string message)
        {
            var request = new QlcRequest
            {
                Method = "sms_messageHash",
                Id = this.GetNextId(),
                Parameters = { message },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Store message and return message hash
        /// </summary>
        /// <param name="message">The message to store</param>
        /// <returns>Hash of the message</returns>
        public QlcResponse<string> StoreMessage(string message) => this.StoreMessageAsync(message).Result;
        public async Task<QlcResponse<string>> StoreMessageAsync(string message)
        {
            var request = new QlcRequest
            {
                Method = "sms_messageStore",
                Id = this.GetNextId(),
                Parameters = { message },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }
    }
}
