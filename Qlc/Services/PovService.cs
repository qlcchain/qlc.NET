using Qlc.Net;
using Qlc.Objects;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class PovService : QlcService
    {
        public PovService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return fittest block header of PoV main chain, used by send TXs
        /// </summary>
        /// <param name="gap">gap before latest block header, default is 0</param>
        /// <returns>block header struct</returns>
        public QlcResponse<PovBlockHeader> GetFittestHeader(int gap = 0) => this.GetFittestHeaderAsync(gap).Result;
        /// <summary>
        /// Return fittest block header of PoV main chain, used by send TXs
        /// </summary>
        /// <param name="gap">gap before latest block header, default is 0</param>
        /// <returns>block header struct</returns>
        public async Task<QlcResponse<PovBlockHeader>> GetFittestHeaderAsync(int gap = 0)
        {
            var request = new QlcRequest
            {
                Method = "pov_getFittestHeader",
                Id = this.GetNextId(),
                Parameters = { gap },
            };

            return await this.netClient.GetResponseAsync<PovBlockHeader>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return latest block header of PoV main chain
        /// </summary>
        /// <returns>block header struct</returns>
        public QlcResponse<PovBlockHeader> GetLatestHeader() => this.GetLatestHeaderAsync().Result;
        /// <summary>
        /// Return latest block header of PoV main chain
        /// </summary>
        /// <returns>block header struct</returns>
        public async Task<QlcResponse<PovBlockHeader>> GetLatestHeaderAsync()
        {
            var request = new QlcRequest
            {
                Method = "pov_getLatestHeader",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<PovBlockHeader>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return block header by height
        /// </summary>
        /// <param name="height">Block height</param>
        /// <returns>block header struct</returns>
        public QlcResponse<PovBlockHeader> GetHeaderByHeight(ulong height) => this.GetHeaderByHeightAsync(height).Result;
        /// <summary>
        /// Return block header by height
        /// </summary>
        /// <param name="height">Block height</param>
        /// <returns>block header struct</returns>
        public async Task<QlcResponse<PovBlockHeader>> GetHeaderByHeightAsync(ulong height)
        {
            var request = new QlcRequest
            {
                Method = "pov_getHeaderByHeight",
                Id = this.GetNextId(),
                Parameters = { height },
            };

            return await this.netClient.GetResponseAsync<PovBlockHeader>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return block header by hash
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <returns>Block header struct</returns>
        public QlcResponse<PovBlockHeader> GetHeaderByHash(string hash) => this.GetHeaderByHashAsync(hash).Result;
        /// <summary>
        /// Return block header by hash
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <returns>Block header struct</returns>
        public async Task<QlcResponse<PovBlockHeader>> GetHeaderByHashAsync(string hash)
        {
            var request = new QlcRequest
            {
                Method = "pov_getHeaderByHash",
                Id = this.GetNextId(),
                Parameters = { hash },
            };

            return await this.netClient.GetResponseAsync<PovBlockHeader>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return many block headers by height
        /// </summary>
        /// <param name="height">Block height</param>
        /// <param name="count">Block count</param>
        /// <param name="direction">true - ascend(forward), false - descend(backward)</param>
        /// <returns>Block headers</returns>
        public QlcResponse<PovBlockHeaders> GetHeadersByHeight(ulong height, ulong count, bool direction) => this.GetHeadersByHeightAsync(height, count, direction).Result;
        /// <summary>
        /// Return many block headers by height
        /// </summary>
        /// <param name="height">Block height</param>
        /// <param name="count">Block count</param>
        /// <param name="direction">true - ascend(forward), false - descend(backward)</param>
        /// <returns>Block headers</returns>
        public async Task<QlcResponse<PovBlockHeaders>> GetHeadersByHeightAsync(ulong height, ulong count, bool direction)
        {
            var request = new QlcRequest
            {
                Method = "pov_batchGetHeadersByHeight",
                Id = this.GetNextId(),
                Parameters = { height, count, direction },
            };

            return await this.netClient.GetResponseAsync<PovBlockHeaders>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return latest full block of PoV main chain
        /// </summary>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public QlcResponse<PovBlock> GetLatestBlock(int txOffset = 0, int txLimit = 100) => this.GetLatestBlockAsync(txOffset, txLimit).Result;
        /// <summary>
        /// Return latest full block of PoV main chain
        /// </summary>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public async Task<QlcResponse<PovBlock>> GetLatestBlockAsync(int txOffset = 0, int txLimit = 100)
        {
            var request = new QlcRequest
            {
                Method = "pov_getLatestBlock",
                Id = this.GetNextId(),
                Parameters = { txOffset, txLimit },
            };

            return await this.netClient.GetResponseAsync<PovBlock>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return full block by height
        /// </summary>
        /// <param name="height">Block height</param>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public QlcResponse<PovBlock> GetBlockByHeight(ulong height, int txOffset = 0, int txLimit = 100) => this.GetBlockByHeightAsync(height, txOffset, txLimit).Result;
        /// <summary>
        /// Return full block by height
        /// </summary>
        /// <param name="height">Block heigth</param>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public async Task<QlcResponse<PovBlock>> GetBlockByHeightAsync(ulong height, int txOffset = 0, int txLimit = 100)
        {
            var request = new QlcRequest
            {
                Method = "pov_getBlockByHeight",
                Id = this.GetNextId(),
                Parameters = { height, txOffset, txLimit },
            };

            return await this.netClient.GetResponseAsync<PovBlock>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return full block by hash
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public QlcResponse<PovBlock> GetBlockByHash(string hash, int txOffset = 0, int txLimit = 100) => this.GetBlockByHashAsync(hash, txOffset, txLimit).Result;
        /// <summary>
        /// Return full block by hash
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <param name="txOffset">Return transcations from offset in block, default is 0</param>
        /// <param name="txLimit">Return transcations not excced limit, default is 100</param>
        /// <returns>PoV block</returns>
        public async Task<QlcResponse<PovBlock>> GetBlockByHashAsync(string hash, int txOffset = 0, int txLimit = 100)
        {
            var request = new QlcRequest
            {
                Method = "pov_getBlockByHash",
                Id = this.GetNextId(),
                Parameters = { hash, txOffset, txLimit },
            };

            return await this.netClient.GetResponseAsync<PovBlock>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return transaction by tx hash
        /// </summary>
        /// <param name="txHash">Transaction hash</param>
        /// <returns>Transaction</returns>
        public QlcResponse<PovTransaction> GetTransaction(string txHash) => this.GetTransactionAsync(txHash).Result;
        /// <summary>
        /// Return transaction by tx hash
        /// </summary>
        /// <param name="txHash">Transaction hash</param>
        /// <returns>Transaction</returns>
        public async Task<QlcResponse<PovTransaction>> GetTransactionAsync(string txHash)
        {
            var request = new QlcRequest
            {
                Method = "pov_getTransaction",
                Id = this.GetNextId(),
                Parameters = { txHash },
            };

            return await this.netClient.GetResponseAsync<PovTransaction>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return transaction by block hash and tx index
        /// </summary>
        /// <param name="blockHash">block hash</param>
        /// <param name="index">tx index</param>
        /// <returns>Transaction</returns>
        public QlcResponse<PovTransaction> GetTransactionByBlockHashAndIndex(string blockHash, int index) => this.GetTransactionByBlockHashAndIndexAsync(blockHash, index).Result;
        /// <summary>
        /// Return transaction by block hash and tx index
        /// </summary>
        /// <param name="blockHash">block hash</param>
        /// <param name="index">tx index</param>
        /// <returns>Transaction</returns>
        public async Task<QlcResponse<PovTransaction>> GetTransactionByBlockHashAndIndexAsync(string blockHash, int index)
        {
            var request = new QlcRequest
            {
                Method = "pov_getTransactionByBlockHashAndIndex",
                Id = this.GetNextId(),
                Parameters = { blockHash, index },
            };

            return await this.netClient.GetResponseAsync<PovTransaction>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return transaction by block height and tx index
        /// </summary>
        /// <param name="blockHeight">Block height</param>
        /// <param name="index">Tx index</param>
        /// <returns>Transaction</returns>
        public QlcResponse<PovTransaction> GetTransactionByBlockHeightAndIndex(ulong blockHeight, int index) => this.GetTransactionByBlockHeightAndIndexAsync(blockHeight, index).Result;
        /// <summary>
        /// Return transaction by block height and tx index
        /// </summary>
        /// <param name="blockHeight">Block height</param>
        /// <param name="index">Tx index</param>
        /// <returns>Transaction</returns>
        public async Task<QlcResponse<PovTransaction>> GetTransactionByBlockHeightAndIndexAsync(ulong blockHeight, int index)
        {
            var request = new QlcRequest
            {
                Method = "pov_getTransactionByBlockHeightAndIndex",
                Id = this.GetNextId(),
                Parameters = { blockHeight, index },
            };

            return await this.netClient.GetResponseAsync<PovTransaction>(request).ConfigureAwait(false);
        }
    }
}
