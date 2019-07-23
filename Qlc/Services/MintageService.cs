using Qlc.Net;
using Qlc.Objects;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class MintageService : QlcService
    {
        public MintageService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return mintage data by mintage parameters
        /// </summary>
        /// <param name="mintageParameters">Mintage parameters</param>
        /// <returns>Data for mintage</returns>
        public QlcResponse<string> GetMintageData(MintageParameters mintageParameters) => this.GetMintageDataAsync(mintageParameters).Result;
        /// <summary>
        /// Return mintage data by mintage parameters
        /// </summary>
        /// <param name="mintageParameters">Mintage parameters</param>
        /// <returns>Data for mintage</returns>
        public async Task<QlcResponse<string>> GetMintageDataAsync(MintageParameters mintageParameters)
        {
            var request = new QlcRequest
            {
                Method = "mintage_getMintageData",
                Id = this.GetNextId(),
                Parameters = { mintageParameters },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return contract send block by mintage parameters
        /// </summary>
        /// <param name="mintageParameters">Mintage parameters</param>
        /// <returns>Mintage block, type is ContractSend</returns>
        public QlcResponse<Block> GetMintageBlock(MintageParameters mintageParameters) => this.GetMintageBlockAsync(mintageParameters).Result;
        /// <summary>
        /// Return contract send block by mintage parameters
        /// </summary>
        /// <param name="mintageParameters">Mintage parameters</param>
        /// <returns>Mintage block, type is ContractSend</returns>
        public async Task<QlcResponse<Block>> GetMintageBlockAsync(MintageParameters mintageParameters)
        {
            var request = new QlcRequest
            {
                Method = "mintage_getMintageBlock",
                Id = this.GetNextId(),
                Parameters = { mintageParameters },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return contract reward block by contract send block
        /// </summary>
        /// <param name="sendBlock">Contract send block</param>
        /// <returns>Contract reward block</returns>
        public QlcResponse<Block> GetRewardBlock(Block sendBlock) => this.GetRewardBlockAsync(sendBlock).Result;
        /// <summary>
        /// Return contract reward block by contract send block
        /// </summary>
        /// <param name="sendBlock">Contract send block</param>
        /// <returns>Contract reward block</returns>
        public async Task<QlcResponse<Block>> GetRewardBlockAsync(Block sendBlock)
        {
            var request = new QlcRequest
            {
                Method = "mintage_getRewardBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlock },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }
    }
}
