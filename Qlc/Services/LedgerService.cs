using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class LedgerService : QlcService
    {
        public LedgerService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return account detail info, include each token in the account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>The account info</returns>
        public QlcResponse<AccountInfo> GetAccountInfo(string address) => this.GetAccountInfoAsync(address).Result;
        /// <summary>
        /// Return account detail info, include each token in the account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>The account info</returns>
        public async Task<QlcResponse<AccountInfo>> GetAccountInfoAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountInfo",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<AccountInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return number of blocks for a specific account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>Blocks number for the account</returns>
        public QlcResponse<int> GetAccountBlocksCount(string address) => this.GetAccountBlocksCountAsync(address).Result;
        public async Task<QlcResponse<int>> GetAccountBlocksCountAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountBlocksCount",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<int>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return blocks for the account, include each token of the account and order of blocks is forward from the last one
        /// </summary>
        /// <param name="address">The account address</param>
        /// <param name="blocks">Number of blocks to return</param>
        /// <param name="index">Offset, index of block where to start, default is 0</param>
        /// <returns>Blocks</returns>
        public QlcResponse<Block[]> GetAccountHistory(string address, int blocks, int index = 0) => this.GetAccountHistoryAsync(address, blocks, index).Result;
        /// <summary>
        /// Return blocks for the account, include each token of the account and order of blocks is forward from the last one
        /// </summary>
        /// <param name="address">The account address</param>
        /// <param name="howMany">Number of blocks to return</param>
        /// <param name="index">Offset, index of block where to start, default is 0</param>
        /// <returns>Blocks</returns>
        public async Task<QlcResponse<Block[]>> GetAccountHistoryAsync(string address, int howMany, int index = 0)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountHistoryTopn",
                Id = this.GetNextId(),
                Parameters = { address, howMany, index },
            };

            return await this.netClient.GetResponseAsync<Block[]>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the representative address for account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>representative address for the account (if account not found, return error)</returns>
        public QlcResponse<string> GetAccountRepresentative(string address) => this.GetAccountRepresentativeAsync(address).Result;
        /// <summary>
        /// Return the representative address for account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>representative address for the account (if account not found, return error)</returns>
        public async Task<QlcResponse<string>> GetAccountRepresentativeAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountRepresentative",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the vote weight for account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>The vote weight for the account (if account is not found, returns an error)</returns>
        public QlcResponse<string> GetAccountVotingWeight(string address) => this.GetAccountVotingWeightAsync(address).Result;
        /// <summary>
        /// Return the vote weight for account
        /// </summary>
        /// <param name="address">The account address</param>
        /// <returns>The vote weight for the account (if account is not found, returns an error)</returns>
        public async Task<QlcResponse<string>> GetAccountVotingWeightAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountVotingWeight",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return account list of chain
        /// </summary>
        /// <param name="accounts">Number of accounts to return</param>
        /// <param name="offset">Offset, index of account where to start, default is 0</param>
        /// <returns>List of accounts</returns>
        public QlcResponse<string[]> GetAccounts(int accounts, int offset = 0) => this.GetAccountsAsync(accounts, offset).Result;
        /// <summary>
        /// Return account list of chain
        /// </summary>
        /// <param name="howMany">Number of accounts to return</param>
        /// <param name="offset">Offset, index of account where to start, default is 0</param>
        /// <returns>List of accounts</returns>
        public async Task<QlcResponse<string[]>> GetAccountsAsync(int howMany, int offset = 0)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accounts",
                Id = this.GetNextId(),
                Parameters = { howMany, offset },
            };

            return await this.netClient.GetResponseAsync<string[]>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns balance and pending (amount that has not yet been received) for each account, if token is QLC, alse have benefit amount as vote, network, oracle, storage
        /// </summary>
        /// <param name="addresses">Address list</param>
        /// <returns>Balances for each token</returns>
        public QlcResponse<Dictionary<string, Dictionary<string, AccountBalance>>> GetAccountBalances(params string[] addresses) => this.GetAccountBalancesAsync(addresses).Result;
        /// <summary>
        /// Returns balance and pending (amount that has not yet been received) for each account, if token is QLC, alse have benefit amount as vote, network, oracle, storage
        /// </summary>
        /// <param name="addresses">Address list</param>
        /// <returns>Balances for each token</returns>
        public async Task<QlcResponse<Dictionary<string, Dictionary<string, AccountBalance>>>> GetAccountBalancesAsync(params string[] addresses)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountsBalance",
                Id = this.GetNextId(),
                Parameters = { addresses },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, Dictionary<string, AccountBalance>>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pairs of token name and block hash (representing the head block ) of each token for each account
        /// </summary>
        /// <param name="addresses">Address list</param>
        /// <returns>Token name and block hash for each account</returns>
        public QlcResponse<Dictionary<string, Dictionary<string, string>>> GetAccountFrontiers(params string[] addresses) => this.GetAccountFrontiersAsync(addresses).Result;
        /// <summary>
        /// Return pairs of token name and block hash (representing the head block ) of each token for each account
        /// </summary>
        /// <param name="addresses">Address list</param>
        /// <returns>Token name and block hash for each account</returns>
        public async Task<QlcResponse<Dictionary<string, Dictionary<string, string>>>> GetAccountFrontiersAsync(params string[] addresses)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountsFrontiers",
                Id = this.GetNextId(),
                Parameters = { addresses },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, Dictionary<string, string>>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pending info for accounts
        /// </summary>
        /// <param name="howMany">get the maximum number of pending for each account, if set to -1, return all pending (the default)</param>
        /// <param name="addresses">Address list</param>
        /// <returns>Pending info for each token of each account</returns>
        public QlcResponse<Dictionary<string, List<AccountPending>>> GetAccountsPending(int howMany = -1, params string[] addresses) => this.GetAccountsPendingAsync(howMany, addresses).Result;
        /// <summary>
        /// Return pending info for accounts
        /// </summary>
        /// <param name="howMany">get the maximum number of pending for each account, if set to -1, return all pending (the default)</param>
        /// <param name="addresses">Address list</param>
        /// <returns>Pending info for each token of each account</returns>
        public async Task<QlcResponse<Dictionary<string, List<AccountPending>>>> GetAccountsPendingAsync(int howMany = -1, params string[] addresses)
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountsPending",
                Id = this.GetNextId(),
                Parameters = { addresses, howMany },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, List<AccountPending>>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return total number of accounts of chain
        /// </summary>
        /// <returns>total number of accounts</returns>
        public QlcResponse<int> GetAccountsCount() => this.GetAccountsCountAsync().Result;
        /// <summary>
        /// Return total number of accounts of chain
        /// </summary>
        /// <returns>total number of accounts</returns>
        public async Task<QlcResponse<int>> GetAccountsCountAsync()
        {
            var request = new QlcRequest
            {
                Method = "ledger_accountsCount",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<int>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the account that the block belong to
        /// </summary>
        /// <param name="blockHash">block hash</param>
        /// <returns>the account address (if block not found, return error)</returns>
        public QlcResponse<string> GetBlockAccount(string blockHash) => this.GetBlockAccountAsync(blockHash).Result;
        /// <summary>
        /// Return the account that the block belong to
        /// </summary>
        /// <param name="blockHash">block hash</param>
        /// <returns>the account address (if block not found, return error)</returns>
        public async Task<QlcResponse<string>> GetBlockAccountAsync(string blockHash)
        {
            var request = new QlcRequest
            {
                Method = "ledger_blockAccount",
                Id = this.GetNextId(),
                Parameters = { blockHash },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return hash for the block
        /// </summary>
        /// <param name="block">Block info</param>
        /// <returns>Block hash</returns>
        public QlcResponse<string> GetBlockHash(Block block) => this.GetBlockHashAsync(block).Result;
        /// <summary>
        /// Return hash for the block
        /// </summary>
        /// <param name="block">Block info</param>
        /// <returns>Block hash</returns>
        public async Task<QlcResponse<string>> GetBlockHashAsync(Block block)
        {
            var request = new QlcRequest
            {
                Method = "ledger_blockHash",
                Id = this.GetNextId(),
                Parameters = { block },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return blocks list of chain
        /// </summary>
        /// <param name="howMany">number of blocks to return</param>
        /// <param name="offset">Offset, index of block where to start, default is 0</param>
        /// <returns>Blocks list</returns>
        public QlcResponse<List<Block>> GetBlocks(int howMany, int offset = 0) => this.GetBlocksAsync(howMany, offset).Result;
        /// <summary>
        /// Return blocks list of chain
        /// </summary>
        /// <param name="howMany">number of blocks to return</param>
        /// <param name="offset">Offset, index of block where to start, default is 0</param>
        /// <returns>Blocks list</returns>
        public async Task<QlcResponse<List<Block>>> GetBlocksAsync(int howMany, int offset = 0)
        {
            var request = new QlcRequest
            {
                Method = "ledger_blocks",
                Id = this.GetNextId(),
                Parameters = { howMany, offset },
            };

            return await this.netClient.GetResponseAsync<List<Block>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the number of blocks (include smartcontract blocks) and unchecked blocks of chain
        /// </summary>
        /// <returns>Count</returns>
        public QlcResponse<BlockCount> GetBlockCount() => this.GetBlockCountAsync().Result;
        /// <summary>
        /// Return the number of blocks (include smartcontract blocks) and unchecked blocks of chain
        /// </summary>
        /// <returns>Count</returns>
        public async Task<QlcResponse<BlockCount>> GetBlockCountAsync()
        {
            var request = new QlcRequest
            {
                Method = "ledger_blocksCount",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<BlockCount>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Report number of blocks by type of chain
        /// </summary>
        /// <returns></returns>
        public QlcResponse<BlockCountByType> GetBlockCountByType() => this.GetBlockCountByTypeAsync().Result;
        /// <summary>
        /// Report number of blocks by type of chain
        /// </summary>
        /// <returns></returns>
        public async Task<QlcResponse<BlockCountByType>> GetBlockCountByTypeAsync()
        {
            var request = new QlcRequest
            {
                Method = "ledger_blocksCountByType",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<BlockCountByType>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return blocks info for blocks hash
        /// </summary>
        /// <param name="blockHashes">Block hashes</param>
        /// <returns>Blocks</returns>
        public QlcResponse<List<Block>> GetBlocksInfo(params string[] blockHashes) => this.GetBlocksInfoAsync(blockHashes).Result;
        /// <summary>
        /// Return blocks info for blocks hash
        /// </summary>
        /// <param name="blockHashes">Block hashes</param>
        /// <returns>Blocks</returns>
        public async Task<QlcResponse<List<Block>>> GetBlocksInfoAsync(params string[] blockHashes)
        {
            var request = new QlcRequest
            {
                Method = "ledger_blocksInfo",
                Id = this.GetNextId(),
                Parameters = { blockHashes },
            };

            return await this.netClient.GetResponseAsync<List<Block>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Accept a specific block hash and return a consecutive blocks hash list, starting with this block, and traverse forward to the maximum number
        /// </summary>
        /// <param name="startBlockHash">block hash to start at</param>
        /// <param name="howMany">Number of block hashed to retrieve. -1 returns them all (the default)</param>
        /// <returns>List of block hashes</returns>
        public QlcResponse<List<string>> GetChain(string startBlockHash, int howMany = -1) => this.GetChainAsync(startBlockHash, howMany).Result;
        /// <summary>
        /// Accept a specific block hash and return a consecutive blocks hash list, starting with this block, and traverse forward to the maximum number
        /// </summary>
        /// <param name="startBlockHash">block hash to start at</param>
        /// <param name="howMany">Number of block hashed to retrieve. -1 returns them all (the default)</param>
        /// <returns>List of block hashes</returns>
        public async Task<QlcResponse<List<string>>> GetChainAsync(string startBlockHash, int howMany = -1)
        {
            var request = new QlcRequest
            {
                Method = "ledger_chain",
                Id = this.GetNextId(),
                Parameters = { startBlockHash, howMany },
            };

            return await this.netClient.GetResponseAsync<List<string>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return a list of pairs of delegator and it's balance for a specific representative account
        /// </summary>
        /// <param name="address">representative account address</param>
        /// <returns></returns>
        public QlcResponse<List<Delegator>> GetDelegators(string address) => this.GetDelegatorsAsync(address).Result;
        /// <summary>
        /// Return a list of pairs of delegator and it's balance for a specific representative account
        /// </summary>
        /// <param name="address">representative account address</param>
        /// <returns></returns>
        public async Task<QlcResponse<List<Delegator>>> GetDelegatorsAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_delegators",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<List<Delegator>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return number of delegators for a specific representative account
        /// </summary>
        /// <param name="address">representative account address</param>
        /// <returns>Number of delegators for the account</returns>
        public QlcResponse<int> GetDelegatorCount(string address) => this.GetDelegatorCountAsync(address).Result;
        /// <summary>
        /// Return number of delegators for a specific representative account
        /// </summary>
        /// <param name="address">representative account address</param>
        /// <returns>Number of delegators for the account</returns>
        public async Task<QlcResponse<int>> GetDelegatorCountAsync(string address)
        {
            var request = new QlcRequest
            {
                Method = "ledger_delegatorsCount",
                Id = this.GetNextId(),
                Parameters = { address },
            };

            return await this.netClient.GetResponseAsync<int>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return send block by send parameter and private key
        /// </summary>
        /// <param name="sendBlockParameters">Parameters</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Send block</returns>
        public QlcResponse<Block> GenerateSendBlock(SendBlockParameters sendBlockParameters, string privateKey = null) => this.GenerateSendBlockAsync(sendBlockParameters, privateKey).Result;
        /// <summary>
        /// Return send block by send parameter and private key
        /// </summary>
        /// <param name="sendBlockParameters">Parameters</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Send block</returns>
        public async Task<QlcResponse<Block>> GenerateSendBlockAsync(SendBlockParameters sendBlockParameters, string privateKey = null)
        {
            var request = new QlcRequest
            {
                Method = "ledger_generateSendBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlockParameters, privateKey },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return receive block by send block and private key
        /// </summary>
        /// <param name="sendBlock">Send block</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Receive block</returns>
        public QlcResponse<Block> GenerateReceiveBlock(Block sendBlock, string privateKey = null) => this.GenerateReceiveBlockAsync(sendBlock, privateKey).Result;
        /// <summary>
        /// Return receive block by send block and private key
        /// </summary>
        /// <param name="sendBlock">Send block</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Receive block</returns>
        public async Task<QlcResponse<Block>> GenerateReceiveBlockAsync(Block sendBlock, string privateKey = null)
        {
            var request = new QlcRequest
            {
                Method = "ledger_generateReceiveBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlock, privateKey },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return change block by account and private key
        /// </summary>
        /// <param name="address">Account address</param>
        /// <param name="newRepresentative">New representative account address</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Change block</returns>
        public QlcResponse<Block> GenerateChangeBlock(string address, string newRepresentative, string privateKey = null) => this.GenerateChangeBlockAsync(address, newRepresentative, privateKey).Result;
        /// <summary>
        /// Return change block by account and private key
        /// </summary>
        /// <param name="address">Account address</param>
        /// <param name="newRepresentative">New representative account address</param>
        /// <param name="privateKey">Private key, if not set, will return block without signature and work</param>
        /// <returns>Change block</returns>
        public async Task<QlcResponse<Block>> GenerateChangeBlockAsync(string address, string newRepresentative, string privateKey = null)
        {
            var request = new QlcRequest
            {
                Method = "ledger_generateChangeBlock",
                Id = this.GetNextId(),
                Parameters = { address, newRepresentative, privateKey },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Check block base info, update chain info for the block, and broadcast block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>Block hash</returns>
        public QlcResponse<string> Process(Block block) => this.ProcessAsync(block).Result;
        /// <summary>
        /// Check block base info, update chain info for the block, and broadcast block
        /// </summary>
        /// <param name="block">The block</param>
        /// <returns>Block hash</returns>
        public async Task<QlcResponse<string>> ProcessAsync(Block block)
        {
            var request = new QlcRequest
            {
                Method = "ledger_process",
                Id = this.GetNextId(),
                Parameters = { block },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pairs of representative and its voting weight
        /// </summary>
        /// <param name="sort">If true (default) wil return representatives sorted by balance in descending order. If false, representatives will be returned in random order</param>
        /// <returns>Representatives</returns>
        public QlcResponse<List<Representative>> GetRepresentatives(bool sort = true) => this.GetRepresentativesAsync(sort).Result;
        /// <summary>
        /// Return pairs of representative and its voting weight
        /// </summary>
        /// <param name="sort">If true (default) wil return representatives sorted by balance in descending order. If false, representatives will be returned in random order</param>
        /// <returns>Representatives</returns>
        public async Task<QlcResponse<List<Representative>>> GetRepresentativesAsync(bool sort = true)
        {
            var request = new QlcRequest
            {
                Method = "ledger_representatives",
                Id = this.GetNextId(),
                Parameters = { sort },
            };

            return await this.netClient.GetResponseAsync<List<Representative>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return tokens of the chain
        /// </summary>
        /// <returns>Tokens</returns>
        public QlcResponse<List<Token>> GetTokens() => this.GetTokensAsync().Result;
        /// <summary>
        /// Return tokens of the chain
        /// </summary>
        /// <returns>Tokens</returns>
        public async Task<QlcResponse<List<Token>>> GetTokensAsync()
        {
            var request = new QlcRequest
            {
                Method = "ledger_tokens",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<List<Token>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return token info by token id
        /// </summary>
        /// <param name="id">Token id</param>
        /// <returns>Token info</returns>
        public QlcResponse<Token> GetTokenById(string id) => this.GetTokenByIdAsync(id).Result;
        /// <summary>
        /// Return token info by token id
        /// </summary>
        /// <param name="id">Token id</param>
        /// <returns>Token info</returns>
        public async Task<QlcResponse<Token>> GetTokenByIdAsync(string id)
        {
            var request = new QlcRequest
            {
                Method = "ledger_tokenInfoById",
                Id = this.GetNextId(),
                Parameters = { id },
            };

            return await this.netClient.GetResponseAsync<Token>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return token info by token name
        /// </summary>
        /// <param name="name">Token name</param>
        /// <returns>Token info</returns>
        public QlcResponse<Token> GetTokenByName(string name) => this.GetTokenByNameAsync(name).Result;
        /// <summary>
        /// Return token info by token name
        /// </summary>
        /// <param name="name">Token name</param>
        /// <returns>Token info</returns>
        public async Task<QlcResponse<Token>> GetTokenByNameAsync(string name)
        {
            var request = new QlcRequest
            {
                Method = "ledger_tokenInfoByName",
                Id = this.GetNextId(),
                Parameters = { name },
            };

            return await this.netClient.GetResponseAsync<Token>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return the number of blocks (not including smartcontract blocks) and unchecked blocks of chain
        /// </summary>
        /// <returns>Count</returns>
        public QlcResponse<TransactionCount> GetTransactionCount() => this.GetTransactionCountAsync().Result;
        public async Task<QlcResponse<TransactionCount>> GetTransactionCountAsync()
        {
            var request = new QlcRequest
            {
                Method = "ledger_transactionsCount",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<TransactionCount>(request).ConfigureAwait(false);
        }
    }
}
