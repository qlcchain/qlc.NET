using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class RewardsService : QlcService
    {
        public RewardsService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Returns airdrop contract reward block by contract send block hash
        /// </summary>
        /// <param name="sendBlockHash">Contract send block hash</param>
        /// <returns>Contract reward block</returns>
        public QlcResponse<Block> GetReceiveRewardBlock(string sendBlockHash) => this.GetReceiveRewardBlockAsync(sendBlockHash).Result;
        /// <summary>
        /// Returns airdrop contract reward block by contract send block hash
        /// </summary>
        /// <param name="sendBlockHash">Contract send block hash</param>
        /// <returns>Contract reward block</returns>
        public async Task<QlcResponse<Block>> GetReceiveRewardBlockAsync(string sendBlockHash)
        {
            var request = new QlcRequest
            {
                Method = "rewards_getReceiveRewardBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlockHash },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns total airdrop qgas amount for a specific pledge
        /// </summary>
        /// <param name="pledgeTxId">Transaction id for the pledge</param>
        /// <returns>Total rewards</returns>
        public QlcResponse<ulong> GetTotalRewards(string pledgeTxId) => this.GetTotalRewardsAsync(pledgeTxId).Result;
        /// <summary>
        /// Returns total airdrop qgas amount for a specific pledge
        /// </summary>
        /// <param name="pledgeTxId">Transaction id for the pledge</param>
        /// <returns>Total rewards</returns>
        public async Task<QlcResponse<ulong>> GetTotalRewardsAsync(string pledgeTxId)
        {
            var request = new QlcRequest
            {
                Method = "rewards_getTotalRewards",
                Id = this.GetNextId(),
                Parameters = { pledgeTxId },
            };

            return await this.netClient.GetResponseAsync<ulong>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns airdrop qgas reward detail info for a specific pledge
        /// </summary>
        /// <param name="pledgeTxId">Transaction id for the pledge</param>
        /// <returns>Reward details</returns>
        public QlcResponse<List<RewardDetails>> GetRewardDetails(string pledgeTxId) => this.GetRewardDetailsAsync(pledgeTxId).Result;
        /// <summary>
        /// Returns airdrop qgas reward detail info for a specific pledge
        /// </summary>
        /// <param name="pledgeTxId">Transaction id for the pledge</param>
        /// <returns>Reward details</returns>
        public async Task<QlcResponse<List<RewardDetails>>> GetRewardDetailsAsync(string pledgeTxId)
        {
            var request = new QlcRequest
            {
                Method = "rewards_getRewardsDetail",
                Id = this.GetNextId(),
                Parameters = { pledgeTxId },
            };

            return await this.netClient.GetResponseAsync<List<RewardDetails>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns airdrop qgas rewards for a specific confidant address
        /// </summary>
        /// <param name="confidantAddress">Confidant address</param>
        /// <returns>rewards - key : hash of confidant Id - value : rewards amount</returns>
        public QlcResponse<Dictionary<string, ulong>> GetConfidantRewards(string confidantAddress) => this.GetConfidantRewardsAsync(confidantAddress).Result;
        /// <summary>
        /// Returns airdrop qgas rewards for a specific confidant address
        /// </summary>
        /// <param name="confidantAddress">Confidant address</param>
        /// <returns>rewards - key : hash of confidant Id - value : rewards amount</returns>
        public async Task<QlcResponse<Dictionary<string,ulong>>> GetConfidantRewardsAsync(string confidantAddress)
        {
            var request = new QlcRequest
            {
                Method = "rewards_getConfidantRewards",
                Id = this.GetNextId(),
                Parameters = { confidantAddress },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, ulong>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns airdrop qgas rewards detail info for a specific confidant address
        /// </summary>
        /// <param name="confidantAddress">Confidant address</param>
        /// <returns>Reward details</returns>
        public QlcResponse<Dictionary<string, List<RewardDetails>>> GetConfidantRewardDetails(string confidantAddress) =>
            this.GetConfidantRewardDetailsAsync(confidantAddress).Result;
        /// <summary>
        /// Returns airdrop qgas rewards detail info for a specific confidant address
        /// </summary>
        /// <param name="confidantAddress">Confidant address</param>
        /// <returns>Reward details</returns>
        public async Task<QlcResponse<Dictionary<string, List<RewardDetails>>>> GetConfidantRewardDetailsAsync(string confidantAddress)
        {
            var request = new QlcRequest
            {
                Method = "rewards_getConfidantRewordsDetail",
                Id = this.GetNextId(),
                Parameters = { confidantAddress },
            };

            return await this.netClient.GetResponseAsync<Dictionary<string, List<RewardDetails>>>(request).ConfigureAwait(false);
        }
    }
}
