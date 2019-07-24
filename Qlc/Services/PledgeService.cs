using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class PledgeService : QlcService
    {
        public PledgeService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return pledge data by pledge parameters
        /// </summary>
        /// <param name="pledgeParameters">Pledge parameters</param>
        /// <returns>Data for pledge, base64 encoded</returns>
        public QlcResponse<string> GetPledgeData(PledgeParameters pledgeParameters) => this.GetPledgeDataAsync(pledgeParameters).Result;
        /// <summary>
        /// Return pledge data by pledge parameters
        /// </summary>
        /// <param name="pledgeParameters">Pledge parameters</param>
        /// <returns>Data for pledge, base64 encoded</returns>
        public async Task<QlcResponse<string>> GetPledgeDataAsync(PledgeParameters pledgeParameters)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeData",
                Id = this.GetNextId(),
                Parameters = { pledgeParameters },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge block by pledge parameters
        /// </summary>
        /// <param name="pledgeParameters">Pledge parameters</param>
        /// <returns>Contractsend block</returns>
        public QlcResponse<Block> GetPledgeBlock(PledgeParameters pledgeParameters) => this.GetPledgeBlockAsync(pledgeParameters).Result;
        /// <summary>
        /// Return pledge block by pledge parameters
        /// </summary>
        /// <param name="pledgeParameters">Pledge parameters</param>
        /// <returns>Contractsend block</returns>
        public async Task<QlcResponse<Block>> GetPledgeBlockAsync(PledgeParameters pledgeParameters)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeBlock",
                Id = this.GetNextId(),
                Parameters = { pledgeParameters },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge ContractReward block by ContractSendblock
        /// </summary>
        /// <param name="sendBlock">The send block</param>
        /// <returns>Contract reward block</returns>
        public QlcResponse<Block> GetPledgeRewardBlock(Block sendBlock) => this.GetPledgeRewardBlockAsync(sendBlock).Result;
        /// <summary>
        /// Return pledge ContractReward block by ContractSendblock
        /// </summary>
        /// <param name="sendBlock">The send block</param>
        /// <returns>Contract reward block</returns>
        public async Task<QlcResponse<Block>> GetPledgeRewardBlockAsync(Block sendBlock)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeRewardBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlock },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return withdraw data by pledge parameters
        /// </summary>
        /// <param name="withdrawPledgeParameters">Parameters</param>
        /// <returns>Withdraw data, base64 encoded</returns>
        public QlcResponse<string> GetWithdrawPledgeData(WithdrawPledgeParameters withdrawPledgeParameters) => this.GetWithdrawPledgeDataAsync(withdrawPledgeParameters).Result;
        /// <summary>
        /// Return withdraw data by pledge parameters
        /// </summary>
        /// <param name="withdrawPledgeParameters">Parameters</param>
        /// <returns>Withdraw data, base64 encoded</returns>
        public async Task<QlcResponse<string>> GetWithdrawPledgeDataAsync(WithdrawPledgeParameters withdrawPledgeParameters)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getWithdrawPledgeData",
                Id = this.GetNextId(),
                Parameters = { withdrawPledgeParameters },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return withdraw ContractSend block by withdraw params
        /// </summary>
        /// <param name="withdrawPledgeParameters">Parameters</param>
        /// <returns>ContractSend block</returns>
        public QlcResponse<Block> GetWithdrawPledgeBlock(WithdrawPledgeParameters withdrawPledgeParameters) => this.GetWithdrawPledgeBlockAsync(withdrawPledgeParameters).Result;
        public async Task<QlcResponse<Block>> GetWithdrawPledgeBlockAsync(WithdrawPledgeParameters withdrawPledgeParameters)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getWithdrawPledgeBlock",
                Id = this.GetNextId(),
                Parameters = { withdrawPledgeParameters },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return withdraw ContractReward block by withdraw ContractSend block
        /// </summary>
        /// <param name="sendBlock">ContractSend block</param>
        /// <returns>ContractReward block</returns>
        public QlcResponse<Block> GetWithdrawRewardBlock(Block sendBlock) => this.GetWithdrawRewardBlockAsync(sendBlock).Result;
        /// <summary>
        /// Return withdraw ContractReward block by withdraw ContractSend block
        /// </summary>
        /// <param name="sendBlock">ContractSend block</param>
        /// <returns>ContractReward block</returns>
        public async Task<QlcResponse<Block>> GetWithdrawRewardBlockAsync(Block sendBlock)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getWithdrawRewardBlock",
                Id = this.GetNextId(),
                Parameters = { sendBlock },
            };

            return await this.netClient.GetResponseAsync<Block>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge infos by pledge address
        /// </summary>
        /// <param name="pledgeAddress">pledge address</param>
        /// <returns>Pledge info</returns>
        public QlcResponse<AddressPledgeInfo> GetPledgeInfoByPledgeAddress(string pledgeAddress) => this.GetPledgeInfoByPledgeAddressAsync(pledgeAddress).Result;
        /// <summary>
        /// Return pledge infos by pledge address
        /// </summary>
        /// <param name="pledgeAddress">pledge address</param>
        /// <returns>Pledge info</returns>
        public async Task<QlcResponse<AddressPledgeInfo>> GetPledgeInfoByPledgeAddressAsync(string pledgeAddress)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeInfosByPledgeAddress",
                Id = this.GetNextId(),
                Parameters = { pledgeAddress },
            };

            return await this.netClient.GetResponseAsync<AddressPledgeInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return total reward amount of a beneficial address
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <returns>Total reward amount</returns>
        public QlcResponse<long> GetPledgeBeneficialTotalAmount(string beneficialAddress) => this.GetPledgeBeneficialTotalAmountAsync(beneficialAddress).Result;
        /// <summary>
        /// Return total reward amount of a beneficial address
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <returns>Total reward amount</returns>
        public async Task<QlcResponse<long>> GetPledgeBeneficialTotalAmountAsync(string beneficialAddress)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeBeneficialTotalAmount",
                Id = this.GetNextId(),
                Parameters = { beneficialAddress },
            };

            return await this.netClient.GetResponseAsync<long>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge infos of a beneficial address
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <returns>Pledge info</returns>
        public QlcResponse<AddressPledgeInfo> GetBeneficialPledgeInfoByAddress(string beneficialAddress) => this.GetBeneficialPledgeInfoByAddressAsync(beneficialAddress).Result;
        /// <summary>
        /// Return pledge infos of a beneficial address
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <returns>Pledge info</returns>
        public async Task<QlcResponse<AddressPledgeInfo>> GetBeneficialPledgeInfoByAddressAsync(string beneficialAddress)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getBeneficialPledgeInfosByAddress",
                Id = this.GetNextId(),
                Parameters = { beneficialAddress },
            };

            return await this.netClient.GetResponseAsync<AddressPledgeInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge info by beneficial address and pledge type
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <returns>Pledge info</returns>
        public QlcResponse<AddressPledgeInfo> GetBeneficialPledgeInfo(string beneficialAddress, string pledgeType) => this.GetBeneficialPledgeInfoAsync(beneficialAddress, pledgeType).Result;
        /// <summary>
        /// Return pledge info by beneficial address and pledge type
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <returns>Pledge info</returns>
        public async Task<QlcResponse<AddressPledgeInfo>> GetBeneficialPledgeInfoAsync(string beneficialAddress, string pledgeType)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getBeneficialPledgeInfos",
                Id = this.GetNextId(),
                Parameters = { beneficialAddress, pledgeType },
            };

            return await this.netClient.GetResponseAsync<AddressPledgeInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return total pledge amount by beneficial address and pledge type
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <returns>Total pledge amount</returns>
        public QlcResponse<long> GetBeneficialPledgeAmount(string beneficialAddress, string pledgeType) => this.GetBeneficialPledgeAmountAsync(beneficialAddress, pledgeType).Result;
        /// <summary>
        /// Return total pledge amount by beneficial address and pledge type
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <returns>Total pledge amount</returns>
        public async Task<QlcResponse<long>> GetBeneficialPledgeAmountAsync(string beneficialAddress, string pledgeType)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeBeneficialAmount",
                Id = this.GetNextId(),
                Parameters = { beneficialAddress, pledgeType },
            };

            return await this.netClient.GetResponseAsync<long>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge data by pledge parameters
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <param name="amount">Amount</param>
        /// <param name="nep5TxId">NEP5 transaction id</param>
        /// <returns>Pledge info</returns>
        public QlcResponse<PledgeInfo> GetPledgeInfoWithNep5TxId(string beneficialAddress, string pledgeType, string amount, string nep5TxId) =>
            this.GetPledgeInfoWithNep5TxIdAsync(beneficialAddress, pledgeType, amount, nep5TxId).Result;
        /// <summary>
        /// Return pledge data by pledge parameters
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <param name="amount">Amount</param>
        /// <param name="nep5TxId">NEP5 transaction id</param>
        /// <returns>Pledge info</returns>
        public async Task<QlcResponse<PledgeInfo>> GetPledgeInfoWithNep5TxIdAsync(string beneficialAddress, string pledgeType, string amount, string nep5TxId)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeInfoWithNEP5TxId",
                Id = this.GetNextId(),
                Parameters = { new { beneficial = beneficialAddress, amount, pType = pledgeType, nep5TxId } },
            };

            return await this.netClient.GetResponseAsync<PledgeInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return pledge data by pledge parameters，if there are multiple identical pledge in the query result, it will be returned in time order
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <param name="amount">Amount of pledge</param>
        /// <returns>Pledge info</returns>
        public QlcResponse<List<PledgeInfo>> GetPledgeInfo(string beneficialAddress, string pledgeType, string amount) =>
            this.GetPledgeInfoAsync(beneficialAddress, pledgeType, amount).Result;
        /// <summary>
        /// Return pledge data by pledge parameters，if there are multiple identical pledge in the query result, it will be returned in time order
        /// </summary>
        /// <param name="beneficialAddress">Beneficial address</param>
        /// <param name="pledgeType">Pledge type</param>
        /// <param name="amount">Amount of pledge</param>
        /// <returns>Pledge info</returns>
        public async Task<QlcResponse<List<PledgeInfo>>> GetPledgeInfoAsync(string beneficialAddress, string pledgeType, string amount)
        {
            var request = new QlcRequest
            {
                Method = "pledge_getPledgeInfo",
                Id = this.GetNextId(),
                Parameters = { new { beneficial = beneficialAddress, amount, pType = pledgeType } },
            };

            return await this.netClient.GetResponseAsync<List<PledgeInfo>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return all pledge info
        /// </summary>
        public QlcResponse<List<PledgeInfo>> GetAllPledgeInfo() => this.GetAllPledgeInfoAsync().Result;
        /// <summary>
        /// Return all pledge info
        /// </summary>
        public async Task<QlcResponse<List<PledgeInfo>>> GetAllPledgeInfoAsync()
        {
            var request = new QlcRequest
            {
                Method = "pledge_getAllPledgeInfo",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<List<PledgeInfo>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Returns total pledge amount on chain
        /// </summary>
        /// <returns>Total pledge amount</returns>
        public QlcResponse<ulong> GetTotalPledgeAmount() => this.GetTotalPledgeAmountAsync().Result;
        /// <summary>
        /// Returns total pledge amount on chain
        /// </summary>
        /// <returns>Total pledge amount</returns>
        public async Task<QlcResponse<ulong>> GetTotalPledgeAmountAsync()
        {
            var request = new QlcRequest
            {
                Method = "pledge_getTotalPledgeAmount",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<ulong>(request).ConfigureAwait(false);
        }
    }
}
