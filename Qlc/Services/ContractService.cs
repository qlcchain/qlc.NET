using Qlc.Net;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class ContractService : QlcService
    {
        public ContractService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Pack the given method name to conform the ABI
        /// </summary>
        /// <param name="abiString">Abi string</param>
        /// <param name="methodName">Method name</param>
        /// <param name="arguments">Arguments for the method</param>
        /// <returns>Packed result</returns>
        public QlcResponse<string> PackContractData(string abiString, string methodName, string[] arguments) => this.PackContractDataAsync(abiString, methodName, arguments).Result;
        /// <summary>
        /// Pack the given method name to conform the ABI
        /// </summary>
        /// <param name="abiString">Abi string</param>
        /// <param name="methodName">Method name</param>
        /// <param name="arguments">Arguments for the method</param>
        /// <returns>Packed result</returns>
        public async Task<QlcResponse<string>> PackContractDataAsync(string abiString, string methodName, string[] arguments)
        {
            var request = new QlcRequest
            {
                Method = "contract_packContractData",
                Id = this.GetNextId(),
                Parameters = { abiString, methodName, arguments },
            };

            return await this.netClient.GetResponseAsync<string>(request).ConfigureAwait(false);
        }
    }
}
