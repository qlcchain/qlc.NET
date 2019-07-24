using Qlc.Net;
using System;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class UtilityService : QlcService
    {
        public UtilityService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Decrypts and encrypted string by passphrase
        /// </summary>
        /// <param name="toDecrypt">Base64 encoded ciphertext</param>
        /// <param name="passphrase">The passphrase</param>
        /// <returns>Decrypted data</returns>
        public QlcResponse<string> Decrypt(string toDecrypt, string passphrase) => this.DecryptAsync(toDecrypt, passphrase).Result;
        /// <summary>
        /// Decrypts and encrypted string by passphrase
        /// </summary>
        /// <param name="toDecrypt">Base64 encoded ciphertext</param>
        /// <param name="passphrase">The passphrase</param>
        /// <returns>Decrypted data</returns>
        public async Task<QlcResponse<string>> DecryptAsync(string toDecrypt, string passphrase)
        {
            var request = new QlcRequest
            {
                Method = "util_decrypt",
                Id = this.GetNextId(),
                Parameters = { toDecrypt, passphrase },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Encrypt raw data by passphrase
        /// </summary>
        /// <param name="toEncrypt">Raw data, must be a hex string</param>
        /// <param name="passphrase">The passphrase</param>
        /// <returns>Base64 encoded ciphertext</returns>
        public QlcResponse<string> Encrypt(string toEncrypt, string passphrase) => this.EncryptAsync(toEncrypt, passphrase).Result;
        /// <summary>
        /// Encrypt raw data by passphrase
        /// </summary>
        /// <param name="toEncrypt">Raw data, must be a hex string</param>
        /// <param name="passphrase">The passphrase</param>
        /// <returns>Base64 encoded ciphertext</returns>
        public async Task<QlcResponse<string>> EncryptAsync(string toEncrypt, string passphrase)
        {
            var request = new QlcRequest
            {
                Method = "util_encrypt",
                Id = this.GetNextId(),
                Parameters = { toEncrypt, passphrase },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Translates a raw amount value for QLC to a human readable value, using the unit
        /// </summary>
        /// <param name="rawValue">The raw value</param>
        /// <param name="unit">The unit</param>
        /// <returns>Human readable balance</returns>
        public QlcResponse<string> RawToBalanceQlc(string rawValue, string unit = "QLC") => this.RawToBalanceQlcAsync(rawValue, unit).Result;
        /// <summary>
        /// Translates a raw amount value for QLC to a human readable value, using the unit
        /// </summary>
        /// <param name="rawValue">The raw value</param>
        /// <param name="unit">The unit</param>
        /// <returns>Human readable balance</returns>
        public async Task<QlcResponse<string>> RawToBalanceQlcAsync(string rawValue, string unit = "QLC")
        {
            var request = new QlcRequest
            {
                Method = "util_rawToBalance",
                Id = this.GetNextId(),
                Parameters = { rawValue, unit },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Translates a raw amount value for a non-QLC token to a human readable value
        /// </summary>
        /// <param name="rawValue">The raw value</param>
        /// <param name="tokenName">Token symbol</param>
        /// <returns>Human readable balance</returns>
        public QlcResponse<string> RawToBalanceToken(string rawValue, string tokenName) => this.RawToBalanceTokenAsync(rawValue, tokenName).Result;
        /// <summary>
        /// Translates a raw amount value for a non-QLC token to a human readable value
        /// </summary>
        /// <param name="rawValue">The raw value</param>
        /// <param name="tokenName">Token symbol</param>
        /// <returns>Human readable balance</returns>
        public async Task<QlcResponse<string>> RawToBalanceTokenAsync(string rawValue, string tokenName)
        {
            if (tokenName.ToLowerInvariant() == "qlc") throw new ArgumentException("Please use RawToBalanceQlc for QLC");

            var request = new QlcRequest
            {
                Method = "util_rawToBalance",
                Id = this.GetNextId(),
                Parameters = { rawValue, "", tokenName },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Translates a human readable value to a raw amount value for QLC, using the unit
        /// </summary>
        /// <param name="balance">The balance</param>
        /// <param name="unit">The unit</param>
        /// <returns>Raw value</returns>
        public QlcResponse<string> BalanceToRawQlc(string balance, string unit = "QLC") => this.BalanceToRawQlcAsync(balance, unit).Result;
        /// <summary>
        /// Translates a human readable value to a raw amount value for QLC, using the unit
        /// </summary>
        /// <param name="balance">The balance</param>
        /// <param name="unit">The unit</param>
        /// <returns>Raw value</returns>
        public async Task<QlcResponse<string>> BalanceToRawQlcAsync(string balance, string unit = "QLC")
        {
            var request = new QlcRequest
            {
                Method = "util_balanceToRaw",
                Id = this.GetNextId(),
                Parameters = { balance, unit },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Translates a human readable value to a raw amount value for a non-QLC token
        /// </summary>
        /// <param name="balance">The balance</param>
        /// <param name="tokenName">Token symbol</param>
        /// <returns>Raw value</returns>
        public QlcResponse<string> BalanceToRawToken(string balance, string tokenName) => this.BalanceToRawTokenAsync(balance, tokenName).Result;
        /// <summary>
        /// Translates a human readable value to a raw amount value for a non-QLC token
        /// </summary>
        /// <param name="balance">The balance</param>
        /// <param name="tokenName">Token symbol</param>
        /// <returns>Raw value</returns>
        public async Task<QlcResponse<string>> BalanceToRawTokenAsync(string balance, string tokenName)
        {
            if (tokenName.ToLowerInvariant() == "qlc") throw new ArgumentException("Please use BalanceToRawQlc for QLC");

            var request = new QlcRequest
            {
                Method = "util_balanceToRaw",
                Id = this.GetNextId(),
                Parameters = { balance, "", tokenName },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }
    }
}
