﻿// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using System.Collections.Generic;
using Blocknet.Lib.Responses.Bridges;
using Blocknet.Lib.Responses.SharedComponents;
using Blocknet.Lib.Services.Coins.Blocknet.Xrouter;

namespace Blocknet.Lib.Responses
{
    public class GetRawTransactionResponse : ErrorResponse, ITransactionResponse
    {
        public string Hex { get; set; }
        public long Version { get; set; }
        public uint LockTime { get; set; }
        public List<Vin> Vin { get; set; }
        public List<Vout> Vout { get; set; }
        public string BlockHash { get; set; }
        public int Confirmations { get; set; }
        public uint Time { get; set; }
        public uint BlockTime { get; set; }
        public string TxId { get; set; }
    }
}