using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Blocknet.Lib.Auxiliary;
using Blocknet.Lib.ExceptionHandling.Rpc;
using Blocknet.Lib.ExtensionMethods;
using Blocknet.Lib.RPC.RequestResponse;
using Blocknet.Lib.RPC.Specifications;
using Blocknet.Lib.Services.Coins.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Blocknet.Lib.Services.Coins.Blocknet.Xrouter;
using Blocknet.Lib.Responses;
using System.Reflection;
using Blocknet.Lib.Services.Coins.Blocknet.Xrouter.Ethereum;

namespace Blocknet.Lib.RPC.Deserializer
{
    public class ValidOrErrorConverterEthereum : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        private T Populate<T>(JToken token, Type objectType, JsonSerializer serializer) where T : ErrorResponse, new()
        {

            var instance = new T();
            var error = token.SelectToken("error");

            if (error != null)
            {

                var errorMessage = error.SelectToken("message");
                if (errorMessage != null)
                {
                    serializer.Populate(token.CreateReader(), instance);
                    return instance;
                }

                instance.Error = new JsonRpcError { Message = error.ToObject<string>(), Code = (RpcErrorCode)token.SelectToken("code").ToObject<int>() };
                return instance;
            }

            serializer.Populate(token.CreateReader(), instance);
            return instance;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (objectType == typeof(GetBlockCountResponse))
            {
                return Populate<GetBlockCountResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(GetBlockHashResponse))
            {
                return Populate<GetBlockHashResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(Services.Coins.Blocknet.Xrouter.Ethereum.GetBlockResponse))
            {
                return Populate<Services.Coins.Blocknet.Xrouter.Ethereum.GetBlockResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(Services.Coins.Blocknet.Xrouter.Ethereum.GetTransactionResponse))
            {
                return Populate<Services.Coins.Blocknet.Xrouter.Ethereum.GetTransactionResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(GetBlocksResponse))
            {
                return Populate<GetBlocksResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(GetTransactionsResponse))
            {
                return Populate<GetTransactionsResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(GetDecodeRawTransactionResponse))
            {
                return Populate<GetDecodeRawTransactionResponse>(token, objectType, serializer);
            }

            if (objectType == typeof(SendTransactionResponse))
            {
                return Populate<SendTransactionResponse>(token, objectType, serializer);
            }

            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}