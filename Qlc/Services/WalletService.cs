using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class WalletService : QlcService
    {
        public WalletService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return balance for each token of the wallet
        /// </summary>
        /// <param name="masterAddress">Master address of the wallet</param>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>Balance of each token in the wallet</returns>
        public QlcResponse<Dictionary<string, string>> GetBalances(string masterAddress, string passphrase) => this.GetBalancesAsync(masterAddress, passphrase).Result;
        /// <summary>
        /// Return balance for each token of the wallet
        /// </summary>
        /// <param name="masterAddress">Master address of the wallet</param>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>Balance of each token in the wallet</returns>
        public async Task<QlcResponse<Dictionary<string, string>>> GetBalancesAsync(string masterAddress, string passphrase)
        {
            var request = new QlcRequest
            {
                Method = "wallet_getBalances",
                Id = this.GetNextId(),
                Parameters = { masterAddress, passphrase },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, string>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns raw key (public key and private key) for a account
        /// </summary>
        /// <param name="accountAddress">Account address</param>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>Key pair</returns>
        public QlcResponse<KeyPair> GetRawKey(string accountAddress, string passphrase) => this.GetRawKeyAsync(accountAddress, passphrase).Result;
        /// <summary>
        /// Returns raw key (public key and private key) for a account
        /// </summary>
        /// <param name="accountAddress">Account address</param>
        /// <param name="passphrase">Passphrase</param>
        /// <returns>Key pair</returns>
        public async Task<QlcResponse<KeyPair>> GetRawKeyAsync(string accountAddress, string passphrase)
        {
            var request = new QlcRequest
            {
                Method = "wallet_getRawKey",
                Id = this.GetNextId(),
                Parameters = { accountAddress, passphrase },
            };

            return await this.netClient.GetResponseAsync<KeyPair>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Generate new seed
        /// </summary>
        /// <returns>seed</returns>
        public QlcResponse<string> GetNewSeed() => this.GetNewSeedAsync().Result;
        /// <summary>
        /// Generate new seed
        /// </summary>
        /// <returns>seed</returns>
        public async Task<QlcResponse<string>> GetNewSeedAsync()
        {
            var request = new QlcRequest
            {
                Method = "wallet_newSeed",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Create new wallet and Return the master address
        /// </summary>
        /// <param name="passphrase">The passphrase</param>
        /// <param name="seed">Hex string for seed, if not set, will create seed randomly</param>
        /// <returns>Master address of the wallet</returns>
        public QlcResponse<string> CreateNewWallet(string passphrase, string seed = null) => this.CreateNewWalletAsync(passphrase, seed).Result;
        /// <summary>
        /// Create new wallet and Return the master address
        /// </summary>
        /// <param name="passphrase">The passphrase</param>
        /// <param name="seed">Hex string for seed, if not set, will create seed randomly</param>
        /// <returns>Master address of the wallet</returns>
        public async Task<QlcResponse<string>> CreateNewWalletAsync(string passphrase, string seed = null)
        {
            var request = new QlcRequest
            {
                Method = "wallet_newWallet",
                Id = this.GetNextId(),
                Parameters = { passphrase, seed },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Change wallet password
        /// </summary>
        /// <param name="masterAddress">Master address of the wallet</param>
        /// <param name="oldPassphrase">Old passphrase</param>
        /// <param name="newPassphrase">New passphrase</param>
        /// <returns>null</returns>
        public QlcResponse<string> ChangePassword(string masterAddress, string oldPassphrase, string newPassphrase) => this.ChangePasswordAsync(masterAddress, oldPassphrase, newPassphrase).Result;
        /// <summary>
        /// Change wallet password
        /// </summary>
        /// <param name="masterAddress">Master address of the wallet</param>
        /// <param name="oldPassphrase">Old passphrase</param>
        /// <param name="newPassphrase">New passphrase</param>
        /// <returns>null</returns>
        public async Task<QlcResponse<string>> ChangePasswordAsync(string masterAddress, string oldPassphrase, string newPassphrase)
        {
            var request = new QlcRequest
            {
                Method = "wallet_changePassword",
                Id = this.GetNextId(),
                Parameters = { masterAddress, oldPassphrase, newPassphrase },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }
    }
}
