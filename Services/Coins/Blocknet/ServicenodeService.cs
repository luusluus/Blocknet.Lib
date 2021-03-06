using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Blocknet.Lib.CoinParameters.Blocknet;
using Blocknet.Lib.RPC.RequestResponse;
using Blocknet.Lib.RPC.Specifications;
using Blocknet.Lib.Services.Coins.Blocknet.Xrouter;
using Blocknet.Lib.Services.Coins.Blocknet.Xrouter.BitcoinBased;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xrouter.Service.Explorer.BitcoinLib.Services.Coins.Blocknet.XRouter;

namespace Blocknet.Lib.Services.Coins.Blocknet
{
	/// <summary>
	/// Mostly the same functionality as <see cref="BitcoinService"/>, just adds a bunch more features
	/// for handling InstantSend and PrivateSend, plus better raw tx generation support.
	/// </summary>
	public class ServicenodeService : BlocknetService, IServicenodeService
	{
		public ServicenodeService(bool useTestnet = false) : base(useTestnet) { }

		public ServicenodeService(string daemonUrl, string rpcUsername, string rpcPassword,
			string walletPassword) : base(daemonUrl, rpcUsername, rpcPassword, walletPassword) { }

		public ServicenodeService(string daemonUrl, string rpcUsername, string rpcPassword,
			string walletPassword, short rpcRequestTimeoutInSeconds) : base(daemonUrl, rpcUsername,
			rpcPassword, walletPassword, rpcRequestTimeoutInSeconds) { }

        public List<ServiceNodeInfoResponse> serviceNodeList()
        {
            return _rpcConnector.MakeRequest<List<ServiceNodeInfoResponse>>(RpcMethods.servicenodelist);
        }
    }
}
