using System.Collections.Generic;
using Blocknet.Lib.RPC.RequestResponse;
using Newtonsoft.Json;

namespace Blocknet.Lib.Services.Coins.Blocknet.Xrouter
{
    public class ConnectedNodeResponse : JsonRpcXrError
    {
        public string NodePubKey { get; set; }
        public int Score { get; set; }
        public bool Banned { get; set; }
        public string PaymentAddress { get; set; }
        public List<string> SpvWallets { get; set; }
        public List<SpvConfig> SpvConfigs { get; set; }
        public double FeeDefault { get; set; }
        public Dictionary<string, double> Fees { get; set; }
        public Dictionary<string, XCloudService> Services { get; set; }

        public class SpvConfig
        {
            public string SpvWallet { get; set; }
            public List<SpvCommand> Commands { get; set; }

            public class SpvCommand:BaseXRouterService
            {
                public string Command { get; set; }
            }
        }
        public class XCloudService:BaseXRouterService
        {
            public string Parameters { get; set; }
        }
        
        public class BaseXRouterService
        {
            public double Fee { get; set; }
            public int FetchLimit { get; set; }
            public int RequestLimit { get; set; }
            public string PaymentAddress { get; set; }
            public bool Disabled { get; set; }
        }
    }

    
}