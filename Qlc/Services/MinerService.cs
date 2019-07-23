using Qlc.Net;
using Qlc.Objects;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class MinerService : QlcService
    {
        public MinerService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return miner history reward info by coinbase address
        /// </summary>
        /// <param name="coinbase">Miner address</param>
        /// <returns>Reward history</returns>
        public QlcResponse<HistoricalRewardInfo> GetRewardHistory(string coinbase) => this.GetRewardHistoryAsync(coinbase).Result;
        /// <summary>
        /// Return miner history reward info by coinbase address
        /// </summary>
        /// <param name="coinbase">Miner address</param>
        /// <returns>Reward history</returns>
        public async Task<QlcResponse<HistoricalRewardInfo>> GetRewardHistoryAsync(string coinbase)
        {
            var request = new QlcRequest
            {
                Method = "miner_getHistoryRewardInfos",
                Id = this.GetNextId(),
                Parameters = { coinbase },
            };

            return await this.netClient.GetResponseAsync<HistoricalRewardInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return miner available reward info by coinbase address. Client should call miner reward contract when NeedCallReward is true.
        /// </summary>
        /// <param name="coinbase"></param>
        /// <returns>Available rewards</returns>
        public QlcResponse<AvailableRewardInfo> GetAvailableRewardInfo(string coinbase) => this.GetAvailableRewardInfoAsync(coinbase).Result;
        /// <summary>
        /// Return miner available reward info by coinbase address. Client should call miner reward contract when NeedCallReward is true.
        /// </summary>
        /// <param name="coinbase"></param>
        /// <returns>Available rewards</returns>
        public async Task<QlcResponse<AvailableRewardInfo>> GetAvailableRewardInfoAsync(string coinbase)
        {
            var request = new QlcRequest
            {
                Method = "miner_getAvailRewardInfo",
                Id = this.GetNextId(),
                Parameters = { coinbase },
            };

            return await this.netClient.GetResponseAsync<AvailableRewardInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return contract send block by reward parameters
        /// </summary>
        /// <param name="rewardParameters">miner reward parameters</param>
        /// <returns>Reward block, type is ContractSend</returns>
        public QlcResponse<Block> GetRewardSendBlock(RewardParameters rewardParameters) => this.GetRewardSendBlockAsync(rewardParameters).Result;
        /// <summary>
        /// Return contract send block by reward parameters
        /// </summary>
        /// <param name="rewardParameters">miner reward parameters</param>
        /// <returns>Reward block, type is ContractSend</returns>
        public async Task<QlcResponse<Block>> GetRewardSendBlockAsync(RewardParameters rewardParameters)
        {
            var request = new QlcRequest
            {
                Method = "miner_getRewardSendBlock",
                Id = this.GetNextId(),
                Parameters = { rewardParameters },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return contract reward block by contract send block hash
        /// </summary>
        /// <param name="sendHash">Contract send block hash</param>
        /// <returns>Contract reward block</returns>
        public QlcResponse<Block> GetRewardReceiveBlockBySendHash(string sendHash) => this.GetRewardReceiveBlockBySendHashAsync(sendHash).Result;
        /// <summary>
        /// Return contract reward block by contract send block hash
        /// </summary>
        /// <param name="sendHash">Contract send block hash</param>
        /// <returns>Contract reward block</returns>
        public async Task<QlcResponse<Block>> GetRewardReceiveBlockBySendHashAsync(string sendHash)
        {
            var request = new QlcRequest
            {
                Method = "miner_getRewardRecvBlockBySendHash",
                Id = this.GetNextId(),
                Parameters = { sendHash },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return contract reward block by contract send block
        /// </summary>
        /// <param name="sendBlock">Contract send block</param>
        /// <returns>Contract reward block</returns>
        public QlcResponse<Block> GetRewardReceiveBlock(Block sendBlock) => this.GetRewardReceiveBlockAsync(sendBlock).Result;
        public async Task<QlcResponse<Block>> GetRewardReceiveBlockAsync(Block sendBlock)
        {
            var request = new QlcRequest
            {
                Method = "miner_getRewardRecvBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlock },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }
    }
}
