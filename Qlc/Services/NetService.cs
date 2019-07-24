using Qlc.Net;
using Qlc.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qlc.Services
{
    public class NetService : QlcService
    {
        public NetService(IQlcNetClient netClient) : base(netClient)
        {
        }

        /// <summary>
        /// Return connect peers
        /// </summary>
        /// <returns>Connected peers</returns>
        public QlcResponse<ConnectedPeersInfo> GetConnectedPeers() => this.GetConnectedPeersAsync().Result;
        /// <summary>
        /// Return connect peers
        /// </summary>
        /// <returns>Connected peers</returns>
        public async Task<QlcResponse<ConnectedPeersInfo>> GetConnectedPeersAsync()
        {
            var request = new QlcRequest
            {
                Method = "net_connectPeersInfo",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<ConnectedPeersInfo>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return online representative accounts that have voted recently
        /// </summary>
        /// <returns>Address list for representative accounts</returns>
        public QlcResponse<List<string>> GetOnlineRepresentatives() => this.GetOnlineRepresentativesAsync().Result;
        /// <summary>
        /// Return online representative accounts that have voted recently
        /// </summary>
        /// <returns>Address list for representative accounts</returns>
        public async Task<QlcResponse<List<string>>> GetOnlineRepresentativesAsync()
        {
            var request = new QlcRequest
            {
                Method = "net_onlineRepresentatives",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<List<string>>(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Return sync status
        /// </summary>
        /// <returns>True: syncing now; False: not syncing</returns>
        public QlcResponse<bool> GetSyncStatus() => this.GetSyncStatusAsync().Result;
        /// <summary>
        /// Return sync status
        /// </summary>
        /// <returns>True: syncing now; False: not syncing</returns>
        public async Task<QlcResponse<bool>> GetSyncStatusAsync()
        {
            var request = new QlcRequest
            {
                Method = "net_syncing",
                Id = this.GetNextId(),
                Parameters = { },
            };

            return await this.netClient.GetResponseAsync<bool>(request).ConfigureAwait(false);
        }
    }
}
