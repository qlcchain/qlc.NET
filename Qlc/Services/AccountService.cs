using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class AccountService : QlcService
    {
        public AccountService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Create a new account by seed and index
        /// </summary>
        /// <param name="seed">seed</param>
        /// <param name="index">Index for account, if not set, default value is 0</param>
        /// <returns>Key pair</returns>
        public QlcResponse<KeyPair> Create(string seed, int index = 0) => this.CreateAsync(seed, index).Result;
        public async Task<QlcResponse<KeyPair>> CreateAsync(string seed, int index = 0)
        {
            var request = new QlcRequest
            {
                Method = "account_create",
                Id = this.GetNextId(),
                Parameters = { seed, index },
            };

            return await this.netClient.GetResponseAsync<KeyPair>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a new seed randomly
        /// </summary>
        /// <returns>seed</returns>
        public QlcResponse<string> GetNewSeed() => this.GetNewSeedAsync().Result;
        /// <summary>
        /// Create a new seed randomly
        /// </summary>
        /// <returns>seed</returns>
        public async Task<QlcResponse<string>> GetNewSeedAsync()
        {
            var request = new QlcRequest
            {
                Method = "account_newSeed",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Create new accounts randomly
        /// </summary>
        /// <param name="howMany">number of accounts, default is 10</param>
        /// <returns>Account</returns>
        public QlcResponse<List<Account>> CreateAccounts(int howMany = 10) => this.CreateAccountsAsync(howMany).Result;
        /// <summary>
        /// Create new accounts randomly
        /// </summary>
        /// <param name="howMany">number of accounts, default is 10</param>
        /// <returns>Account</returns>
        public async Task<QlcResponse<List<Account>>> CreateAccountsAsync(int howMany = 10)
        {
            var request = new QlcRequest
            {
                Method = "account_newAccounts",
                Id = this.GetNextId(),
                Parameters = { howMany },
            };

            return await this.netClient.GetResponseAsync<List<Account>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return account address by public key
        /// </summary>
        /// <param name="publicKey">The public key</param>
        /// <returns>Account address</returns>
        public QlcResponse<string> GetAddressForPublicKey(string publicKey) => this.GetAddressForPublicKeyAsync(publicKey).Result;
        /// <summary>
        /// Return account address by public key
        /// </summary>
        /// <param name="publicKey">The public key</param>
        /// <returns>Account address</returns>
        public async Task<QlcResponse<string>> GetAddressForPublicKeyAsync(string publicKey)
        {
            var request = new QlcRequest
            {
                Method = "account_forPublicKey",
                Id = this.GetNextId(),
                Parameters = { publicKey },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return public key for account address
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>Public key</returns>
        public QlcResponse<string> GetPublicKeyForAddress(string address) => this.GetPublicKeyForAddressAsync(address).Result;
        /// <summary>
        /// Return public key for account address
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>Public key</returns>
        public async Task<QlcResponse<string>> GetPublicKeyForAddressAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "account_publicKey",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns whether the address is valid or not
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>True if valid, false otherwise</returns>
        public QlcResponse<bool> ValidateAddress(string address) => this.ValidateAddressAsync(address).Result;
        /// <summary>
        /// Returns whether the address is valid or not
        /// </summary>
        /// <param name="address">The address</param>
        /// <returns>True if valid, false otherwise</returns>
        public async Task<QlcResponse<bool>> ValidateAddressAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "account_validate",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<bool>(request).ConfigureAwait(false);
        }
    }
}
