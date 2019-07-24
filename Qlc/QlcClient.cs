using Newtonsoft.Json;
using Qlc.Net;
using Qlc.Services;
using System;

namespace Qlc
{
    /// <summary>
    /// A client that lets you interact seamlessly with the QLC blockchain.
    /// For more detailed information please refer to the documentation here: https://docs.qlcchain.online/api/rpc/
    /// </summary>
    public class QlcClient
    {
        public const string DefaultQlcEndpointAddress = "https://rpc.qlcchain.online/";
        private readonly JsonSerializerSettings DefaultSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public QlcClient() : this(new Uri(DefaultQlcEndpointAddress))
        {

        }

        public QlcClient(Uri endpointAddress, JsonSerializerSettings jsonSerializerSettings = null)
        {
            this.EndpointAddress = endpointAddress ?? throw new ArgumentNullException(nameof(endpointAddress));
            this.JsonSerializerSettings = jsonSerializerSettings ?? DefaultSerializerSettings;

            var client = new RpcClient(this.EndpointAddress, this.JsonSerializerSettings);
            this.Account = new AccountService(client);
            this.Contract = new ContractService(client);
            this.Ledger = new LedgerService(client);
            this.Miner = new MinerService(client);
            this.Mintage = new MintageService(client);
            this.Net = new NetService(client);
            this.Pledge = new PledgeService(client);
            this.Pov = new PovService(client);
            this.Rewards = new RewardsService(client);
            this.Sms = new SmsService(client);
            this.Utility = new UtilityService(client);
            this.Wallet = new WalletService(client);
        }

        public AccountService Account { get; private set; }
        public ContractService Contract { get; private set; }
        public LedgerService Ledger { get; private set; }
        public MinerService Miner { get; private set; }
        public MintageService Mintage { get; private set; }
        public NetService Net { get; private set; }
        public PledgeService Pledge { get; private set; }
        public PovService Pov { get; private set; }
        public RewardsService Rewards { get; private set; }
        public SmsService Sms { get; private set; }
        public UtilityService Utility { get; private set; }
        public WalletService Wallet { get; private set; }

        public Uri EndpointAddress { get; private set; }
        private JsonSerializerSettings JsonSerializerSettings { get; set; }
    }
}
